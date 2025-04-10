using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    Assignment assignment1;

    public Button startWorkingButton;
    public TMP_Dropdown dropdown; // Used to get duration to work on assignment
    public TMP_Text currentProgressText; // Used to display current progress of assignment
    public TMP_Text predictedProgressText; // Used to display current progress of assignment
    public TMP_Text stressText; // Used to display stress level of the player
    public TMP_Text energyText;
    public GameObject computerUI;
    public GameObject closeButton1;
    public GameObject closeButton2;
    public GameObject dayPanel; 
    public GameObject assignmentPanel;
    public Button initialWorkOnButton;

    void Start()
    {
        assignment1 = new Assignment("Assignment 1", 180);

        startWorkingButton.onClick.AddListener(OnButtonClick);
        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton1.GetComponent<Button>().onClick.AddListener(CloseComputer);
        closeButton2.GetComponent<Button>().onClick.AddListener(CloseComputer);
        initialWorkOnButton.onClick.AddListener(OnInitialWorkClick);

 
        computerUI.SetActive(false);
        UpdateCurrentProgressDisplay();
    }

    void OnInitialWorkClick()
    {
        dayPanel.SetActive(false);
        assignmentPanel.SetActive(true);
    }

    void OnButtonClick()
    {
        int selectedIndex = dropdown.value;
        string selectedOption = dropdown.options[selectedIndex].text;

        if (selectedOption == "30 min") assignment1.UpdateProgress(10);
        else if (selectedOption == "1 hr") assignment1.UpdateProgress(20);
        else if (selectedOption == "2 hr") assignment1.UpdateProgress(40);
        else if (selectedOption == "3 hr") assignment1.UpdateProgress(60);
        else if (selectedOption == "4 hr") assignment1.UpdateProgress(80);

        UpdateCurrentProgressDisplay();
        computerUI.SetActive(false);
    }

    void OnDropdownValueChanged()
    {
        int selectedIndex = dropdown.value;
        string selectedOption = dropdown.options[selectedIndex].text;

        int predictedProgress = 0;
        if (selectedOption == "30 min") predictedProgress = 10;
        else if (selectedOption == "1 hr") predictedProgress = 20;
        else if (selectedOption == "2 hr") predictedProgress = 40;
        else if (selectedOption == "3 hr") predictedProgress = 60;
        else if (selectedOption == "4 hr") predictedProgress = 80;

        predictedProgressText.text = $"Predicted Progress: {predictedProgress}%";
    }

    void UpdateCurrentProgressDisplay()
    {   
        int progressPercent = assignment1.currentProgress;
        currentProgressText.text = "Current Progress: " + progressPercent + "%";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseComputer();
        }
    }

    public void CloseComputer()
    {
        computerUI.SetActive(false);
    }
}
