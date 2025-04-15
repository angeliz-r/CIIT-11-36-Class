using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager2D : MonoBehaviour
{
    public static GameManager2D Instance;
    public PostProcessManager postProcess;
    [SerializeField] private int Score = 0;
    [SerializeField] private int Lives = 3;

    //UI
    private VisualElement _root;
    private Label _scoreLabel;
    private Label _livesLabel;
    private Button _mainMenu;
    private Button _mute;
    private bool _muteToggled;

    private void OnEnable()
    {
        Instance = this; //create a running instance of Sample Game Manager
        _muteToggled = false;
        //get the UI elements
        _root = GetComponent<UIDocument>().rootVisualElement;
        //query from the root visual element, basically look for the labels
        _scoreLabel = _root.Q<Label>("Score");
        _livesLabel = _root.Q<Label>("Lives");
        _mainMenu = _root.Q<Button>("MainMenu");
        _mainMenu.clicked += MainMenuClicked;
        _mute = _root.Q<Button>("Sound");
        _mute.clicked += MuteClicked;
    }

    private void MuteClicked()
    {
        if (_muteToggled)
        {
            _mute.text = "SOUND: ON";
            _muteToggled = false;
        }
        else
        {
            _mute.text = "SOUND: OFF";
            _muteToggled = true;
        }
        AudioManager.Instance.ToggleSound();
    }
    private void Awake()
    {
        //when game level is loaded, check if there is existing playerprefs
        if (!IsNewGame())
            LoadGame(); //if it is not a new game, load the existing playerprefs data
        else if (IsNewGame())
            PlayerPrefs.SetInt("playerStarted2d", 1); // 1 in this context means TRUE
    }

    private void Start()
    {
        //set up initial UI text on screen
        _scoreLabel.text = "Score: " + Score.ToString();
        _livesLabel.text = "Lives: " + Lives.ToString();

        //set post process
        if (Lives > 1)
            postProcess.SetDangerPostProcess(false);
        else if (Lives == 1)
            postProcess.SetDangerPostProcess(true);


    }
    private void MainMenuClicked()
    {
        PlayerPrefs.Save(); //save all preferences before loadng to start screen
        PlayerPrefs.SetInt("SceneSelect", 2);
        SceneManager.LoadScene("StartScreen"); // load the start screen
    }

    public void AddScore(int scoreValue)
    {
        Score += scoreValue; // add to total score
        _scoreLabel.text = "Score: " + Score.ToString(); // update the UI
        PlayerPrefs.SetInt("score2d", Score); //save the data to player prefs
       // Debug.Log("SCORE: " + Score.ToString());
    }

    public void SubtractLives(int livesValue)
    {
        Lives -= livesValue; //subtract to total lives
        _livesLabel.text = "Lives: " + Lives.ToString(); //update the UI
        PlayerPrefs.SetInt("lives2d", Lives); // save the data
        if (Lives == 1)
            postProcess.SetDangerPostProcess(true);
        //Debug.Log("LIVES: " + Lives.ToString());
    }

    public void AddLives(int livesValue)
    {
        Lives += livesValue; // add to total lives
        _livesLabel.text = "Lives: " + Lives.ToString(); // update the UI
        PlayerPrefs.SetInt("lives2d", Lives); //save the data
        if (Lives > 1)
            postProcess.SetDangerPostProcess(false);
        //Debug.Log("LIVES: " + Lives.ToString());
    }

    public bool GameOver()
    {
        if (Lives <= 0)
        {
            //lose
            PlayerPrefs.SetString("status2d", "You Lose!"); //set win/lose status to carry over to End Screen
            PlayerPrefs.SetInt("SceneSelect", 2);
            SceneManager.LoadScene("EndScreen"); // load the end screen
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GameWin()
    {
        PlayerPrefs.SetString("status2d", "You Win!"); //set win/lose status to carry over to End Screen
        PlayerPrefs.SetInt("SceneSelect", 2); //remember the game level
        SceneManager.LoadScene("EndScreen");  // load the end screen
    }

    void LoadGame()
    {
        //get save data
        Score = PlayerPrefs.GetInt("score2d", 0); //if score does not exist, default to 0
        Lives = PlayerPrefs.GetInt("lives2d", 0); //if lives does not exist, default to 0

        if (Lives <= 0) //if player died, reset values
        {
            Lives = 3;
            PlayerPrefs.SetInt("lives2d", Lives); //set lives key as the value of Lives variable
            Score = 0;
            PlayerPrefs.SetInt("score2d", Score); //set the value of score key as the value of Score variable
        }
    }

    public bool IsNewGame()
    {
        if (PlayerPrefs.HasKey("playerStarted2d"))
        {
            return false; //load the game if playerStarted key does not exist
        }
        else
        {
            return true;
        }
    }
}
