using FileParser.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileParser.UI
{
    delegate void UpdateListCallback(string text);
    public partial class MainForm : Form
    {
        //string[] args = Environment.GetCommandLineArgs();         // for production
        string[] args = { "PATH", "inputA.csv", "inputB.json" };    // for testing
        string path = Environment.CurrentDirectory;
        private object _lock = new object();
        private bool _done;
        List<string> validFiles = new List<string>() { ".json", ".csv" };
        private double totalReadTime;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var outputFile = "output.txt";
            var outputStream = new StreamWriter(new FileStream(outputFile,
                FileMode.Create, FileAccess.Write));
            try
            {
                if (args.Length != 3)
                {
                    throw new Exception("App requires two files as parameters");
                }

                for (int i = 1; i < args.Length; i++)
                {
                    var file = new InputFile(args[i]);
                    if (!validFiles.Contains(file.GetFileExtension()))
                        throw new Exception("Input files must be valid json or csv");
                    Thread t = new Thread( ()=> ProcessFile(outputStream, file) );
                    t.Start();
                  
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                Application.Exit();
            }

        }

        private void ProcessFile(StreamWriter outputStream, InputFile file)
        {
            DateTime readStartTime;
            DateTime readEndTime;

            var line = string.Empty;

            readStartTime = DateTime.Now;

            while ((line = file.ReadLine()) != null)
            {
                readEndTime = DateTime.Now;
                lock (_lock)
                {
                    outputStream.WriteLine(line);
                    UpdateList(line);
                    //Thread.Sleep(10); //remove after testing....
                }

                UpdateTotalReadTime(readStartTime, readEndTime);

                readStartTime = DateTime.Now;
            }
            if (_done)
            {
                outputStream.WriteLine(String.Format("Reading input files completed in {0}ms", totalReadTime));
                outputStream.Close();
            }
            else
                _done = true;
        }

        private void UpdateTotalReadTime(DateTime readStartTime, DateTime readEndTime)
        {
            totalReadTime = totalReadTime + (readEndTime - readStartTime).TotalMilliseconds;
        }

        private void UpdateList(string line)
        {
            if (OutputList.InvokeRequired)
            {
                UpdateListCallback c = new UpdateListCallback(UpdateList);
                this.Invoke(c, new object[] { line });
            }
            else
            {
                OutputList.Items.Add(line);
            }
        }
    }
}
