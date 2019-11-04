using ORM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : DatabaseObject, new()
    {
        public DatabaseData<T> Data { get; set; }

        #region Singleton
        /*
         * Singleton implementation with an attempted thread-safety using double-check locking
         * @source: http://csharpindepth.com/articles/general/singleton.aspx
         */
        private static BaseRepository<T> instance;
        private static readonly object lockObj = new object();
        public static BaseRepository<T> Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new BaseRepository<T>();
                    }
                    return instance;
                }
            }
        }
        #endregion

        private BaseRepository()
        { }
    }
}
