using UnityEngine;

public class VSBomb : VSWeapon
{
    public int explosionMultplier = 2;
    public VSBomb(string name, string type, int minDamage, int maxDamage)
    {
        weaponName = name;
        weaponType = type;
        weaponMinDamage = minDamage;
        weaponMaxDamage = maxDamage;
    }

    public override float DamageCalculation()
    {
        float totalDamage = Random.RandomRange(weaponMinDamage, weaponMaxDamage) * explosionMultplier;
        Debug.Log("Dealt " + totalDamage.ToString() + " damage!");
        return totalDamage;
    }

    public override void Use()
    {
        Debug.Log("Used " + weaponName + " with explosion multiplier damage of " + explosionMultplier.ToString());
    }

}
