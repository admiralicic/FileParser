﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileParser.Library
{
    public class InputFile
    {
        private string _filePath;
        private static object _locker = new object();
        private StreamReader _inputStream = null;

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

        public string GetFileName()
        {
            return Path.GetFileNameWithoutExtension(_filePath);
        }

        public string GetFileExtension()
        {
            return Path.GetExtension(_filePath);
        }

        public string ReadLine()
        {
            if(_inputStream == null)
                _inputStream = new StreamReader(_filePath);

            var lineText = _inputStream.ReadLine();

            if (lineText != null)
            {
                var fileLine = new FileLine(lineText,
                this.GetFileName(), this.GetFileExtension());

                var normalizedLine = fileLine.GetNormalized();

                return normalizedLine;
            }
            else
            {
                return null;
            }

            
        }
    }
}
