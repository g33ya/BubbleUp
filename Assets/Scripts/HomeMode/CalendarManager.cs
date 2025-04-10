using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject closeButton;
    public TMP_Text assignmentNumText;
    public TMP_Text assignmentCurrentProgress;

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

        if (assignmentCurrentProgress.text == "Current Progress: 100%")
        {
            assignmentNumText.text = "0";
        }
    }

    public void CloseCalendar()
    {
        calendarUI.SetActive(false);
    }
}
