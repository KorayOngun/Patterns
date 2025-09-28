using System.Text.Json;

internal class Program
{
    private static void Main(string[] args)
    {

        var options = new JsonSerializerOptions { WriteIndented = true };

        IEnemyBuilder enemyBuilder = new EnemyBuilder();
        EnemyDirector enemyDirector = new EnemyDirector();

        var enemy1 = enemyDirector.CreateLevelOneOrc(enemyBuilder);
        var enemy2 = enemyDirector.CreateLevelTwoOrc(enemyBuilder);

        Console.WriteLine(JsonSerializer.Serialize(enemy1, options));
        Console.WriteLine(JsonSerializer.Serialize(enemy2, options));


    }
}

public interface IEnemyBuilder
{
    void SetType(string type);
    void SetHp(int hp);
    void SetAttackPoint(int attackPoint);
    Enemy GetEnemy();
}


public  class Enemy
{
    public string Type { get; set; }
    public int HP {  get; set; }
    public int AttackPoint { get; set; }
}

public class EnemyBuilder : IEnemyBuilder
{
    private Enemy _enemy = null!;

    public void Reset() => _enemy = new Enemy();
    public EnemyBuilder()
    {
        this.Reset();
    }

    public void SetAttackPoint(int attackPoint)
    {
        _enemy.AttackPoint = attackPoint;
    }

    public void SetHp(int hp)
    {
        _enemy.HP = hp;
    }

    public void SetType(string type)
    {
        _enemy.Type = type;
    }
    
    public Enemy GetEnemy()
    {
        var enemy = _enemy;
        Reset();
        return enemy;
    }
}

public class EnemyDirector
{
    public Enemy CreateLevelOneOrc(IEnemyBuilder enemyBuilder)
    {
        enemyBuilder.SetHp(1);
        enemyBuilder.SetAttackPoint(1);
        enemyBuilder.SetType("level 1 orc");
        return enemyBuilder.GetEnemy();
    }

    public Enemy CreateLevelTwoOrc(IEnemyBuilder enemyBuilder)
    {
        enemyBuilder.SetHp(2);
        enemyBuilder.SetAttackPoint(2);
        enemyBuilder.SetType("level 2 orc");
        return enemyBuilder.GetEnemy();
    }
}