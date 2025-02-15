using UnityEngine;

public class VSAxe : VSWeapon
{
    public float bleed = 1.5f;

    public VSAxe(string name, string type, int minDamage, int maxDamage)
    {
        weaponName = name;
        weaponType = type;
        weaponMinDamage = minDamage;
        weaponMaxDamage = maxDamage;
    }
    public override float DamageCalculation()
    {
        float totalDamage = Random.RandomRange(weaponMinDamage, weaponMaxDamage) + bleed;
        Debug.Log("Dealt " + totalDamage.ToString() + " damage!");
        return totalDamage;
    }

    public override void Use()
    {
        Debug.Log("Used " + weaponName + " with bleeding damage of " + bleed.ToString());
    }
}
