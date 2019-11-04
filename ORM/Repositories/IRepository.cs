using ORM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Repositories
{
    public interface IRepository<T> where T : DatabaseObject, new()
    {
        DatabaseData<T> Data { get; set; }
    }
}
