using UnityEngine;

public class SpikeCollision2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {

            objectCollidedWith.rigidbody.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);
            GameManager2D.Instance.SubtractLives(1);// subtract life
            AudioManager.Instance.PlaySFX("hit");

            if (GameManager2D.Instance.GameOver())
            {
                //destroy the object that collided with it if no lives left
                Destroy(objectCollidedWith.gameObject);
            }
        }
    }
}
