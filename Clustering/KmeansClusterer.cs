using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public class KmeansClusterer
    {
        List<Cluster> _clusters;
        List<MathVector> _rawData;
        List<ObjectOfClustering<MathVector>> _data;
        int _countClusters;
        int _randomSeed;
        public KmeansClusterer(List<MathVector> rawData, int countClusters, int randomSeed)
        {
            _rawData = new List<MathVector>(rawData);
            _data = new List<ObjectOfClustering<MathVector>>(rawData.Count);
            _countClusters = countClusters;
            _clusters = new List<Cluster>(countClusters);
            _randomSeed = randomSeed;
        }

        public IEnumerable<Cluster> Clusters
        {
            get
            {
                return _clusters;
            }
        }
        public List<KeyValuePair<int, List<MathVector>>> RunClustering()
        {
            InitClusters();
            bool changed = true;
            int cnt = 0;
            UpdateMeans();
            UpdateCentroids();
            while (changed == true)
            {
                Console.WriteLine($"Iteration {cnt.ToString("N1", CultureInfo.InvariantCulture)}");
                cnt++;
                changed = Assign();
                UpdateMeans();
                UpdateCentroids();
            }

            _data = _data.OrderBy(p => p.Id).ThenBy(p => p.Object[0]).ThenBy(p => p.Object[1]).ToList();

            Console.WriteLine("\nClustering complete\n");
            Console.WriteLine("Clustering in internal format:\n");
            foreach (var obj in _data)
            {
                Console.Write($"{obj.Id} ");
            }
            Console.WriteLine("\n");
            List<KeyValuePair<int, List<MathVector>>> result = new List<KeyValuePair<int, List<MathVector>>>();
            foreach(var cluster in _clusters)
            {
                List<MathVector> objectsOfCluster = new List<MathVector>(_data.Where(p => p.Id == cluster.Id).Select(p => new MathVector(p.Object)));
                result.Add(new KeyValuePair<int, List<MathVector>>(cluster.Id, objectsOfCluster));
            }
            return result;
        }

        private Cluster DetermineClusterMembership(IMathVector vector)
        {
            double minDistance = vector.CalcDistance(_clusters[0].ClusterCenter);
            int indexCluster = 0;
            for (int i = 1; i < _clusters.Count; i++)
            {
                double distance = vector.CalcDistance(_clusters[i].ClusterCenter);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    indexCluster = i;
                }
            }
            return _clusters[indexCluster];
        }

        private void InitClusters()
        {
            for (int i = 0; i < _countClusters; i++)
            {
                _data.Add(new ObjectOfClustering<MathVector> { Id = i, Object = new MathVector(_rawData[i]) });
                _clusters.Add(new Cluster(_data[i].Object, i));
            }
            Random random = new Random(_randomSeed);
            for (int i = _countClusters; i < _rawData.Count(); i++)
            {
                int clusterIndex = random.Next(0, _clusters.Count);
                _data.Add(new ObjectOfClustering<MathVector> { Id = clusterIndex, Object = new MathVector(_rawData[i]) });
            }
        }

        private bool Assign()
        {
            bool changed = false;
            foreach (var objectOfClustering in _data)
            {
                Cluster newCluster = DetermineClusterMembership(objectOfClustering.Object);
                if (newCluster.Id != objectOfClustering.Id)
                {
                    changed = true;
                    objectOfClustering.Id = newCluster.Id;
                }
            }
            return changed;
        }

        private IMathVector MeanVector(int clusterId)
        {
            List<ObjectOfClustering<MathVector>> objectsOfCluster = _data.Where(p => p.Id == clusterId).ToList();
            IMathVector meanVector = new MathVector(objectsOfCluster[0].Object);
            for (int i = 1; i < objectsOfCluster.Count; i++)
            {
                meanVector = (meanVector as MathVector) + objectsOfCluster[i].Object;
            }
            meanVector = (meanVector as MathVector) / objectsOfCluster.Count;
            return meanVector;
        }
        private IMathVector Centroid(int clusterId)
        {
            List<ObjectOfClustering<MathVector>> objectsOfCluster = _data.Where(p => p.Id == clusterId).ToList();
            IMathVector clusterCenter = new MathVector(objectsOfCluster[0].Object);
            double minDistance = clusterCenter.CalcDistance(_clusters[clusterId].MeanVector);
            foreach (MathVector vector in objectsOfCluster.Select(p => p.Object))
            {
                double currDistance = vector.CalcDistance(_clusters[clusterId].MeanVector);
                if (currDistance < minDistance)
                {
                    clusterCenter = vector;
                    minDistance = currDistance;
                }
            }
            return clusterCenter;
        }
        public void UpdateMeans()
        {
            foreach (var cluster in _clusters)
            {
                cluster.MeanVector = MeanVector(cluster.Id);
            }
        }

        public void UpdateCentroids()
        {
            foreach (var cluster in _clusters)
            {
                cluster.ClusterCenter = Centroid(cluster.Id);
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach (var cluster in _clusters)
            {
                var objectsOfCluster = _data.Where(p => p.Id == cluster.Id).ToList();

                result += $"-------------------------Cluster {cluster.Id}-------------------------\n";
                result += $"\nCluster center: {cluster.ClusterCenter}\n\n";
                foreach (var obj in objectsOfCluster)
                {
                    double distanceToThisCenter = Math.Round(obj.Object.CalcDistance(cluster.ClusterCenter), 2);
                    result += $"{obj.Object}";
                    //result += "\n";
                    //foreach (var clust in _clusters)
                    //{
                    //    double currentDistance = Math.Round(obj.Object.CalcDistance(clust.ClusterCenter), 2);
                    //    result += $"\tDistance to Cluster {clust.Id}: {currentDistance}.\t\tМеньше: {currentDistance < distanceToThisCenter}\n";
                    //}
                    result += "\n";
                }
                result += "\n";
            }
            return result;
        }
    }
}
