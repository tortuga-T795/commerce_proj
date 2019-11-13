using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Attributes;
using ORM.Util;
using ORM.Repositories;
using ORM.Objects;
using System.Data;
using DepartmentOfCommerceProject.Repositories;
using DepartmentOfCommerceProject.Infrastructure.BusinessObjects.DatabaseObjects;

namespace Tests
{
    public class TestRepository : IRepository<TestDatabaseObject>
    {
        #region Singleton
        static TestRepository()
        {
            instance = new TestRepository();
        }

        private static readonly object lockObj = new object();
        private static TestRepository instance;
        public static TestRepository Instance
        {
            get
            {
                lock (lockObj)
                {
                    if (instance == null)
                    {
                        instance = new TestRepository();
                    }
                    return instance;
                }
            }
        }

        private TestRepository()
        { }
        #endregion

        public DatabaseData<TestDatabaseObject> Data { get; set; }
        public bool NeedToDownload { get; set; }
    }

    [TestClass]
    public class TestForeignKeyAttribute
    {
        [TestMethod]
        public void TestGetRepositoryDataMethod()
        {
            //ForeignKeyAttribute attribute =
            //    new ForeignKeyAttribute(typeof(TestRepository), typeof(TestDatabaseObject), "Id", "TestProp");

            //DataSet set = new DataSet();
            //DataTable table = new DataTable("testTable");

            //TestRepository.Instance.Data = new DatabaseData<TestDatabaseObject>(new DataSet());
        }
    }
}
