using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Objects;
using ORM.Repositories;
using DepartmentOfCommerceProject.Infrastructure.BusinessObjects.DatabaseObjects;

namespace DepartmentOfCommerceProject.Repositories
{
    public class AccountTypesRepository : IRepository<AccountType>
    {
        #region Singleton
        private static readonly object lockObj = new object();
        private static AccountTypesRepository instance;
        public static AccountTypesRepository Instance
        {
            get
            {
                lock(lockObj)
                {
                    if (instance == null)
                    {
                        instance = new AccountTypesRepository();
                    }
                    return instance;
                }
            }
        }
        #endregion

        public DatabaseData<AccountType> Data { get; set; }

        private AccountTypesRepository()
        { }
    }
}
