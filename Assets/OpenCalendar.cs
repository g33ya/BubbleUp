using UnityEngine;

public class CalendarOpener : MonoBehaviour
{
    public GameObject calendarUI;

    void OnMouseDown()
    {
        calendarUI.SetActive(true);
    }
}
