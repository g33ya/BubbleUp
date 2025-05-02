using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CalendarManager : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject computerUI;
    public GameObject assignmentListScreen;

    public GameObject closeButton;
    public TMP_Text assignmentNumText;
    public TMP_Text assignmentCurrentProgress;
    public Button thursdayButton;
    public Button sundayButton;

    void Start()
    {
        Debug.Log("CalendarManager started"); // Debug log to check if the script is running
        closeButton.GetComponent<Button>().onClick.AddListener(CloseCalendar);
        thursdayButton.GetComponent<Button>().onClick.AddListener(OpenComputer);
        sundayButton.GetComponent<Button>().onClick.AddListener(OpenComputer);

        calendarUI.SetActive(false);
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

    public void OpenComputer()
    {
        Debug.Log("OpenComputer called"); // Debug log to check if the method is called
        calendarUI.SetActive(false);
        computerUI.SetActive(true);
        assignmentListScreen.SetActive(true);
    }
}
