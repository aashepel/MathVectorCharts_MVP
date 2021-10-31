using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clustering
{
    public class ObjectOfClustering<T> where T : class
    {
        public int Id { get; set; }
        public T Object { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Object}";
        }
    }
}
