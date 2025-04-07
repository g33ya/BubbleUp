using UnityEngine;

public class OpenCalendar : MonoBehaviour
{
    public GameObject calendarUI;

    void OnMouseDown()
    {
        calendarUI.SetActive(true);
    }
}
