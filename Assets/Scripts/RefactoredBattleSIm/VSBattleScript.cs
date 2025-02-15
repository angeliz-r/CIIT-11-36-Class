using System.Runtime.CompilerServices;
using UnityEngine;

public class VSBattleScript : MonoBehaviour
{
    //initialize characters
    public VSCharacter player;
    public VSCharacter enemy;

    //initialize public variables
    public int luckThreshold = 30;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initializing characters and randomize their weapons
        player = new VSCharacter("Minato", 200, 22, WeaponRandomizer());
        enemy = new VSCharacter("Takaya", 200, 15, WeaponRandomizer());

        Debug.Log("The battle begins! The characters' weapons have been randomly selected.");
        Debug.Log("The battle is between " + player.charName + " weilding a " + player.weapon.weaponName + " and " + enemy.charName + " weilding a " + enemy.weapon.weaponName);

        //battle loops
        while (CheckBattleStatus(player, enemy)) //check if both are still alive
        {
            LogHP();
            DetermineAction(player, enemy);
            DetermineAction(enemy, player);
        }

        LogHP(); //one last log to see the HPs 

        //determine the winner
        if (player.charCurrentHP <= 0 && enemy.charCurrentHP <=0)
        {
            Debug.Log("Both have lost!");
        }
        else if (player.charCurrentHP <= 0 && enemy.charCurrentHP > 0)
        {
            Debug.Log(enemy.charName + " has won!");
        }
        else if (enemy.charCurrentHP <= 0 && player.charCurrentHP > 0)
        {
            Debug.Log(player.charName + " has won!");
        }
    }

    void DetermineAction(VSCharacter npc1, VSCharacter npc2)
    {
        npc1.Attack();
        if (CheckCharLuck(npc2.charLuck) > luckThreshold) //if npc2 is lucky, dodge
        {
            npc2.Dodge(player);
        }
        else if (CheckCharLuck(npc1.charLuck) < luckThreshold - 15) //if npc1 is very unlucky, freeze up.
        {
            npc1.FreezeUp();
        }
        else // hit if nothing else worked
        {
            npc1.weapon.Use();
            npc2.charCurrentHP -= npc1.weapon.DamageCalculation();
        }
    }

    //this is a randomizer that initializes a weapon for the characters
    VSWeapon WeaponRandomizer()
    {
        VSAxe axe;
        VSGun gun;
        VSBomb bomb;
        int weaponSelect = Random.Range(0, 2);
        switch(weaponSelect)
        {
            case 0:
                axe = new VSAxe("Axe", "Two Handed", 10, 50);
                return axe;
            break; 
            case 1:
                gun = new VSGun("Gun", "Ranged", 30, 80, 5);
                return gun;
            break;
            case 2:
                bomb = new VSBomb("Bomb", "Explosive", 70, 100);
                return bomb;
            break;
            default:
                gun = new VSGun("Gun", "Ranged", 50, 70, 10);
                return gun;
            break;
        }

    }

    //this randomizes the player luck adding from the player luck stat
    int CheckCharLuck(int luckVal)
    {
        int luck = Random.Range(0, luckVal + 10);
        return luck;
    }

    //this checks if any of the npcs are dead
    bool CheckBattleStatus (VSCharacter npc1, VSCharacter npc2)
    {
        bool isBattleEnd;
        if (npc1.charCurrentHP > 0 && npc2.charCurrentHP > 0)
            isBattleEnd = true;
        else
            isBattleEnd = false;

        return isBattleEnd;
    }

    //this logs the HP of each npc
    void LogHP ()
    {
        Debug.Log("__________________________________");
        Debug.Log(player.charName + "'s Health: " + player.charHP + "/" + player.charCurrentHP);
        Debug.Log(enemy.charName + "'s Health: " + enemy.charHP + "/" + enemy.charCurrentHP);
        Debug.Log("__________________________________");
    }
}
