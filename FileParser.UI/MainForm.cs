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
    public partial class MainForm : Form
    {
        //string[] args = Environment.GetCommandLineArgs();
        List<string> validFiles = new List<string>() { ".json", ".csv" };

        string[] args = { "PATH","inputA.csv", "inputB.json" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var outputFile = "output.txt";
            var outputStream = new StreamWriter(new FileStream(outputFile, FileMode.Create, FileAccess.Write));
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

                    var thread = new Thread(() => file.Parse(outputStream));
                    thread.Start();

                    //file.Parse(outputStream);
                }

                //outputStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }

        private void UpdateList(string line)
        {

        }
    }
}
