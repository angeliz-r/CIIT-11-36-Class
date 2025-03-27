using UnityEngine;

public class ExtraLife2D : MonoBehaviour
{
    public int lifeValue = 1;
    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            Debug.Log("Adding a life!");
            GameManager2D.Instance.AddLives(lifeValue); //add corresponding life based on value
            AudioManager.Instance.PlaySFX("powerup");
            Destroy(this.gameObject);
        }
    }
}
