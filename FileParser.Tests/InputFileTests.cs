using FileParser.Library;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Tests
{
    [TestFixture]
    public class InputFileTests
    {
        private string _path;
        private string _fileNameCsv;
        private string _fileNameJson;
        private string _validFilePathCsv;
        private string _validFilePathJson;
        private string _invalidFilePath;

        [SetUp]
        public void Setup()
        {
            _fileNameCsv = "inputA.csv";
            _fileNameJson = "inputB.json";
            _path = @"C:/Test/";
            _validFilePathCsv = _path + _fileNameCsv;
            _validFilePathJson = _path + _fileNameJson;
            _invalidFilePath = @"C:Test/inputA";
        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void InputFileShoulHaveValidCSVFilePath()
        {
            var inputFile = new InputFile(_validFilePathCsv);

            var actual = inputFile.GetFilePath();

            Assert.That(actual, Is.EqualTo(@"C:/Test/inputA.csv"));
        }

        [Test]
        public void InputFileShoulHaveValidJSONFilePath()
        {
            var inputFile = new InputFile(_validFilePathJson);

            var actual = inputFile.GetFilePath();

            Assert.That(actual, Is.EqualTo(@"C:/Test/inputB.json"));
        }

        [Test]
        public void InputFileSouldThrowExceptionIfNotAValidPath()
        {
            Assert.That(delegate { new InputFile(_invalidFilePath); }, 
                Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void InputFileShouldThrowExceptionIfFilePathIsNull()
        {
            Assert.That(delegate { new InputFile(""); }, 
                Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void InputFileMustHaveValidFileName()
        {
            var inputFile = new InputFile(_validFilePathCsv);

            var expected = "inputA";

            var actual = inputFile.GetFileName();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void InputFileMustHaveValidCSVExtension()
        {
            var inputFile = new InputFile(_validFilePathCsv);
            
            var expected = ".csv";

            var actual = inputFile.GetFileExtension();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void InputFileMustHaveValidJsonExtension()
        {
            var inputFile = new InputFile(_validFilePathJson);

            var expected = ".json";

            var actual = inputFile.GetFileExtension();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

   
}
