using MathVectorCharts_MVP.Exceptions;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Tools.Parsers
{
    public abstract class AbstractParser<T> : IParser<T>
    {
        protected List<T> _records;
        protected bool _successfullyParsed = false;
        protected List<string> _headers;
        protected string _filePath;
        protected int _maxFileSize;
        public AbstractParser(string filePath, int maxFileSize = 1024 * 1024)
        {
            _filePath = filePath;
            _maxFileSize = maxFileSize;
            if (filePath != null)
            {
                ValidateParamsFile();
            }
        }
        public bool SuccessfullyParsed
        {
            get { return _successfullyParsed; }
        }
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _successfullyParsed = false;
                _filePath = value;                
            }
        }
        public List<string> Headers
        {
            get
            {
                if (!SuccessfullyParsed)
                {
                    Parse();
                }
                return _headers;
            }
        }
        public List<T> Records
        {
            get
            {
                if (!SuccessfullyParsed)
                {
                    Parse();
                }
                return _records;
            }
        }
        public abstract void Parse();
        public virtual void Parse(string filePath)
        {
            _filePath = filePath;
            ValidateParamsFile();
            Parse();
        }
        private void ValidateSizeFile()
        {
            var fileInfo = new FileInfo(_filePath);
            if (!fileInfo.Exists)
            {
                throw new ExceededAllowedFileLengthException();
            }
        }
        private void ValidateExistsFile()
        {
            var fileInfo = new FileInfo(_filePath);
            if (fileInfo.Length > _maxFileSize)
            {
                throw new ExceededAllowedFileLengthException();
            }

        }
        protected virtual void ValidateParamsFile()
        {
            ValidateSizeFile();
            ValidateExistsFile();
        }
    }
}
