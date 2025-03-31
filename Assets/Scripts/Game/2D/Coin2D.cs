using UnityEngine;

public class Coin2D : MonoBehaviour
{
    public int coinValue = 1;
    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            //Debug.Log("Destroying Coin! Sending Score!");
            AudioManager.Instance.PlaySFX("powerup");
            GameManager2D.Instance.AddScore(coinValue); //add corresponding score based on coin value
            Destroy(this.gameObject);
        }
    }
}
