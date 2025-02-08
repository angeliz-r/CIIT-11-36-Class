using System.Collections.Generic;
using UnityEngine;


public class BS : MonoBehaviour
{
    public string playerName = "Hatdog";
    public int playerHP = 50;
    public int playerCurrentHP = 0;
    public int playerLuck = 9;

    public int enemyHP = 50;
    public int enemyCurrentHP = 0;

    public int LuckThreshold = 30;
    public int minDamage = 5;
    public int maxDamage = 10;

    public string[] weapons = { "Axe", "Tsinelas", "Tinapay" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Initialize player and enemy HP to their MAX HP.
        playerCurrentHP = playerHP;
        enemyCurrentHP = enemyHP;

        Debug.Log("The battle begins!");

        //while the player and enemy are alive, do these:
        while (playerCurrentHP > 0 && enemyCurrentHP > 0 )
        {
            //Check if the player is lucky enough to escape, if not, keep fighting
            if (CheckPlayerLuck(playerLuck) > LuckThreshold)
            {
                Debug.Log(playerName + " has escaped!");
                break; //exit the fight
            }

            //if the player is not lucky, continue the battle.
            PlayerAttack(); // the player atacks, display enemy HP after the enemy receives damage
            Debug.Log("Enemy HP: " + enemyHP + " / " + enemyCurrentHP);
            EnemyAttack(); //the enemy attacks, dispay player HP after the player receives damage
            Debug.Log(playerName + " HP: " + playerHP + " / " + playerCurrentHP);
        }

        //This is a win checker
        //check if player is alive, while enemy is dead
        if (playerCurrentHP > 0 && enemyCurrentHP <= 0)
        {
            Debug.Log(playerName + " is victorious!");
        }
        //check if the enemy is alive while player is dead
        else if (enemyCurrentHP >0 && playerCurrentHP <=0)
        {
            Debug.Log(playerName + " loses!");
        }
        //if both are alive/dead the battle ends in a draw
        else
        {
            Debug.Log("The battle ends in a draw.");
        }

        Debug.Log("The battle has ended.");
    }

    int WeaponDamage(string weapon) //this is a weapon damage randomizer that gets the weapon name and spits out a random damage from the random range.
    {
        int damage = 0;
        switch (weapon)
        {
            case "Axe":
                damage = Random.Range(minDamage, maxDamage);
                break;
            case "Tinelas":
                damage = Random.Range(0, minDamage);
                break;
            case "Tinapay":
                damage = Random.Range(0, 1);
                break;
        }
        return damage;
    }

    int CheckPlayerLuck(int playerLuck) //this randomizes the player luck adding from the player luck stat
    {
        int luck = Random.Range(0, playerLuck + 5);
        return luck;
    }

    void PlayerAttack() //here the player attacks with a randomly selected weapon with its randomly generated damage
    {
        int selectedWeapon = Random.Range(0, weapons.Length);
        int damage = WeaponDamage(weapons[selectedWeapon]);
        Debug.Log(playerName + " is attacking with a " + weapons[selectedWeapon] + " for " + damage + " damage!");
        enemyCurrentHP -= damage;
    }

    void EnemyAttack()
    {
        int selectedWeapon = Random.Range(0, weapons.Length);
        int damage = WeaponDamage(weapons[selectedWeapon]);
        Debug.Log("The enemy is attacking with a " + weapons[selectedWeapon] + " for " + damage + " damage!");
        playerCurrentHP -= damage;
    }
}
