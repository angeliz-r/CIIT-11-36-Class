using UnityEngine;
using UnityEngine.UIElements;

public class SampleGameManager : MonoBehaviour
{
    public static SampleGameManager Instance;
    private int Score = 0;
    private int Lives = 3;
    private Vector3 playerPosition;
    //UI
    private VisualElement _root;
    private Label _scoreLabel;
    private Label _livesLabel;
    private Label _statusLabel;

    private void OnEnable()
    {
        Instance = this; //create a running instance of Sample Game Manager

        //get the UI elements
        _root = GetComponent<UIDocument>().rootVisualElement;
        //query from the root visual element, basically look for the labels
        _scoreLabel = _root.Q<Label>("Score");
        _livesLabel = _root.Q<Label>("Lives");
        _statusLabel = _root.Q<Label>("Status");
    }

    private void Start()
    {
        if (!IsNewGame())
            LoadGame();
        //set up initial UI text on screen
        _scoreLabel.text = "Score: " + Score.ToString();
        _livesLabel.text = "Lives: " + Lives.ToString();

    }

    public void AddScore(int scoreValue)
    {
        Score += scoreValue; // add to total score
        _scoreLabel.text = "Score: " + Score.ToString(); // update the UI
        PlayerPrefs.SetInt("score", Score); //save the data
        Debug.Log("SCORE: " + Score.ToString());
    }

    public void SubtractLives(int livesValue)
    {
        Lives -= livesValue; //subtract to total lives
        _livesLabel.text = "Lives: " + Lives.ToString(); //update the UI
        PlayerPrefs.SetInt("lives", Lives); // save the data
        Debug.Log("LIVES: " + Lives.ToString());
    }

    public void AddLives(int livesValue)
    {
        Lives += livesValue; // add to total lives
        _livesLabel.text = "Lives: " + Lives.ToString(); // update the UI
        PlayerPrefs.SetInt("lives", Lives); //save the data
        Debug.Log("LIVES: " + Lives.ToString());
    }

    public bool GameOver()
    {
        if (Lives <= 0)
        {
            //_statusLabel.text = "YOU LOSE!";
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GameWin()
    {
        if (Score >= 5)
        {
            //_statusLabel.text = "YOU WIN!";
        }
    }

    void LoadGame()
    {
        //get save data
        Score = PlayerPrefs.GetInt("score", 0);
        Lives = PlayerPrefs.GetInt("lives", 0);

        if (Lives <= 0) //if player died, reset values
        {
            Lives = 3;
            PlayerPrefs.SetInt("lives", Lives);
            Score = 0;
            PlayerPrefs.SetInt("score", Score);
            PlayerPrefs.DeleteKey("playerPositionX");
            PlayerPrefs.DeleteKey("playerPositionY");
            PlayerPrefs.DeleteKey("playerPositionZ");
        }
    }

    public bool IsNewGame()
    {
        if (PlayerPrefs.HasKey("playerStarted"))
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt("playerStarted", 1);
            return true;
        }
    }

    public Vector3 GetPlayerPosition()
    {
        playerPosition.x = PlayerPrefs.GetFloat("playerPositionX", 0);
        playerPosition.y = PlayerPrefs.GetFloat("playerPositionY", 0);
        playerPosition.z = PlayerPrefs.GetFloat("playerPositionZ", 0);
        return playerPosition;
    }
}
