using ORM.Objects;
using System;

namespace ORM.Repositories
{
    public interface IRepository<T> where T : DatabaseObject, new()
    {
        DatabaseData<T> Data { get; set; }
        bool NeedToDownload { get; set; }
    }
}
