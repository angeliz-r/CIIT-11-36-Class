using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameSelectController : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO AN EMPY GAMEOBJECT WITH A UI DOCUMENT COMPONENT
    private VisualElement _userInterface;
    private Button _3DBtn;
    private Button _2DBtn;
    private Button _exitButton;

    private void Awake()
    {
        _userInterface = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _3DBtn = _userInterface.Q<Button>("3DLevel");
        _3DBtn.clicked += On3DClicked;
        _2DBtn = _userInterface.Q<Button>("2DLevel");
        _2DBtn.clicked += On2DClicked;
        _exitButton = _userInterface.Q<Button>("Exit");
        _exitButton.clicked += OnExitClicked;
    }

    private void On2DClicked()
    {
        PlayerPrefs.SetInt("SceneSelect", 2);
        SceneManager.LoadScene("StartScreen");
    }

    private void On3DClicked()
    {
        PlayerPrefs.SetInt("SceneSelect", 3);
        SceneManager.LoadScene("StartScreen");
    }

    private void OnExitClicked()
    {
        Application.Quit();
    }
}
