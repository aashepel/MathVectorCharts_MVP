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
    public enum ClusteringAlgorithmType
    {
        Kmeans = 0,
        KmeansPP = 1
    }
    public class ClusteringService : IClusteringService
    {
        public PointClusters LoadPointClustering(string filePath, ClusteringAlgorithmType clusteringAlgorithmType, int countClusters)
        {
            List<MathVector> rawData = LoadData(filePath);
            IClusterer clusterer = null;
            switch (clusteringAlgorithmType)
            {
                case ClusteringAlgorithmType.Kmeans:
                    clusterer = new KmeansClusterer(rawData, countClusters);
                    break;
                default:
                    throw new Exceptions.UnknowClusteringAlgorithm();
            }
            return clusterer.Calculate();
        }

        private List<MathVector> LoadData(string filePath)
        {
            IParser<MathVector> parser = new MatrixValuesParser(filePath);
            return parser.Records;
        }
    }
}
