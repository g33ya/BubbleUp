using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorManager : MonoBehaviour
{
    // UI elements for the Door
    public TMP_Dropdown dropdown; 
    public TMP_Text plusEnergyText;      
    public TMP_Text minusStressText;   
    public TMP_Text stressText;           
    public TMP_Text energyText;        
    public GameObject DoorUI;          
    public GameObject closeButton;      
    public GameObject startButton;      

    // Game systems
    public TimeManager timeManager;
    public LevelManager levelManager;

    void Start()
    {
        DoorUI.SetActive(false);  // Hide the door interaction UI at start

        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseDoorUI);
        startButton.GetComponent<Button>().onClick.AddListener(StartDoorAction);
    }

    // Called when the player starts using the door (e.g. exits a room, takes a break)
    void StartDoorAction()
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

        timeManager.AddTime(selectedTime); // Simulate time spent during door activity

        // Apply stat changes from door interaction
        levelManager.IncreaseEnergyLevel((int)(selectedTime * 0.3f)); 
        levelManager.DecreaseStressLevel((int)(selectedTime * 0.2f)); 

        DoorUI.SetActive(false); // Close UI after interaction

        UpdateDoorStatsDisplay();
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

        UpdateDoorStatsDisplay();
    }

    // Updates the UI to show the player's current stats
    void UpdateDoorStatsDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Hides the door interaction UI
    public void CloseDoorUI()
    {
        DoorUI.SetActive(false);
    }

    // Allows player to close the UI with Escape key
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseDoorUI();
        }
    }

    // Plays a sound effect (e.g. door creak, footstep) — will move to LogicManager later
    public void playSound(AudioSource sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}
