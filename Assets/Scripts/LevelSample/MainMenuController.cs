using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MainMenuController : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO AN EMPY GAMEOBJECT WITH A UI DOCUMENT COMPONENT
    [SerializeField] private VisualElement _userInterface;
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Label _saveStatus;

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
        //if (!PlayerPrefs.HasKey("playerStarted"))
        //{
        //    _continueButton.visible = false;
        //}
        _continueButton.clicked += OnContinueClicked;

        _exitButton = _userInterface.Q<Button>("Exit");
        _exitButton.clicked += OnExitClicked;
        _saveStatus = _userInterface.Q<Label>("Status");
    }

    private void OnNewGameClicked()
    {
        _saveStatus.text = ""; //clear save status text if there was any text
        PlayerPrefs.DeleteAll();//clear old data/playerprefs
        SceneManager.LoadScene("LevelSample"); //load game level as a new game
    }

    private void OnContinueClicked()
    {
        //check if the plyer has level saved
        if (PlayerPrefs.HasKey("playerStarted")) //check if player had previous save data
        {
            _saveStatus.text = ""; //clear save status text if there was any text
            SceneManager.LoadScene("LevelSample");//load game level
        }
        else
        {
            _saveStatus.text = "No Save Game Found";
        }

    }

    private void OnExitClicked()
    {
        _saveStatus.text = "";
        Application.Quit();
    }
}
