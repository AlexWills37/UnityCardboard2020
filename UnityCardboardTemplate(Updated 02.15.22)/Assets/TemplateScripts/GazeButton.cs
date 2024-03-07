using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Connects the GazeOverEvent script with a Unity Button component.
/// After attaching this script to a button, adjust the Maximum Angle For Event to best
/// fit the size of the button.
/// When hovering over the button, this script will use the Button's "Selected Color".
/// When not looking at the button, it should return to the Button's "Normal Color".
/// When clicking while hovering over the button, the button's On Click event will be called.
/// </summary>
[RequireComponent(typeof(GazeOverEvent))]
[RequireComponent(typeof(Button))]
public class GazeButton : MonoBehaviour
{
    private Button button;
    private GazeOverEvent gazeControlScript;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gazeControlScript = GetComponent<GazeOverEvent>();
        
        gazeControlScript.OnHoverBegin.AddListener(SelectButton);
        gazeControlScript.OnHoverEnd.AddListener(DeselectButton);
        gazeControlScript.OnButtonPressedDuringHover.AddListener(ClickButton);
    }

    private void SelectButton() {
        EventSystem.current.SetSelectedGameObject(button.gameObject);
    }

    private void DeselectButton() {
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void ClickButton() {
        button.onClick.Invoke();
    }
}
