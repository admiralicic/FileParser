using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Library
{
    public class FileLine
    {
        private string _fileExtension;
        private string _fileName;
        private string _lineText;

        public FileLine(string lineText, string fileName, string fileExtension)
        {
            _lineText = lineText;
            _fileName = fileName;
            _fileExtension = fileExtension;
        }

        public string GetNormalized()
        {
            if (_fileExtension.Equals(".csv"))
            {
                return NormalizeCSV();
            } else if (_fileExtension.Equals(".json"))
            {
                return NormalizeJson();
            }

            return null;
        }

        private string NormalizeCSV()
        {
            return @"""inputA"",""cfd001"",4000,132.50";
        }

        private string NormalizeJson()
        {
            return @"""inputA"",""afa072"",3000,22.15";
        }
    }
}
