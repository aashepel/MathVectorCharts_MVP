using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    interface IClusterer
    {
        void InitClusters();
        IEnumerable<Cluster> Clusters { get; }
        Cluster DetermineClusterMembership(IMathVector vector);
    }
}
