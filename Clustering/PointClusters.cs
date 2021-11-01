using LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public class PointClusters
    {
        private Dictionary<MathVector, List<MathVector>> _pc = new Dictionary<MathVector, List<MathVector>>();
        public Dictionary<MathVector, List<MathVector>> PC
        {
            get { return _pc; }
            set { _pc = value; }
        }
    }
}
