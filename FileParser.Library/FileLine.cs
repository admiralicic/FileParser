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
                return NormalizeCSV();
            else if (_fileExtension.Equals(".json"))
                return NormalizeJson();

            return null;
        }

        private string NormalizeCSV()
        {
            return '"' + _fileName + '"' + "," + _lineText;
        }

        private string NormalizeJson()
        {
            var normalizedLine = _lineText.Substring(2, _lineText.Length - 3);
            string[] lineSplit = normalizedLine.Split(new char[] { ':', ',' });

            normalizedLine = "";

            for (int i = 1; i < lineSplit.Length; i += 2)
            {
                normalizedLine += lineSplit[i].Trim() + ",";
            }
            
            normalizedLine = normalizedLine.Substring(0, normalizedLine.Length - 1);
            normalizedLine = '"' + _fileName + '"' + "," + normalizedLine;

            return normalizedLine;
        }
    }
}
