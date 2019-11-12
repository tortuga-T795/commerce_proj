using ORM.Objects;
using ORM.Attributes;

namespace Tests
{
    public class TestDatabaseObject : DatabaseObject
    {
        [FieldName("TestId")]
        public int Id { get; set; }

        [FieldName("TestField")]
        public int TestProp { get; set; }
    }
}
