using System;
using System.Reflection;
using System.Collections.Generic;

namespace ORM.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute : Attribute
    {
        public Type ReferencesType { get; private set; }
        public PropertyInfo ReferencesProperty { get; private set; }
        public PropertyInfo PrintProperty { get; private set; }

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
        public ForeignKeyAttribute(Type refType, string propName, string printPropName)
        {
            ReferencesType = refType;
            ReferencesProperty = ReferencesType.GetProperty(propName);
            PrintProperty = ReferencesType.GetProperty(printPropName);
        }
    }
}
