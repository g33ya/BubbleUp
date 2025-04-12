using UnityEngine;

public class OpenCalendar : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject computerUI;
    public GameObject bedUI;

    void OnMouseDown()
    {
        if (!computerUI.activeSelf && !bedUI.activeSelf)
        {
            calendarUI.SetActive(true);
        }
    }
}
