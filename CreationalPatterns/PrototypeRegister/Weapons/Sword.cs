namespace PrototypeRegister.Weapons;

public class Sword : Weapon
{
    public Sword()
    {

    }
    public Sword(int damage, int range) : base(damage, range) { }
    public override Sword Clone()
    {
        return (Sword)MemberwiseClone();
    }
}

