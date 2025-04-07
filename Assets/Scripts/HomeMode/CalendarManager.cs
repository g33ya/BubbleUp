using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject closeButton;

    void Start()
    {
        calendarUI.SetActive(false);
        closeButton.GetComponent<Button>().onClick.AddListener(CloseCalendar);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // close on escape key press
        {
            CloseCalendar();
        }
    }

    public void CloseCalendar()
    {
        calendarUI.SetActive(false);
    }
}
