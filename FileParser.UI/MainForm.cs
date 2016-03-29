using FileParser.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileParser.UI
{
    public partial class MainForm : Form
    {
        string[] args = Environment.GetCommandLineArgs();

        //string[] args = { "PATH","inputA.csv", "inputB.json" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var outputFile = "output.txt";
            var outputStream = new StreamWriter(new FileStream(outputFile, FileMode.Create, FileAccess.Write));

            if (args.Length != 3)
            {
                MessageBox.Show("App requires two files as parameters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            for (int i = 1; i < args.Length; i++)
            {
                var file = new InputFile(args[i]);

                file.Parse(outputStream);
            }
            

        }
    }
}
