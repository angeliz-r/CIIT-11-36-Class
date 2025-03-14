using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MainMenuController : MonoBehaviour
{
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
        _newGameButton = _userInterface.Q<Button>("NewGame");
        _newGameButton.clicked += OnNewGameClicked;

        _continueButton = _userInterface.Q<Button>("Continue");
        _continueButton.clicked += OnContinueClicked;

        _exitButton = _userInterface.Q<Button>("Exit");
        _exitButton.clicked += OnExitClicked;
        _saveStatus = _userInterface.Q<Label>("Status");
    }

    private void OnNewGameClicked()
    {
        _saveStatus.text = "";
        PlayerPrefs.DeleteAll();//clear old data
        SceneManager.LoadScene("LevelSample"); //load game level
    }

    private void OnContinueClicked()
    {
        //check if the plyer has level saved
        if (PlayerPrefs.HasKey("playerStarted"))
        {
            _saveStatus.text = "";
            SceneManager.LoadScene("LevelSample");
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
