using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public class PointInfo
    {
        public int Id { get; set; }
        public int ClusterId { get; set; } = -1;
        public MathVector Point { get; set; }
    }
    public class KmeansClusterer : IClusterer
    {
        private List<Cluster> _clusters = new List<Cluster>();
        private List<MathVector> _rawData;
        private List<PointInfo> _points;
        private int _countClusters;
        public KmeansClusterer(List<MathVector> rawData, int countClusters)
        {
            _countClusters = countClusters;
            _rawData = new List<MathVector>(rawData.Select(x => new MathVector(x)));
            InitPoints();
        }

        public IEnumerable<Cluster> Clusters
        {
            get { return _clusters; }
        }

        public PointClusters KMeans
        {
            get
            {
                return CalculateKMeans();
            }
        }

        private bool Assign()
        {
            bool changed = false;
            foreach (var pointInfo in _points)
            {
                Cluster newCluster = DetermineClusterMembership(pointInfo.Point);
                if (newCluster.Id != pointInfo.Id)
                {
                    changed = true;
                    pointInfo.Id = newCluster.Id;
                }
            }
            return changed;
        }

        private PointClusters CalculateKMeans()
        {
            InitClusters();
            bool changed = true;
            int cnt = 0;
            while (changed == true)
            {
                cnt++;
                changed = Assign();
                UpdateMeans();
                UpdateCentroids();
            }

            _points = _points.OrderBy(p => p.Id).ThenBy(p => p.Point[0]).ThenBy(p => p.Point[1]).ToList();

            PointClusters pointClusters = new PointClusters();

            for (int i = 0; i < _clusters.Count; i++)
            {
                pointClusters.PC.Add(_clusters[i].ClusterCenter as MathVector, _points.Where(p => p.Id == i).Select(p => p.Point).ToList());
            }
            return pointClusters;
        }

        private void UpdateMeans()
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

        private IMathVector MeanVector(int clusterId)
        {
            List<PointInfo> pointsOfCluster = _points.Where(p => p.Id == clusterId).ToList();
            IMathVector meanVector = new MathVector(pointsOfCluster[0].Point);
            for (int i = 1; i < pointsOfCluster.Count; i++)
            {
                meanVector = (meanVector as MathVector) + pointsOfCluster[i].Point;
            }
            meanVector = (meanVector as MathVector) / pointsOfCluster.Count;
            return meanVector;
        }
        private IMathVector Centroid(int clusterId)
        {
            List<PointInfo> objectsOfCluster = _points.Where(p => p.Id == clusterId).ToList();
            IMathVector clusterCenter = new MathVector(objectsOfCluster[0].Point);
            double minDistance = clusterCenter.CalcDistance(_clusters[clusterId].MeanVector);
            foreach (MathVector vector in objectsOfCluster.Select(p => p.Point))
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

        private void InitPoints()
        {
            _points = new List<PointInfo>();
            int index = 0;
            foreach (var point in _rawData)
            {
                _points.Add(new PointInfo { Id = index++, Point = point });
            }
        }

        public Cluster DetermineClusterMembership(IMathVector vector)
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

        public void InitClusters()
        {
            InitCentroids();
        }

        private void InitCentroids()
        {
            Random random = new Random(0);
            List<int> clustersCentersIndexes = new List<int>();
            //MathVector firstCentroid = FirstCentroid();
            //int index = random.Next(0, _data.Count);
            int index = _points.IndexOf(_points.OrderBy(p => p.Point[0]).ThenBy(p => p.Point[1]).ElementAt(_points.Count / 2));
            MathVector firstCentroid = _points[index].Point;
            //int indexFirstCentroid = _data.Select(p => p.Object).ToList().IndexOf(firstCentroid);
            _clusters.Add(new Cluster(firstCentroid, 0));
            //clustersCentersIndexes.Add(indexFirstCentroid);
            clustersCentersIndexes.Add(index);



            while (clustersCentersIndexes.Count != _countClusters)
            {
                double minDistance = double.MinValue;
                MathVector maxDistanceVector = null;
                int maxIndexVector = -1;
                for (int i = 0; i < _points.Select(p => p.Point).Count(); i++)
                {
                    if (!clustersCentersIndexes.Contains(i))
                    {
                        double minCurrentDistance = 0;
                        List<double> distances = new List<double>();
                        foreach (var cluster in _clusters)
                        {
                            double currentDistances = _points[i].Point.CalcDistance(cluster.ClusterCenter);
                            distances.Add(currentDistances);
                        }
                        minCurrentDistance = distances.Min();
                        if (minCurrentDistance > minDistance)
                        {
                            minDistance = minCurrentDistance;
                            maxDistanceVector = _points[i].Point;
                            maxIndexVector = i;
                        }
                    }
                }
                clustersCentersIndexes.Add(maxIndexVector);
                _clusters.Add(new Cluster(maxDistanceVector, _clusters.Count));
            }
        }
    }
}
