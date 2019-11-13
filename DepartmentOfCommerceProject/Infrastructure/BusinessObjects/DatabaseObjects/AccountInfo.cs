using System;
using ORM.Objects;
using ORM.Attributes;
using DepartmentOfCommerceProject.Repositories;

namespace DepartmentOfCommerceProject.Infrastructure.BusinessObjects.DatabaseObjects
{
    [TableName("Accounts")]
    [RelationTable(typeof(AccountTypesRepository))]
    public class AccountInfo : DatabaseObject
    {
        [PrimaryKey]
        [FieldName("token")]
        public string Hash { get; private set; }

        [FieldName("accountNickname")]
        public string NickName { get; private set; }

        [FieldName("ownerName")]
        public string Name { get; private set; }

        [FieldName("ownerSurname")]
        public string Surname { get; private set; }

        [FieldName("accType")]
        [ForeignKey(typeof(AccountTypesRepository), typeof(AccountType), "Id", "TypeName")]
        public int AccountType { get; private set; }
    }
}
