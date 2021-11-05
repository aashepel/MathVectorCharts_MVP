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
    /// <summary>
    /// Абстрактный generic парсер, реализующий интерфейс IParser
    /// </summary>
    /// <typeparam name="T">Объекты какого класса необходимо "парсить"</typeparam>
    public abstract class AbstractParser<T> : IParser<T>
    {
        protected List<T> _records; // Записи - список объектов класса T
        protected bool _successfullyParsed = false; // Успешно ли был "распарсен" файл по последнему пути (Если путь к файлу меняется - принимается значение false)
        protected List<string> _headers; // Заголовки (актуально для csv файлов. Возможно, пригодится для остальных типов)
        protected string _filePath; // Путь к файлу
        protected int _maxFileSize; // Максимальный размер файла для "парсинга" (по умолчанию 1 МБ)
        public AbstractParser(string filePath, int maxFileSize = 1024 * 1024)
        {
            _filePath = filePath;
            _maxFileSize = maxFileSize;
            // Если путь к файлу указан, сразу проверяем основные параметры файла
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

        /// <summary>
        /// Заголовки (актуально для csv файлов)
        /// </summary>
        public List<string> Headers
        {
            get
            {
                // Если файл не был "распарсен" или был "распарсен" неуспешно, пытаемся "распарсить" его
                if (!SuccessfullyParsed)
                {
                    Parse();
                }
                return _headers;
            }
        }

        /// <summary>
        /// Записи (объекты класса)
        /// </summary>
        public List<T> Records
        {
            get
            {
                // Если файл не был "распарсен" или был "распарсен" неуспешно, пытаемся "распарсить" его
                if (!SuccessfullyParsed)
                {
                    Parse();
                }
                return _records;
            }
        }
        
        /// <summary>
        /// Абстрактный метод Parse, реализуется в дочерних классах
        /// </summary>
        public abstract void Parse();

        /// <summary>
        /// Виртуальный метод Parse, может быть перегружен в дочерних классах
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public virtual void Parse(string filePath)
        {
            _filePath = filePath;
            ValidateParamsFile();
            Parse();
        }

        /// <summary>
        /// Метод для проверки размера файла
        /// </summary>
        /// <exception cref="ExceededAllowedFileLengthException">Бросаем исключение, если размер файла превышен</exception>
        private void ValidateSizeFile()
        {
            var fileInfo = new FileInfo(_filePath);
            if (fileInfo.Length > _maxFileSize)
            {
                throw new ExceededAllowedFileLengthException();
            }
        }

        /// <summary>
        /// Метод для проверки существования файла
        /// </summary>
        /// <exception cref="ExceededAllowedFileLengthException">Бросаем исключение, если файл не сущестует</exception>
        private void ValidateExistsFile()
        {
            var fileInfo = new FileInfo(_filePath);
            if (!fileInfo.Exists)
            {
                throw new NotExsistFileException();
            }
        }

        /// <summary>
        /// Метод для провекрки нужных параметров файла
        /// </summary>
        protected virtual void ValidateParamsFile()
        {
            ValidateSizeFile();
            ValidateExistsFile();
        }
    }
}
