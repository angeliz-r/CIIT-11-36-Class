using UnityEngine;

public class Coin2D : MonoBehaviour
{
    public int coinValue = 1;
    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            Debug.Log("Destroying Coin! Sending Score!");
            GameManager2D.Instance.AddScore(coinValue); //add corresponding score based on coin value
            GameManager2D.Instance.GameWin(); //check if you have won the game and update
            Destroy(this.gameObject);
        }
    }
}
