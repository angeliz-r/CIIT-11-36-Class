using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO A CHECKPOINT GAME OBJECT WITH A TRIGGER COLLIDER
    private void OnTriggerEnter(Collider objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            Debug.Log("Saving Checkpoint!");

            //save player position
            Vector3 lastPosition = objectCollidedWith.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", lastPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", lastPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", lastPosition.z);
            PlayerPrefs.Save();
            Destroy(this.gameObject); // destroy this game object after it has been saved
        }
    }
}
