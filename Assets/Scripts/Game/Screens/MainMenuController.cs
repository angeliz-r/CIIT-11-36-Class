using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

[System.Serializable]
public class MainMenuController : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO AN EMPY GAMEOBJECT WITH A UI DOCUMENT COMPONENT
    private string _gameSceneName;
    private VisualElement _userInterface;
    private Button _newGameButton, _continueButton, _exitButton, _optionsButton;
    private Label _saveStatus;

    private void Awake()
    {
        _userInterface = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        //Look for the UI button called NewGame
        _newGameButton = _userInterface.Q<Button>("NewGame");
        //Check for click on the button and run OnNewGameClicked function below
        _newGameButton.clicked += OnNewGameClicked;

        _continueButton = _userInterface.Q<Button>("Continue");
        _continueButton.clicked += OnContinueClicked;

        _exitButton = _userInterface.Q<Button>("Exit");
        _exitButton.clicked += OnExitClicked;

        _optionsButton = _userInterface.Q<Button>("Options");
        _optionsButton.clicked += OnOptionsClicked;

        _saveStatus = _userInterface.Q<Label>("Status");
    }
    private void OnNewGameClicked()
    {
        _saveStatus.text = ""; //clear save status text if there was any text
        SelectSceneCheck();
        PlayerPrefs.DeleteAll();//clear old data/playerprefs
        SceneManager.LoadScene(_gameSceneName); //load game level as a new game
        AudioManager.Instance.PlaySFX("button");
    }

    private void OnContinueClicked()
    {
        SelectSceneCheck();
        AudioManager.Instance.PlaySFX("button");
        //check if the plyer has level saved
        if (PlayerPrefs.HasKey("playerStarted") && _gameSceneName == "LevelSample") //check if player had previous save data
        {
            _saveStatus.text = ""; //clear save status text if there was any text
            SceneManager.LoadScene(_gameSceneName);//load game level
        }
        else if (!PlayerPrefs.HasKey("playerStarted") && _gameSceneName == "LevelSample")
        {
            _saveStatus.text = "No Save Game Found";
        }
        else if(PlayerPrefs.HasKey("playerStarted2d") && _gameSceneName == "2DLevel")
        {
            _saveStatus.text = ""; //clear save status text if there was any text
            SceneManager.LoadScene(_gameSceneName);//load game level
        }
        else if (!PlayerPrefs.HasKey("playerStarted2d") && _gameSceneName == "2DLevel")
        {
            _saveStatus.text = "No Save Game Found";
        }

    }

    private void OnOptionsClicked()
    {
        SceneManager.LoadScene("OptionsScreen");
        AudioManager.Instance.PlaySFX("button");
    }


    private void OnExitClicked()
    {
        _saveStatus.text = "";
        AudioManager.Instance.PlaySFX("button");
        //SceneManager.LoadScene("GameSelect");
        Application.Quit();
    }

    private void SelectSceneCheck()
    {
        _gameSceneName = "2DLevel";
        //if (PlayerPrefs.GetInt("SceneSelect") == 2)
        //{
        //    _gameSceneName = "2DLevel";
        //}
        //else if (PlayerPrefs.GetInt("SceneSelect") == 3)
        //{
        //    _gameSceneName = "LevelSample";
        //}
    }
}
