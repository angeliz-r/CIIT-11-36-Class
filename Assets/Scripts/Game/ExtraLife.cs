using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    public int lifeValue = 1;
    private void OnTriggerEnter(Collider objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            Debug.Log("Adding a life!");
            SampleGameManager.Instance.AddLives(lifeValue); //add corresponding life based on value
            AudioManager.Instance.PlaySFX("powerup");
            Destroy(this.gameObject);
        }
    }

}
