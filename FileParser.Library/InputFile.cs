using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Library
{
    public class InputFile
    {
        private string _filePath;

        public InputFile(string filePath)
        {
            try
            {
                Path.GetFullPath(filePath);
            }
            catch (Exception)
            {
                throw new ArgumentException("File path invalid");
            }

            var fileExtension = Path.GetExtension(filePath);
            
            if (!fileExtension.Equals(".json") && !fileExtension.Equals(".csv"))
                throw new ArgumentException("Input file must be 'json' or 'csv'");

            _filePath = filePath;
        }

        public string GetFilePath()
        {
            return _filePath;
        }

        public object GetFileName()
        {
            return Path.GetFileNameWithoutExtension(_filePath);
        }

        public object GetFileExtension()
        {
            return Path.GetExtension(_filePath);
        }
    }
}
