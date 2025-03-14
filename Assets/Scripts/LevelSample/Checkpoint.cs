using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider objectCollidedWith)
    {
        if (objectCollidedWith.gameObject.tag == "Player")
        {
            Debug.Log("Saving Checkpoint!");
            //save game scene
            string activeScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("levelSaved", activeScene);

            //save player position
            Vector3 lastPosition = objectCollidedWith.transform.position;
            PlayerPrefs.SetFloat("playerPositionX", lastPosition.x);
            PlayerPrefs.SetFloat("playerPositionY", lastPosition.y);
            PlayerPrefs.SetFloat("playerPositionZ", lastPosition.z);
            PlayerPrefs.Save();
            Destroy(this.gameObject);
        }
    }
}
