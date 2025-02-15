using UnityEngine;

public class VSWeapon
{
    public string weaponName = "Weapon";
    public string weaponType = "Generic";
    public int weaponMinDamage = 0;
    public int weaponMaxDamage = 0;

    public VSWeapon()
    {
        weaponName = "Weapon";
        weaponType = "Generic";
        weaponMinDamage = 1;
        weaponMaxDamage = 10;
    }

    public VSWeapon(string name, string type, int minDamage, int maxDamage)
    {
        weaponName = name;
        weaponType = type;
        weaponMinDamage = minDamage;
        weaponMaxDamage = maxDamage;
    }

    public virtual float DamageCalculation()
    {
        float totalDamage = Random.RandomRange(weaponMinDamage, weaponMaxDamage);
        Debug.Log("Dealt " + totalDamage.ToString() + "damage!");
        return totalDamage;
    }

    public virtual void Use()
    {
        Debug.Log("Used " + weaponName);
    }
}
