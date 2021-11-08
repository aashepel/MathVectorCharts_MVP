//using LinearAlgebra;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;

//namespace Clustering
//{
//    public struct PointDetails
//    {
//        public int Id { get; set; }
//        public int IdCluster { get; set; }
//        public MathVector Point { get; set; }
//        public List<Double> Weights { get; set; }
//        public double SumDistances { get; set; }
//        public double MinDistance { get; set; }
//        public override string ToString()
//        {
//            return $"{IdCluster} - {Point}";
//        }
//        public static PointDetails GetAllDetails(List<MathVector> allPoints, MathVector seedPoint, PointDetails pd)
//        {
//            double[] Weights = new double[allPoints.Count];
//            double minD = double.MaxValue;
//            double Sum = 0d;
//            int i = 0;

//            foreach (MathVector p in allPoints)
//            {
//                if (p == seedPoint) //Delta is 0
//                    continue;

//                Weights[i] = p.CalcDistance(seedPoint);
//                Sum += Weights[i];
//                if (Weights[i] < minD)
//                    minD = Weights[i];
//                i++;
//            }

//            pd.Point = seedPoint;
//            pd.Weights = Weights.ToList();
//            pd.SumDistances = Sum;
//            pd.MinDistance = minD;

//            return pd;
//        }
//    }
//    public class KmeansPlusPlusClusterer : IClusterer
//    {
//        private List<MathVector> _allPoints;
//        private int _countClusters;
//        private const int maxCycle = 10000;
//        private int cntCycle = 0;

//        public IEnumerable<Cluster> Clusters => throw new NotImplementedException();

//        public KmeansPlusPlusClusterer(List<MathVector> rawData, int countClusters)
//        {
//            _allPoints = new List<MathVector>(rawData.Select(p => new MathVector(p)).ToList());
//            _countClusters = countClusters;
//        }
//        public PointClusters GetKMeansPP()
//        {
//            return CalculateKMeansPP(_allPoints, _countClusters);
//        }
//        private PointClusters CalculateKMeansPP(List<MathVector> allPoints, int k)
//        {
//            //1. Preprocess KMeans (obtain optimized seed points)
//            List<MathVector> seedPoints = GetSeedPoints(allPoints, k);

//            //2. Regular KMeans algorithm
//            //PointClusters resultado = GetKMeans(allPoints, seedPoints, k).Value;
//            while (true)
//            {
//                var result = GetKMeans(allPoints, seedPoints, k);
//                if (result.Key || cntCycle >= maxCycle)
//                {
//                    return result.Value;
//                }
//                cntCycle++;
//            }

//            return null;
//        }

//        private KeyValuePair<bool, PointClusters> GetKMeans(List<MathVector> allPoints, List<MathVector> seedPoints, int k)
//        {
//            PointClusters cluster = new PointClusters();
//            double[] Distances = new double[k];
//            double minD = double.MaxValue;
//            List<MathVector> sameDPoint = new List<MathVector>();
//            bool exit = true;

//            //Cycle thru all points in ensemble and assign to nearest centre 
//            foreach (MathVector p in allPoints)
//            {
//                foreach (MathVector sPoint in seedPoints)
//                {
//                    double dist = p.CalcDistance(sPoint);
//                    if (dist < minD)
//                    {
//                        sameDPoint.Clear();
//                        minD = dist;
//                        sameDPoint.Add(sPoint);
//                    }
//                    if (dist == minD)
//                    {
//                        if (!sameDPoint.Contains(sPoint))
//                            sameDPoint.Add(sPoint);
//                    }
//                }

//                //Extract nearest central point. 
//                MathVector keyPoint;
//                if (sameDPoint.Count > 1)
//                {
//                    int index = GetRandNumCrypto(0, sameDPoint.Count);
//                    keyPoint = sameDPoint[index];
//                }
//                else
//                    keyPoint = sameDPoint[0];

//                //Assign ensemble point to correct central point cluster
//                if (!cluster.PC.ContainsKey(keyPoint))  //New
//                {
//                    List<MathVector> newCluster = new List<MathVector>();
//                    newCluster.Add(p);
//                    cluster.PC.Add(keyPoint, newCluster);
//                }
//                else
//                {   //Existing cluster centre   
//                    cluster.PC[keyPoint].Add(p);
//                }

//                //Reset
//                sameDPoint.Clear();
//                minD = double.MaxValue;
//            }

//            //Bulletproof check - it it come out of the wash incorrect then re-seed.
//            if (cluster.PC.Count != k)
//            {
//                cluster.PC.Clear();
//                seedPoints = GetSeedPoints(allPoints, k);
//            }

//            List<MathVector> newSeeds = GetCentroid(cluster);

//            //Determine exit
//            foreach (MathVector newSeed in newSeeds)
//            {
//                if (!cluster.PC.ContainsKey(newSeed))
//                    exit = false;
//            }

//            cntCycle++;
//            return new KeyValuePair<bool, PointClusters>(exit, cluster);
//            //if (exit || cntCycle >= maxCycle)
//            //    return cluster;
//            //else
//            //    return GetKMeans(allPoints, newSeeds, k);
//        }

