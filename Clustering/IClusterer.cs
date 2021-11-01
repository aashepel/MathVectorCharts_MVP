using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public interface IClusterer
    {
        void InitClusters();
        IEnumerable<Cluster> Clusters { get; }
        Cluster DetermineClusterMembership(IMathVector vector);
        PointClusters Calculate();
    }
}
