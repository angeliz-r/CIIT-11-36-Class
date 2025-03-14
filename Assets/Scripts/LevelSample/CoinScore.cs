using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScore : MonoBehaviour
{
    public int coinValue = 1;
    private void OnTriggerEnter(Collider objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            Debug.Log("Destroying Coin! Sending Score!");
            SampleGameManager.Instance.AddScore(coinValue); //add corresponding score based on coin value
            SampleGameManager.Instance.GameWin(); //check if you have won the game and update
            Destroy(this.gameObject);
        }
    }
}
