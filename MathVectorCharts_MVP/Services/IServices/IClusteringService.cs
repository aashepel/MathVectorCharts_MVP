using Clustering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathVectorCharts_MVP.Services
{
    public interface IClusteringService
    {
        PointClusters LoadPointClustering(string filePath, ClusteringAlgorithmType clusteringAlgorithmType, int countClusters);
    }
}
