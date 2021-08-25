using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yamcs.Shared.Models
{
    public class APIEntityResponse<TEntity> where TEntity : class
    {
        public TEntity Data { get; set; }
    }
    public class APIListOfEntityResponse<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Data { get; set; }
    }
}
