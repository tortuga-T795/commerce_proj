using System;
using ORM.Objects;
using ORM.Attributes;

namespace DepartmentOfCommerceProject.Infrastructure.BusinessObjects.DatabaseObjects
{
    [TableName("AccountTypes")]
    [ReadOnlyTable]
    public class AccountType : DatabaseObject
    {
        [PrimaryKey]
        [FieldName("id")]
        public int Id { get; private set; }

        [FieldName("typeName")]
        public string TypeName { get; private set; }
    }
}
