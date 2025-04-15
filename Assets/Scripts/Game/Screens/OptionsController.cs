using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OptionsController : MonoBehaviour
{
    //THIS SCRIPT IS ATTACHED TO AN EMPY GAMEOBJECT WITH A UI DOCUMENT COMPONENT
    //public bool is2dLevel;
    private VisualElement _userInterface;
    private Button _mainMenuButton;
    private Slider _BGMSlider,_SFXSlider;

    private void Awake()
    {
        _userInterface = GetComponent<UIDocument>().rootVisualElement;
    }

    private void OnEnable()
    {
        _mainMenuButton = _userInterface.Q<Button>("Back");
        _mainMenuButton.clicked += OnMenuClicked;

        _BGMSlider = _userInterface.Q<Slider>("BGM");
        _SFXSlider = _userInterface.Q<Slider>("SFX");
        _BGMSlider.RegisterValueChangedCallback(value =>
        {
            AudioManager.Instance.AdjustBGMVol(value.newValue);
        });
        _SFXSlider.RegisterValueChangedCallback(value =>
        {
            AudioManager.Instance.AdjustSFXVol(value.newValue);
        });
    }

    private void OnMenuClicked()
    {
        AudioManager.Instance.PlaySFX("button");
        SceneManager.LoadScene("StartScreen");
    }

    private void Update()
    {
    }
}
