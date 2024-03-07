using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// A timer that counts down in seconds. To use, add this script to a game object and
/// set the Timer Value in the inspector. Check "Start On Awake" to start the timer immediately,
/// or call the timer's StartTimer() method to begin the countdown. To display the countdown,
/// add a Text Mesh Pro Text object in the inspector. When the timer finishes, the
/// OnTimerComplete event will be called.
/// </summary>
public class CountdownTimer : MonoBehaviour
{
    [Tooltip("How long (seconds) the timer is set for.")]
    public float timerValue = 60f;

    [Tooltip("Whether the timer should start counting down immediately.")]
    public bool startOnAwake = true;
    public TextMeshProUGUI timerText = null;

    // Unity Event occurs when the timer hits 0
    public UnityEvent OnTimerComplete;


    private bool timerActive = false;
    private int timerIntValue;  // Used to update the timer's text object every second (and not every frame)

    // Awake is called before Start, before the first frame update
    void Awake()
    {
        if (startOnAwake)
        {
            timerActive = true;
            timerIntValue = (int)timerValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive) {
            timerValue -= Time.deltaTime;

            // Timer complete
            if (timerValue <= 0) {
                OnTimerComplete.Invoke();
                timerValue = 0;
                timerActive = false;
            }

            // timerIntValue will be rounded down to the second
            if (timerValue < timerIntValue) {
                timerIntValue = (int)timerValue;    
                timerText?.SetText("" + timerIntValue); // Update the text if it is set in the inspector
            }
        }
    }

    /// <summary>
    /// Starts the countdown timer from its currently set Timer Value.
    /// </summary>
    public void StartTimer()
    {
        timerActive = true;
    }
}
