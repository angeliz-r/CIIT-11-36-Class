using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class EndMenuController : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO AN EMPY GAMEOBJECT WITH A UI DOCUMENT COMPONENT
    //public bool is2dLevel;
    private VisualElement _userInterface;
    private Button _mainMenuButton;
    private Button _exitButton;
    private Label _finalScoreLabel;
    private Label _winStatusLabel;

    private void Awake()
    {
        _userInterface = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _mainMenuButton = _userInterface.Q<Button>("MainMenu");
        _mainMenuButton.clicked += OnMenuClicked;

        _exitButton = _userInterface.Q<Button>("Exit");
        _exitButton.clicked += OnExitClicked;

        _finalScoreLabel = _userInterface.Q<Label>("FinalScore");
        _winStatusLabel = _userInterface.Q<Label>("WinStatus");
    }
    private void Start()
    {
        _winStatusLabel.text = PlayerPrefs.GetString("status2d");
        _finalScoreLabel.text = PlayerPrefs.GetInt("score2d").ToString();
        //if (PlayerPrefs.GetInt("SceneSelect") == 3)
        //{
        //    _winStatusLabel.text = PlayerPrefs.GetString("status");
        //    _finalScoreLabel.text = "Final Score: " + PlayerPrefs.GetInt("score").ToString();
        //}
        //else if (PlayerPrefs.GetInt("SceneSelect") == 2)
        //{
        //    _winStatusLabel.text = PlayerPrefs.GetString("status2d");
        //    _finalScoreLabel.text = PlayerPrefs.GetInt("score2d").ToString();
        //}
    }
    private void OnMenuClicked()
    {
        AudioManager.Instance.PlaySFX("button");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartScreen");
    }

    private void OnExitClicked()
    {
        AudioManager.Instance.PlaySFX("button");
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
