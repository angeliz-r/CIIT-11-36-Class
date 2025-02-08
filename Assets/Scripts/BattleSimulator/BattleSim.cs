using System;
using UnityEngine;

public class BattleSim : MonoBehaviour
{
    public string playerName;
    public int playerMaxHP = 50;
    public int playerCurrentHP = 50;

    private int minDamage = 5;
    private int maxDamage = 15;
    private int luck = 5;

    private string[] weapons = { "sword", "stick", "axe" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("The battle simulation begins!");
        Debug.Log(playerName + " HP: " + playerCurrentHP + "/" + playerMaxHP);

        while (playerCurrentHP > 0)
        {

            int luckCheck = luck + UnityEngine.Random.Range(0, 10);

            if (luckCheck > 15)
            {
                Debug.Log(playerName + " has escaped the encounter!");
                break;
            }
            else
            {
                int targetDamage = UnityEngine.Random.Range(0, 20);
                playerCurrentHP -= targetDamage;

                int selectedWeapon = UnityEngine.Random.Range(0, weapons.Length);
                Debug.Log(playerName + " took " + targetDamage + " damage from a " + weapons[selectedWeapon] + ".");
                Debug.Log(playerName + " HP: " + playerCurrentHP + "/" + playerMaxHP);
            }

            if (playerCurrentHP <= 0)
            {
                Debug.Log(playerName + " is dead");
            }
        }
        Debug.Log("The battle simulation has ended.");
    }
}
