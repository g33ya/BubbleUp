using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    // UI elements
    public TMP_Dropdown dropdown;
    public TMP_Text plusEnergyText;     
    public TMP_Text minusStressText;    
    public TMP_Text stressText;         
    public TMP_Text energyText;         
    public GameObject BookUI;
    public GameObject closeButton;
    public GameObject startButton;

    // Game systems
    public TimeManager timeManager;
    public LevelManager levelManager;

    void Start()
    {
        BookUI.SetActive(false);

        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseBook);
        startButton.GetComponent<Button>().onClick.AddListener(StartReading);
    }

    // Starts reading and applies stat changes
    void StartReading()
    {
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedReadTime = GetMinutesFromOption(selectedOptionString);

        timeManager.AddTime(selectedReadTime); // Simulate reading time

        // Adjust stats
        levelManager.IncreaseEnergyLevel((int)(selectedReadTime * 0.3f)); // Reusing energy field for knowledge
        levelManager.DecreaseStressLevel((int)(selectedReadTime * 0.2f));

        BookUI.SetActive(false);

        UpdateStatDisplay();
    }

    // Updates projected changes when dropdown is changed
    void OnDropdownValueChanged()
    {
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedOptionNum = GetMinutesFromOption(selectedOptionString);

        int plusKnowledge = (int)(selectedOptionNum * 0.2f);
        int minusStress = (int)(selectedOptionNum * 0.3f);

        plusEnergyText.text = $"+ {plusKnowledge} Knowledge";
        minusStressText.text = $"- {minusStress} Stress";

        UpdateStatDisplay();
    }

    // Update the on-screen player stats
    void UpdateStatDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Close the book reading UI
    public void CloseBook()
    {
        BookUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseBook();
        }
    }

    // Plays a given sound
    public void PlaySound(AudioSource sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }

     // Allows player to close UI with Escape key

    // Helper function to convert dropdown text to time in minutes
    int GetMinutesFromOption(string option)
    {
        switch (option)
        {
            case "30 min": return 30;
            case "1 hr": return 60;
            case "2 hr": return 120;
            case "3 hr": return 180;
            case "4 hr": return 240;
            default: return 0;
        }
    }
}
