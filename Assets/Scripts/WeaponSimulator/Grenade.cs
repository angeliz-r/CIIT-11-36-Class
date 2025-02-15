using UnityEngine;

[System.Serializable]
public class Grenade : Weapon
{
    protected int grenadeCount = 2;
    protected float grenadeDamage = 30.5f;

    public Grenade ()
    {

    }

    public Grenade (int count, float damage) 
    {
        this.grenadeCount = count;
        this.grenadeDamage = damage;
    }

    public override void Use()
    {
        Debug.Log("Threw a " + this.name);
        grenadeCount--;
        Debug.Log("Grenade damage: " + grenadeDamage.ToString());
        Debug.Log("Grenades left: " + grenadeCount.ToString());

    }
}
