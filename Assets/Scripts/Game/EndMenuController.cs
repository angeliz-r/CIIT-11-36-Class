using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[System.Serializable]   
public class EndMenuController : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO AN EMPY GAMEOBJECT WITH A UI DOCUMENT COMPONENT
    public bool is2dLevel;
    [SerializeField] private VisualElement _userInterface;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Label _finalScoreLabel;
    [SerializeField] private Label _winStatusLabel;
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
        if (!is2dLevel)
        {
            _winStatusLabel.text = PlayerPrefs.GetString("status");
            _finalScoreLabel.text = "Final Score: " + PlayerPrefs.GetInt("score").ToString();
        }
        else
        {
            _winStatusLabel.text = PlayerPrefs.GetString("status2d");
            _finalScoreLabel.text = "Final Score: " + PlayerPrefs.GetInt("score2d").ToString();
        }
    }
    private void OnMenuClicked()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartScreen");
    }

    private void OnExitClicked()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
