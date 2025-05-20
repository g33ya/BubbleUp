using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatManager : MonoBehaviour
{
    // UI elements for the Cat Interaction System
    public TMP_Dropdown dropdown; 
    public TMP_Text plusEnergyText;
    public TMP_Text minusStressText;
    public TMP_Text stressText;
    public TMP_Text energyText;
    public GameObject CatUI;
    public GameObject closeButton;
    public GameObject startButton;

    // Game systems
    public TimeManager timeManager;
    public LevelManager levelManager;
    void Start()
    {
        CatUI.SetActive(false);  // Hide the cat interaction UI at start

        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseCatUI);
        startButton.GetComponent<Button>().onClick.AddListener(StartCatTime);
    }

    // Called when player starts spending time with the cat
    void StartCatTime()
    {
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedTime = 0;

        // Convert dropdown selection to minutes
        if (selectedOptionString == "30 min") selectedTime = 30;
        else if (selectedOptionString == "1 hr") selectedTime = 60;
        else if (selectedOptionString == "2 hr") selectedTime = 120;
        else if (selectedOptionString == "3 hr") selectedTime = 180;
        else if (selectedOptionString == "4 hr") selectedTime = 240;

        int energyCost = (int)(selectedTime * 0.03f);

        // Check if the player has enough energy
        if (!levelManager.CanDoActivity(energyCost))
        {
            return; // Exit early if too tired
        }

        timeManager.AddTime(selectedTime); // Simulate time spent with the cat

        // Apply stat changes
        levelManager.DecreaseEnergyLevel(energyCost);                    // slight energy drop
        levelManager.DecreaseStressLevel((int)(selectedTime * 0.41f));  // big stress relief

        CatUI.SetActive(false); // Close the cat interaction UI

        UpdateCatStatsDisplay(); // Refresh stats on screen
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

        int minusEnergy = (int)(selectedTime * 0.03f);
        int minusStress = (int)(selectedTime * 0.41f);

        plusEnergyText.text = $"- {minusEnergy} Energy";
        minusStressText.text = $"- {minusStress} Stress";


        UpdateCatStatsDisplay();
    }

    // Updates the UI to show the player's current stats
    void UpdateCatStatsDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Hides the cat interaction UI
    public void CloseCatUI()
    {
        CatUI.SetActive(false);
    }

    // Allows player to close UI with Escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCatUI();
        }
    }

}
