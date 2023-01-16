
var pb = new PersonBuilder();
var person = pb.Called("Muhammed Hanifi").WorksAsA("Senior Software Development Specialist").Build();
Console.WriteLine(person);
public class Person
{
    public string Name, Position;
    public override string ToString()
    {
        return $"Name : {Name} , Position : {Position}";
    }
}

public sealed class PersonBuilder
{
    public readonly List<Action<Person>> Actions
      = new List<Action<Person>>();

    public PersonBuilder Called(string name)
    {
        Actions.Add(p => { p.Name = name; });
        return this;
    }

    public Person Build()
    {
        var p = new Person();
        Actions.ForEach(a => a(p));
        return p;
    }
}

public static class PersonBuilderExtensions
{
    public static PersonBuilder WorksAsA
      (this PersonBuilder builder, string position)
    {
        builder.Actions.Add(p =>
        {
            p.Position = position;
        });
        return builder;
    }
}
