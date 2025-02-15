using UnityEngine;

public class VSGun : VSWeapon
{
    public int maxBullets = 10;
    public int currentBullets = 10;

    public VSGun(string name, string type, int minDamage, int maxDamage, int maxBulletsCount)
    {
        weaponName = name;
        weaponType = type;
        weaponMinDamage = minDamage;
        weaponMaxDamage = maxDamage;
        maxBullets = maxBulletsCount;
        currentBullets = maxBullets;
    }

    public override void Use()
    {
        if (currentBullets > 0)
        {
            currentBullets--;
            Debug.Log("Used " + weaponName + ". Bullets remaining: " + currentBullets.ToString());
        }
        else if(currentBullets <= 0)
        {
            Debug.Log("Used " + weaponName + " but it has no more bullets!");
        }
    }
}
