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
    class FileLineTests
    {
        private string _inputFileName;
        private InputFile _inputFileCsv;
        private InputFile _inputFileJson;
        private string _inputTextCSV;
        private string _inputTextJson;
        private string _csvExtension;
        private string _jsonExtension;

        [SetUp]
        public void SetUp()
        {
            _inputFileCsv = new InputFile(@"C:/Tests/inputA.csv");
            _inputFileJson = new InputFile(@"C:/Tests/inputB.json");
            _inputTextCSV = @"""cfd001"",4000,132.50";
            _inputTextJson = @"{ ""id"": ""afa072"", ""quantity"": 3000, ""price"": 22.15 }";
            _inputFileName = "inputA";
            _csvExtension = ".csv";
            _jsonExtension = ".json";
        }

        [Test]
        public void CSVLineReturnsNormalizedText()
        {
            var line = new FileLine(_inputTextCSV, _inputFileName, _csvExtension);

            var expected = @"""inputA"",""cfd001"",4000,132.50";

            var actual = line.GetNormalized();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void JsonLineReturnsNormalizedText()
        {
            var line = new FileLine(_inputTextJson, _inputFileName, _jsonExtension);

            var expected = @"""inputA"",""afa072"",3000,22.15";

            var actual = line.GetNormalized();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void NonJsonAndNonCsvLineReturnsNullDuringNormalization()
        {
            var line = new FileLine(_inputTextJson, _inputFileName, ".doc");

            string expected = null;

            var actual = line.GetNormalized();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
