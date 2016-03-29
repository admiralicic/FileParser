using FileParser.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileParser.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var inputFile = new InputFile(@"C:/Tests/inputA.csv");

            var fileName = inputFile.GetFileName();
            var fileExtension = inputFile.GetFileExtension();
        }
    }
}
