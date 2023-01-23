using NUnit.Framework;
using System.Text;


namespace CodeBuilder
{
    class Field
    {
        public string Type, Name;

        public override string ToString()
        {
            return $"public {Type} {Name}";
        }
    }

    class Class
    {
        public string Name;
        public List<Field> Fields = new List<Field>();

        public Class()
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .AppendLine($"public class {Name}")
                .AppendLine("{");

            foreach (var f in Fields)
                sb.AppendLine($"  {f};");

            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        public CodeBuilder(string rootName)
        {
            theClass.Name = rootName;
        }

        public CodeBuilder AddField(string name, string type)
        {
            theClass.Fields.Add(new Field { Name = name, Type = type });
            return this;
        }

        public override string ToString()
        {
            return theClass.ToString();
        }

        private Class theClass = new Class();
    }
}

namespace CodeBuilder.Test
{
    [TestFixture]
    public class FirstTestSuite
    {
        [Test]
        public void EmptyTest()
        {
            var cb = new CodeBuilder("Foo");
            Assert.That(cb.ToString(), Is.EqualTo("public class Foo\r\n{\r\n}\r\n"));
        }

        [Test]
        public void PersonTest()
        {

            var expectedResult = @"public class Person
{
  public string Name;
  public int Age;
}
";
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Assert.That(cb.ToString(), Is.EqualTo(expectedResult));
        }
    }
}