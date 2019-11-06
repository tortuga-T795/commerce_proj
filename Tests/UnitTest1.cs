using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Util;
using ORM.Objects;
using ORM.Attributes;
using System.Reflection;

namespace Tests
{
    class TestDatabaseObject : DatabaseObject
    {
        [FieldName("TestId")]
        public int Id { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDatabaseDataSelectCondition()
        {
            TestDatabaseObject obj = new TestDatabaseObject() { Id = 20 };
            var condition = new DatabaseDataSelectCondition<TestDatabaseObject>(obj.GetPublicProperty("Id"), 30, ComparisonType.Equal);
            string strCondition = condition.GetCondition();

            Assert.AreEqual(strCondition, "TestId = 30");
        }
    }
}
