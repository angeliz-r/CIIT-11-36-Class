using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIButtons : MonoBehaviour
{
    public TextMeshProUGUI textToChange;
    private bool _pressed;
    public void PressTheButton ()
    {
        if (!_pressed)
        {
            textToChange.text = "The button has been clicked!";
            _pressed = true;
        }
        else
        {
            textToChange.text = "GAME TITLE";
            _pressed = false;
        }
        Debug.Log("Clicked!");
    }

}
