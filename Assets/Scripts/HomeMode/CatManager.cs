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

        timeManager.AddTime(selectedTime); // Simulate time spent with the cat

        // Apply stat changes from cat time
        levelManager.IncreaseEnergyLevel((int)(selectedTime * 0.3f)); 
        levelManager.DecreaseStressLevel((int)(selectedTime * 0.2f)); 
        PlayerPrefs.SetInt("EnergyLevel", levelManager.energyLevel); // Save energy level
        PlayerPrefs.SetInt("StressLevel", levelManager.stressLevel); // Save stress level
        PlayerPrefs.Save(); // Save changes to PlayerPrefs

        CatUI.SetActive(false); // Close UI after interaction

        UpdateCatStatsDisplay();
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

        int plusEnergy = (int)(selectedTime * 0.2f);
        int minusStress = (int)(selectedTime * 0.3f);

        plusEnergyText.text = $"+ {plusEnergy} Energy";
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

    // Plays a sound effect (will be moved to LogicManager later)
    public void playSound(AudioSource sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}
