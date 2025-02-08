using UnityEngine;

public class WeaponSim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Weapon weapon = new Weapon();
        weapon.name = "Generic weapon";
        weapon.Use();

        Weapon gun = new Gun();
        gun.name = "Vandal";
        gun.Use();

        Weapon knife = new Knife();
        knife.name = "Knife";
        knife.Use();

    }
}