//        /// <summary>
//        /// Get the centroid of a set of points
//        /// cf. http://en.wikipedia.org/wiki/Centroid
//        /// Consider also: Metoid cf. http://en.wikipedia.org/wiki/Medoids
//        /// </summary>
//        /// <param name="pcs"></param>
//        /// <returns></returns>
//        private List<MathVector> GetCentroid(PointClusters pcs)
//        {
//            List<MathVector> newSeeds = new List<MathVector>(pcs.PC.Count);
            
//            foreach (List<MathVector> cluster in pcs.PC.Values)
//            {
//                MathVector sum = new MathVector(2);
//                foreach (MathVector p in cluster)
//                {
//                    sum = (sum + p) as MathVector;
//                }
//                sum = (sum / cluster.Count) as MathVector;
//                newSeeds.Add(new MathVector(sum));
//            }

//            return newSeeds;
//        }

//        private List<MathVector> GetSeedPoints(List<MathVector> allPoints, int countClusters)
//        {
//            List<MathVector> seedPoints = new List<MathVector>(countClusters);
//            PointDetails pd;
//            List<PointDetails> pds = new List<PointDetails>();
//            int index = 0;

//            //1. Choose 1 random point as first seed
//            int firstIndex = GetRandNorm(0, allPoints.Count);
//            MathVector FirstPoint = allPoints[firstIndex];
//            seedPoints.Add(FirstPoint);

//            for (int i = 0; i < countClusters - 1; i++)
//            {
//                if (seedPoints.Count >= 2)
//                {
//                    //Get point with min distance
//                    PointDetails minpd = GetMinDPD(pds);
//                    index = GetWeightedProbDist(minpd.Weights, minpd.SumDistances);
//                    MathVector SubsequentPoint = allPoints[index];
//                    seedPoints.Add(SubsequentPoint);

//                    pd = new PointDetails();
//                    pd = PointDetails.GetAllDetails(allPoints, SubsequentPoint, pd);
//                    pds.Add(pd);
//                }
//                else
//                {
//                    pd = new PointDetails();
//                    pd = PointDetails.GetAllDetails(allPoints, FirstPoint, pd);
//                    pds.Add(pd);
//                    index = GetWeightedProbDist(pd.Weights, pd.SumDistances);
//                    MathVector SecondPoint = allPoints[index];
//                    seedPoints.Add(SecondPoint);

//                    pd = new PointDetails();
//                    pd = PointDetails.GetAllDetails(allPoints, SecondPoint, pd);
//                    pds.Add(pd);
//                }
//            }

//            return seedPoints;
//        }

//        //Gets a pseudo random number (of normal quality) in range: [0, 1)
//        private double GetRandNorm()
//        {
//            Random seed = new Random();
//            return seed.NextDouble();
//        }

//        //Gets a pseudo random number (of normal quality) in range: [min, max)
//        private int GetRandNorm(int min, int max)
//        {
//            Random seed = new Random();
//            return seed.Next(min, max);
//        }
//        /// <summary>
//        /// Very simple weighted probability distribution. NB: No ranking involved.
//        /// Returns a random index proportional to to D(x)^2
//        /// </summary>
//        /// <param name="w">Weights</param>
//        /// <param name="s">Sum total of weights</param>
//        /// <returns>Index</returns>
//        private int GetWeightedProbDist(List<double> w, double s)
//        {
//            double p = GetRandNumCrypto();
//            double q = 0d;
//            int i = -1;

//            while (q < p)
//            {
//                i++;
//                q += (w[i] / s);
//            }
//            return i;
//        }
//        //Gets min distance from set of PointDistance objects. If similar then chooses random item.
//        private PointDetails GetMinDPD(List<PointDetails> pds)
//        {
//            double minValue = double.MaxValue;
//            List<PointDetails> sameDistValues = new List<PointDetails>();

//            foreach (PointDetails pd in pds)
//            {
//                if (pd.MinDistance < minValue)
//                {
//                    sameDistValues.Clear();
//                    minValue = pd.MinDistance;
//                    sameDistValues.Add(pd);
//                }
//                if (pd.MinDistance == minValue)
//                {
//                    if (!sameDistValues.Contains(pd))
//                        sameDistValues.Add(pd);
//                }
//            }

//            if (sameDistValues.Count > 1)
//                return sameDistValues[GetRandNumCrypto(0, sameDistValues.Count)];
//            else
//                return sameDistValues[0];
//        }

//        private int GetRandNumCrypto(int min, int max)
//        {
//            byte[] salt = new byte[8];
//            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
//            rng.GetBytes(salt);
//            return (int)((double)BitConverter.ToUInt64(salt, 0) / UInt64.MaxValue * (max - min)) + min;
//        }

//        private double GetRandNumCrypto()
//        {
//            byte[] salt = new byte[8];
//            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
//            rng.GetBytes(salt);
//            return (double)BitConverter.ToUInt64(salt, 0) / UInt64.MaxValue;
//        }

//        public void InitClusters()
//        {
//            throw new NotImplementedException();
//        }

//        public Cluster DetermineClusterMembership(IMathVector vector)
//        {
//            throw new NotImplementedException();
//        }

//        public PointClusters Calculate()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
