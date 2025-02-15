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

        Weapon grenade = new Grenade();
        grenade.name = "Grenade";
        grenade.Use();

        Weapon grenade2 = new Grenade(1, 10);
        grenade2.name = "Grendade2";
        grenade2.Use();
    }
}
