using UnityEngine;

using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public TMP_Text timeText;
    private int hour = 19; // 7 PM
    private int minute = 0;

    void Start()
    {
        UpdateTimeDisplay();
    }

    public void AddTime(int minutesToAdd)
    {
        minute += minutesToAdd;
        while (minute >= 60)
        {
            minute -= 60;
            hour += 1;
        }
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        string suffix = hour >= 12 ? "PM" : "AM";
        int displayHour = hour % 12;
        if (displayHour == 0) displayHour = 12;

        timeText.text = displayHour.ToString("0") + ":" + minute.ToString("00") + " " + suffix;
    }
}

