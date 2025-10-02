namespace PrototypeRegister.Weapons;

public class Bow : Weapon
{
    public Bow(int damage, int range) : base(damage, range) { }
    public override Bow Clone()
    {
        return (Bow)MemberwiseClone();
    }
}

