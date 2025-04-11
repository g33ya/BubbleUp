using UnityEngine;

public class OpenCalendar : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject computerUI;

    void OnMouseDown()
    {
        if (!computerUI.activeSelf)
        {
            calendarUI.SetActive(true);
        }
    }
}
