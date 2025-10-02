using PrototypeRegister.Weapons;

namespace PrototypeRegister.Registers;

public static class WeaponRegister
{
    private static readonly Dictionary<string, Weapon> register = new Dictionary<string, Weapon>()
    {
        {nameof(Sword),new Sword(10,1)},
        {nameof(Bow), new Bow(6,5)},
        {nameof(Staff), new Staff(8,3)}
    };

    public static Weapon? GetWeapon(string name)
    {
        if (register.TryGetValue(name, out var weapon))
            return weapon.Clone();
        return null;
    }
}