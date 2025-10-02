namespace PrototypeRegister.Weapons;

public class Staff : Weapon
{
    public Staff(int damage, int range) : base(damage, range) { }
    public override Staff Clone()
    {
        return (Staff)MemberwiseClone();
    }
}

