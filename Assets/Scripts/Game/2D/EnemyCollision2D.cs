using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            //Debug.Log("Destroying Enemy and losing a life!");

            GameManager2D.Instance.SubtractLives(1);// subtract life
            AudioManager.Instance.PlaySFX("hit");
            Destroy(this.gameObject); // destroy self

            if (GameManager2D.Instance.GameOver())
            {
                //destroy the object that collided with it if no lives left
                Destroy(objectCollidedWith.gameObject);
            }
        }
    }

}
