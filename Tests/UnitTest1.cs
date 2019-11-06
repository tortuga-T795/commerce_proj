using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Util;
using ORM.Objects;
using ORM.Attributes;
using System.Reflection;
using System.Collections.Generic;

namespace Tests
{
    class TestDatabaseObject : DatabaseObject
    {
        [FieldName("TestId")]
        public int Id { get; set; }

        [FieldName("TestField")]
        public int TestProp { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDatabaseDataSelectCondition()
        {
            TestDatabaseObject obj = new TestDatabaseObject() { Id = 20 };
            var condition = new DatabaseDataSelectCondition<TestDatabaseObject>(obj.GetPublicProperty("Id"), obj.Id, ComparisonType.Equal);
            string strCondition = condition.GetCondition();

            Assert.AreEqual(strCondition, "TestId = 20");
        }

        [TestMethod]
        public void TestDatabaseDataSelectConditionsCollection()
        {
            TestDatabaseObject obj = new TestDatabaseObject() { Id = 20, TestProp = 15 };
            var conditions = new List<DatabaseDataSelectCondition<TestDatabaseObject>>();
            conditions.Add(new DatabaseDataSelectCondition<TestDatabaseObject>(obj.GetPublicProperty("Id"), obj.Id, ComparisonType.Equal));
            conditions.Add(new DatabaseDataSelectCondition<TestDatabaseObject>(obj.GetPublicProperty("TestProp"), obj.TestProp, ComparisonType.Equal));
            conditions.Add(new DatabaseDataSelectCondition<TestDatabaseObject>(obj.GetPublicProperty("TestProp"), 20, ComparisonType.Less));
            var operators = new List<LogicOperator>() { LogicOperator.And, LogicOperator.And };

            var condCollection = new DatabaseDataSelectConditionsCollection<TestDatabaseObject>(conditions, operators);
            string condition = condCollection.GetCondition();

            Assert.AreEqual(condition, "TestId = 20 AND TestField = 15 AND TestField < 20");
        }
    }
}
