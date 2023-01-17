/*
Factory Coding Exercise
You are given a class called Person . The person has two fields: Id , and Name .

Please implement a non-static PersonFactory  that has a CreatePerson()  method that takes a person's name.

The Id of the person should be set as a 0-based index of the object created. So, the first person the factory makes should have Id=0, second Id=1 and so on.
*/
using NUnit.Framework;

var test = new FirstTestSuite();
test.Test();



public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PersonFactory
{
    private int Id = 0;
    public Person CreatePerson(string name)
    {
        return new Person { Id = Id++, Name = name };
    }
}


[TestFixture]
public class FirstTestSuite
{
    [Test]
    public void Test()
    {
        var pf = new PersonFactory();

        var p1 = pf.CreatePerson("Chris");
        Assert.That(p1.Name, Is.EqualTo("Chris"));
        Assert.That(p1.Id, Is.EqualTo(0));

        var p2 = pf.CreatePerson("Sarah");
        Assert.That(p2.Id, Is.EqualTo(1));
    }
}