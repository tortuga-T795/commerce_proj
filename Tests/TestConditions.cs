using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.Util;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class TestConditions
    {
        [TestMethod]
        public void TestDatabaseDataSelectCondition()
        {
            TestDatabaseObject obj = new TestDatabaseObject() { Id = 20 };
            var condition = new DatabaseDataSelectCondition<TestDatabaseObject>(obj.GetPublicProperty("Id"), obj.Id, ComparisonType.Equal);
            string strCondition = condition.GetCondition();

            Assert.AreEqual("TestId = 20", strCondition);
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

            Assert.AreEqual("TestId = 20 AND TestField = 15 AND TestField < 20", condition);
        }
    }
}
