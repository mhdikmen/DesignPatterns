using static System.Console;

var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

var jane = john.DeepCopy();
jane.Address.HouseNumber = 321;
jane.Names[0] = "Jane";// it also applies it to john. I am gonna fix it.

WriteLine(john);
WriteLine(jane);


public interface IProtoType<T>
{
    T DeepCopy();
}

public class Address : IProtoType<Address>
{
    public readonly string StreetName;
    public int HouseNumber;

    public Address(string streetName, int houseNumber)
    {
        StreetName = streetName;
        HouseNumber = houseNumber;
    }

    public Address(Address other)
    {
        StreetName = other.StreetName;
        HouseNumber = other.HouseNumber;
    }

    public override string ToString()
    {
        return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
    }

    public Address DeepCopy()
    {
        return new Address(StreetName, HouseNumber);
    }
}

public class Person : IProtoType<Person>
{
    public readonly string[] Names;
    public readonly Address Address;

    public Person(string[] names, Address address)
    {
        Names = names;
        Address = address;
    }
    public Person(Person other)
    {
        Names = other.Names;
        Address = other.Address;
    }
    public override string ToString()
    {
        return $"{nameof(Names)}: {string.Join(",", Names)}, {nameof(Address)}: {Address}";
    }

    public Person DeepCopy()
    {
        return new Person(Names, Address.DeepCopy());
    }
}


