using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour
{
    [SerializeField] private string newGame;

    public void NewGameButton ()
    {
        SceneManager.LoadScene(newGame);
    }

    public void LoadGameButton ()
    {
        if (PlayerPrefs.HasKey("levelSaved"))
        {
            string loadLevel = PlayerPrefs.GetString("levelSaved");
            SceneManager.LoadScene(loadLevel);
        }
    }

}
