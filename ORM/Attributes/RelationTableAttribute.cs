using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Objects;
using ORM.Repositories;
using System.Reflection;

namespace ORM.Attributes
{
    /// <summary>
    /// Этот атрибут будет нужен при загрузке данных из БД, т.к. метод DatabaseManager.GetData
    /// не работает с конкретными полями какого-то DatabaseObject'а, то нужно этим атрибутом
    /// пометить класс, чтобы GetData смог понять какие ещё нужно данные загружать
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RelationTableAttribute : Attribute
    {
        public PropertyInfo RepositoryInstanceProperty { get; private set; }
        public Type ReferenceType { get; private set; }

        public DatabaseData<T> GetDatabaseData<T>() where T : DatabaseObject, new()
        {
            var repo = RepositoryInstanceProperty.GetValue(null, null) as IRepository<T>;

            return repo.Data;
        }

        public RelationTableAttribute(Type repoType)
        {
            this.ReferenceType = repoType;
            this.RepositoryInstanceProperty = repoType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
        }
    }
}
