using DepartmentOfCommerceProject.Infrastructure.BusinessObjects.DatabaseObjects;
using DepartmentOfCommerceProject.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class TestDatabaseManagerClass
    {
        [TestMethod]
        public void TestDataDownloading()
        {
            AccountTypesRepository repo = AccountTypesRepository.Instance;
            DatabaseManager manager = DatabaseManager.Instance;
            manager.GetData<AccountType, AccountTypesRepository>(repo);

            var data = repo.Data.Select().ToList();
            var checkData = new List<string>();

            for(int i = 0; i < checkData.Count; ++i)
            {
                Assert.AreEqual(checkData[i], data[i].TypeName);
            }
        }
    }
}
