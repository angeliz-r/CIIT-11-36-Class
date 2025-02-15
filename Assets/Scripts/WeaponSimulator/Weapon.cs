using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public string name;
    protected int maxBullets;
    private int damage;

    public virtual void Use()
    {
        Debug.Log("Used " + this.name);
    }

}
