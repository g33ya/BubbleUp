using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JournalManager : MonoBehaviour
{
    // UI elements for the Journaling System
    public TMP_Dropdown dropdown; 
    public TMP_Text plusEnergyText;
    public TMP_Text minusStressText;
    public TMP_Text stressText;
    public TMP_Text energyText;
    public GameObject JournalUI;
    public GameObject closeButton; 
    public GameObject startButton;

    // Game systems
    public TimeManager timeManager;
    public LevelManager levelManager;

    void Start()
    {
        JournalUI.SetActive(false);  // Hide the journal UI at start

        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseJournalUI);
        startButton.GetComponent<Button>().onClick.AddListener(StartJournaling);
    }

    // Called when player begins a journaling session
    void StartJournaling()
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

        timeManager.AddTime(selectedTime); // Simulate time spent journaling

        // Apply stat changes from journaling
        levelManager.IncreaseEnergyLevel((int)(selectedTime * 0.3f)); 
        levelManager.DecreaseStressLevel((int)(selectedTime * 0.2f)); 
        PlayerPrefs.SetInt("EnergyLevel", levelManager.energyLevel); // Save energy level
        PlayerPrefs.SetInt("StressLevel", levelManager.stressLevel); // Save stress level
        PlayerPrefs.Save(); // Save changes to PlayerPrefs

        JournalUI.SetActive(false); // Close UI after journaling

        UpdateJournalStatsDisplay();
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

        UpdateJournalStatsDisplay();
    }

    // Updates the UI to show the player's current stats
    void UpdateJournalStatsDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Hides the journaling UI
    public void CloseJournalUI()
    {
        JournalUI.SetActive(false);
    }

    // Allows player to close the UI with Escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseJournalUI();
        }
    }

    // Plays a sound effect (e.g. page turning) — will move to LogicManager later
    public void playSound(AudioSource sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}
