using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Tools.Parsers
{
    public abstract class AbstractParser<T> : IParser<T> where T : class, new()
    {
        protected List<T> _records;
        protected bool _successfullyParsed = false;
        protected List<string> _headers;
        protected string _filePath;
        public AbstractParser(string filePath)
        {
            FilePath = filePath;
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
            Parse();
        }
    }
}
