internal class Program
{
    private static void Main(string[] args)
    {
        var user = new User()
        {
            Id = 1,
            Name = "Test"
        };

        IRepo repo = new Repo();
        repo = new LoggingRepoDecorator(repo);
        repo = new AuditRepoDecoratore(repo);

        repo.Save(user);
        var a = repo.Get(user.Id);
        Console.WriteLine(a.Name);
    }
}



public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public void A()
    {
        this.MemberwiseClone();
    }
}

public interface IRepo // IComponent
{
    void Save(User user);
    User? Get(int id);
}

public class Repo : IRepo // BaseComponent
{
    private readonly List<User> users = new List<User>();

    public User? Get(int id)
    {
        return users.FirstOrDefault(x => x.Id == id);
    }

    public void Save(User user)
    {
        users.Add(user);
    }
}



public class RepoDecorator : IRepo //Component Decorator
{
    protected IRepo _repo;
    public RepoDecorator(IRepo repo)
    {
        _repo = repo;
    }

    public virtual void Save(User user)
    {
        _repo.Save(user);
    }

    public virtual User? Get(int id)
    {
        return _repo.Get(id);
    }
}




public class LoggingRepoDecorator : RepoDecorator // Decorator 1
{
    public LoggingRepoDecorator(IRepo repo) : base(repo) { }

    public override User? Get(int id)
    {
        var item = base.Get(id);
        Console.WriteLine("log get");
        return item;
    }

    public override void Save(User user)
    {
        base.Save(user);
        Console.WriteLine("log save");
    }
}



public class AuditRepoDecoratore : RepoDecorator // Decorator 2
{
    public AuditRepoDecoratore(IRepo repo) : base(repo) { }

    public override void Save(User user)
    {
        base.Save(user);
        Console.WriteLine("audit save");
    }
}