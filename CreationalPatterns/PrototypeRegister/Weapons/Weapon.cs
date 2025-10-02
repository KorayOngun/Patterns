namespace PrototypeRegister.Weapons;

public abstract class Weapon
{
    public Weapon()
    {

    }
    public Weapon(int damage, int range)
    {
        Damage = damage;
        Range = range;
    }
    public int Damage { get; set; }
    public int Range { get; set; }

    public abstract Weapon Clone();
}

