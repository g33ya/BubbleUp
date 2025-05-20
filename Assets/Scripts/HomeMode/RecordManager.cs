using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecordManager : MonoBehaviour
{
    // UI elements for the Record-Keeping System
    public TMP_Dropdown dropdown; 
    public TMP_Text plusEnergyText;
    public TMP_Text minusStressText;
    public TMP_Text stressText;
    public TMP_Text energyText;
    public GameObject recordUI;
    public GameObject closeButton;
    public GameObject startButton;       

    // Game systems
    public TimeManager timeManager;      
    public LevelManager levelManager;

    void Start()
    {
        recordUI.SetActive(false);  // Hide the record UI at start

        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseRecordUI);
        startButton.GetComponent<Button>().onClick.AddListener(StartRecording);
    }

    // Called when player starts the record-keeping activity
    void StartRecording()
{
    int selectedIndex = dropdown.value;
    string selectedOptionString = dropdown.options[selectedIndex].text;
    int selectedTime = 0;

    if (selectedOptionString == "30 min") selectedTime = 30;
    else if (selectedOptionString == "1 hr") selectedTime = 60;
    else if (selectedOptionString == "2 hr") selectedTime = 120;
    else if (selectedOptionString == "3 hr") selectedTime = 180;
    else if (selectedOptionString == "4 hr") selectedTime = 240;

    int energyGain = (int)(selectedTime * 0.3f); // if it increases energy, skip energy check
    int stressReduction = (int)(selectedTime * 0.2f);

    int energyCost = 10; // You can change this value based on balancing

    if (!levelManager.CanDoActivity(energyCost))
    {
        return;
    }

    timeManager.AddTime(selectedTime);
    levelManager.DecreaseEnergyLevel(energyCost); // applying a fixed cost
    levelManager.IncreaseEnergyLevel(energyGain);
    levelManager.DecreaseStressLevel(stressReduction);

    recordUI.SetActive(false);
    UpdateRecordStatsDisplay();
}


    // Updates projected stat changes based on dropdown selection
    void OnDropdownValueChanged()
    {
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedTime = 0;

        if (selectedOptionString == "30 min") selectedTime = 30;
        else if (selectedOptionString == "1 hr") selectedTime = 60;
        else if (selectedOptionString == "2 hr") selectedTime = 120;
        else if (selectedOptionString == "3 hr") selectedTime = 180;
        else if (selectedOptionString == "4 hr") selectedTime = 240;

        int minusEnergy = (int)(selectedTime * 0.2f);
        int minusStress = (int)(selectedTime * 0.1f);

        plusEnergyText.text = $"- {minusEnergy} Energy";  // Change label accordingly
        minusStressText.text = $"- {minusStress} Stress";

        UpdateRecordStatsDisplay();
    }

    // Updates the UI to show the player's current stats
    void UpdateRecordStatsDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Hides the record-keeping UI
    public void CloseRecordUI()
    {
        recordUI.SetActive(false);
    }

    // Allows player to close the UI with Escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseRecordUI();
        }
    }
}
