using System;
using System.Reflection;
using System.Collections.Generic;
using ORM.Repositories;
using ORM.Objects;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public Type ReferencesType { get; private set; }
        public PropertyInfo ReferencesProperty { get; private set; }
        public PropertyInfo PrintProperty { get; private set; }
        public Type RepositoryType { get; private set; }
        // было не object, а IRepository<DatabaseObject>, просто заебало колупаться
        public PropertyInfo RepositoryInstanceProperty { get; private set; }
        public bool NeedToDownloadData
        {
            get
            {
                var repo = RepositoryInstanceProperty.GetValue(null, null) as IRepository<DatabaseObject>;

                return repo.NeedToDownload;
            }
        }

        public DatabaseData<T> GetRepositoryData<T>() where T : DatabaseObject, new()
        {
            var repo = RepositoryInstanceProperty.GetValue(null, null) as IRepository<T>;

            return repo.Data;
        }

        /// <summary>
        /// Сие чудо костыльного образа мышления должно работать так:
        ///     када селектается коллекция каких-та объектов, внутри которых нахоидтся ссыль на етыт объект,
        ///         то селектается ещё и коллекция объектов, на которые ссылаются и записываются сюда, абы не потерять
        ///         для послебующей работы
        ///     а потом када работа непосредственно с коллекцией объектов закончилась, 
        ///         то она останется здесь, шобы не проебаться)
        /// </summary>
        public List<object> CollectionToReference { get; set; }

        /// <summary>
        /// </summary>
        /// <param name="refType">Type to reference</param>
        /// <param name="propName">Name of the property to be referenced</param>
        /// <param name="printPropName">Name of the property to be printed when data is displayed</param>
        public ForeignKeyAttribute(Type repoType, Type refType, string propName, string printPropName)
        {
            RepositoryType = repoType;
            RepositoryInstanceProperty = repoType.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
            ReferencesType = refType;
            ReferencesProperty = ReferencesType.GetProperty(propName);
            PrintProperty = ReferencesType.GetProperty(printPropName);
        }
    }
}
