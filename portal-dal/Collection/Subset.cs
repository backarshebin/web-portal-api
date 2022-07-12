using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portal_dal.Collection
{
    public class Subset<T>
    {
        // represents the result of performing a database query which returns
        // a set of entities that is a subset of all entities in the database

        public List<T> Elements { get; protected set; }
        public int Offset { get; protected set; }
        public int Limit { get; protected set; }
        public int Total { get; protected set; }

        public Subset(
            List<T> elements,
            int offset,
            int limit,
            int total)
        {
            Elements = elements;
            Offset = offset;
            Limit = limit;
            Total = total;
        }
    }
}
