using System.Text.Json;
using PrototypeRegister.Registers;
using PrototypeRegister.Weapons;

public class Program
{
    private static void Main(string[] args)
    {
        var sword = WeaponRegister.GetWeapon(nameof(Sword));
        var bow = WeaponRegister.GetWeapon(nameof(Bow));

        Console.WriteLine(JsonSerializer.Serialize(sword));
    }

}




