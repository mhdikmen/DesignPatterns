
Foo x = await Foo.CreateAsync();

public class Foo
{
    private Foo()
    {
    }
    public static async Task<Foo> CreateAsync()
    {
        var result = new Foo();
        return await result.InitAsync();
    }
    public async Task<Foo> InitAsync()
    {
        await Task.Delay(1000);
        return this;
    }
}