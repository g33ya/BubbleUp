using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    Assignment assignment1;

    public Button startWorkingButton;
    public TMP_Dropdown dropdown; // Used to get duration to work on assignment
    public TMP_Text currentProgressText; // Used to display current progress of assignment
    public TMP_Text plusProgressText; 
    public TMP_Text plusStressText;
    public TMP_Text minusSleepText;
    public TMP_Text stressText; // Used to display stress level of the player
    public TMP_Text energyText;
    public GameObject computerUI;
    public GameObject closeButton1;
    public GameObject closeButton2;
    public GameObject dayPanel; 
    public GameObject assignmentPanel;
    public Button initialWorkOnButton;
    public TimeManager timeManager; 
    public LevelManager levelManager; // Reference to the LevelManager script
    public TMP_Text notEnoughEnergyText; // Text to display when not enough energy
    public TMP_Text tooStressedText; // Text to display when not enough energy
    public TMP_Text assignmentCompleteText; // Text to display the name of the assignment


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
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedOptionNum = 0;

        if (selectedOptionString == "30 min") selectedOptionNum = 30;
        else if (selectedOptionString == "1 hr") selectedOptionNum = 60;
        else if (selectedOptionString == "2 hr") selectedOptionNum = 120;
        else if (selectedOptionString == "3 hr") selectedOptionNum = 180;
        else if (selectedOptionString == "4 hr") selectedOptionNum = 240;

        if (levelManager.energyLevel - (selectedOptionNum * 0.2) <= 0)
        {
            startWorkingButton.interactable = false; // Disable the button if not enough energy
            notEnoughEnergyText.gameObject.SetActive(true); 
            if (levelManager.stressLevel + (selectedOptionNum * 0.4) >= 100){
                tooStressedText.gameObject.SetActive(true); 
            }
            return; 
        }

        if (levelManager.stressLevel + (selectedOptionNum * 0.4) >= 100)
        {
            startWorkingButton.interactable = false; // Disable the button if not enough energy
            tooStressedText.gameObject.SetActive(true); 
            if (levelManager.energyLevel - (selectedOptionNum * 0.2) <= 0){
                notEnoughEnergyText.gameObject.SetActive(true); 
            }
            return; 
        }
        

        timeManager.AddTime(selectedOptionNum); // Add time to the time manager

        assignment1.currentProgress += (int)(selectedOptionNum * 0.3f); // Increase progress of the assignment
        

        if (assignment1.currentProgress >= 100)
        {
            assignment1.currentProgress = 100;
            initialWorkOnButton.interactable = false; // Lock the button (disable interaction)
            assignmentCompleteText.gameObject.SetActive(true);
        }
        UpdateCurrentProgressDisplay();

        levelManager.DecreaseEnergyLevel((int)(-selectedOptionNum * 0.2f)); // Decrease energy level
        levelManager.IncreaseStressLevel((int)(selectedOptionNum * 0.4f)); // Increase stress level
        
        
        computerUI.SetActive(false);
        assignmentPanel.SetActive(false); // Show the assignment panel after working on the assignment
    }

    void OnDropdownValueChanged()
    {
        startWorkingButton.interactable = true;
        notEnoughEnergyText.gameObject.SetActive(false);
        tooStressedText.gameObject.SetActive(false);

        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedOptionNum = 0;

        if (selectedOptionString == "30 min") selectedOptionNum = 30;
        else if (selectedOptionString == "1 hr") selectedOptionNum = 60;
        else if (selectedOptionString == "2 hr") selectedOptionNum = 120;
        else if (selectedOptionString == "3 hr") selectedOptionNum = 180;
        else if (selectedOptionString == "4 hr") selectedOptionNum = 240;

        int plusProgress = (int)(selectedOptionNum * .3f);
        int minusSleep = (int)(selectedOptionNum * .2f);
        int plusStress = (int)(selectedOptionNum * .4f);

        plusProgressText.text = $"+ {plusProgress}% Progress";
        minusSleepText.text = $"- {minusSleep} Energy";
        plusStressText.text = $"+ {plusStress} Stress";
        
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
        assignmentPanel.SetActive(false); 
    }
}