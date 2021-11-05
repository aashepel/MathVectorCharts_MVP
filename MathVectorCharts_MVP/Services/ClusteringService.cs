using Clustering;
using LinearAlgebra;
using MathVectorCharts_MVP.Tools.Parsers;
using MathVectorCharts_MVP.Tools.Parsers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Services
{
    /// <summary>
    /// Список алгоритмов кластеризации
    /// </summary>
    public enum ClusteringAlgorithmType
    {
        Kmeans = 0,
        KmeansPP = 1
    }

    /// <summary>
    /// Сервис кластеризации
    /// </summary>
    public class ClusteringService : IClusteringService
    {
        /// <summary>
        /// Метод для получения информации о кластерах (центроидах и остальных точках)
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="clusteringAlgorithmType">Алгоритм кластеризации</param>
        /// <param name="countClusters">Количество кластеров</param>
        /// <returns></returns>
        /// <exception cref="Exceptions.UnknowClusteringAlgorithm">Бросеаем исключение, если алгоритм кластеризации еще не определен в программе</exception>
        public PointClusters LoadPointClustering(string filePath, ClusteringAlgorithmType clusteringAlgorithmType, int countClusters)
        {
            List<MathVector> rawData = LoadData(filePath); // Загружаем "сырые данные"
            IClusterer clusterer = null; // Создаем интерфейс кластеризации
            // В зависимости от алгоритма кластеризации присваиваем интерфейсу нужный класс кластеризации
            switch (clusteringAlgorithmType)
            {
                case ClusteringAlgorithmType.Kmeans:
                    clusterer = new KmeansClusterer(rawData, countClusters);
                    break;
                default:
                    throw new Exceptions.UnknowClusteringAlgorithm(); // Если ни один из кейсов не сработал программа заходит в блок default, где бросается исключение
            }
            return clusterer.Calculate(); // При помощи общего интерфейса для всех алгоритмов кластеризации вызываем метод Calculate
        }

        /// <summary>
        /// Метод для загрузки данных (дата-сета)
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Список мат. векторов</returns>
        private List<MathVector> LoadData(string filePath)
        {
            IParser<MathVector> parser = new MatrixValuesParser(filePath);
            return parser.Records;
        }
    }
}
