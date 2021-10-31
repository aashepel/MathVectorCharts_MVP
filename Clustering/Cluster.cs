using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public class Cluster
    {
        public Cluster(IMathVector clusterCenter, int id)
        {
            Id = id;
            ClusterCenter = clusterCenter;
        }

        public int Id { get; }
        public IMathVector ClusterCenter { get; set; }
        public IMathVector MeanVector { get; set; }
    }
}
