using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Allows for a script to show/hide Text Mesh Pro text.
/// Set Start Active to true if the text should begin shown, or set
/// it to false if the text should begin hidden. Call Toggle() to activate/deactivate
/// the text.
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class ToggleText : MonoBehaviour
{
    [Tooltip("Whether the text should start showing.")]
    public bool startActive = false;
    private TextMeshProUGUI textToToggle; // TMPro object to modify
    private string textContent; // String to hold onto the text

    // Start is called before the first frame update
    void Start()
    {
        textToToggle = GetComponent<TextMeshProUGUI>();
        textContent = textToToggle.text;

        if (!startActive) {
            textToToggle.SetText("");
        }
    }

    /// <summary>
    /// Shows the text if it is hidden, or hides it if it is showing.
    /// </summary>
    public void Toggle() 
    {
        if (textToToggle.text == "") {
            textToToggle.SetText(textContent);
        } else {
            textToToggle.SetText("");
        }
    }
}
