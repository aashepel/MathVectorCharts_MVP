using Clustering;
using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ClusteringConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"C:\Users\Alexandr\Documents\k-means_DataSet.txt";
            List<string> linesFile = File.ReadAllLines(filePath).ToList();
            List<MathVector> points = new List<MathVector>();
            foreach (string line in linesFile)
            {
                IEnumerable<double> values = line.Split(' ').Where(p => p.Length != 0).Select(p => double.Parse(p));
                points.Add(new MathVector(values.ToArray()));
            }
            const int countClusters = 10;
            KmeansClusterer clusterer = new KmeansClusterer(points, countClusters, 1000);
            var clusteredObjects = clusterer.RunClustering();
            Console.WriteLine(clusterer);
            Console.ReadKey();
        }

    }
}
