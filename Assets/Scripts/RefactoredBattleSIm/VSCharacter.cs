using System;
using UnityEngine;

public class VSCharacter
{
    public string charName = "Default";
    public float charHP = 0;
    public float charCurrentHP = 0;
    public int charLuck = 0;
    public VSWeapon weapon;

    //this is the default character created if you do not add variable data
    public VSCharacter ()
    {
        charName = "Juan Dela Cruz";
        charHP = 100;
        charCurrentHP = charHP;
        charLuck = 20;
        weapon = new VSWeapon ();
    }

    //this is a custom character when var data is added
    public VSCharacter (string name, float HP, int luck, VSWeapon weapon)
    {
        this.charName = name;
        this.charHP = HP;
        this.charLuck = luck;
        this.weapon = weapon;
        this.charCurrentHP = this.charHP;
    }

    public void Attack ()
    {
        Debug.Log(this.charName + " is attacking with a " + weapon.weaponName);
    }

    public void Dodge (VSCharacter npc)
    {
        Debug.Log(this.charName + " dodged " + npc.charName + "'s attack!");
    }
    public void FreezeUp ()
    {
        Debug.Log(this.charName + " froze up and did nothing!");
    }

}
