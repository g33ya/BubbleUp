using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class SleepManager : MonoBehaviour
{
    // UI elements
    public TMP_Dropdown dropdown; 
    public TMP_Text plusEnergyText;
    public TMP_Text minusStressText;
    public TMP_Text stressText;
    public TMP_Text energyText;
    public GameObject BedUI;
    public GameObject closeButton;
    public GameObject startButton;

    public AudioClip dreamSound;

    // Game systems
    public TimeManager timeManager;
    public LevelManager levelManager;

    void Start()
    {
        BedUI.SetActive(false);

        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseSleep);
        startButton.GetComponent<Button>().onClick.AddListener(StartSleep);
    }

    void StartSleep(){
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedSleepTime = 0;

        if (selectedOptionString == "30 min") selectedSleepTime = 30;
        else if (selectedOptionString == "1 hr") selectedSleepTime = 60;
        else if (selectedOptionString == "2 hr") selectedSleepTime = 120;
        else if (selectedOptionString == "3 hr") selectedSleepTime = 180;
        else if (selectedOptionString == "4 hr") selectedSleepTime = 240;
        else if (selectedOptionString == "End of Day") {
            levelManager.IncreaseEnergyLevel(50);
            levelManager.DecreaseStressLevel(40);
        
            BedUI.SetActive(false);
            SoundPlayer.instance.PlaySFX(dreamSound);
            timeManager.StartCoroutine(timeManager.FadeInOutWithScene("Shop 2 Tuesday"));

            //SceneManager.LoadScene("Shop 2 Tuesday"); //Need to talk to Taylor About the Scene Change
            return;
        }

        timeManager.AddTime(selectedSleepTime); // Simulate time passing - Gia

        // Energy & Stress Stat Change
        levelManager.IncreaseEnergyLevel((int)(selectedSleepTime * 0.3f)); 
        levelManager.DecreaseStressLevel((int)(selectedSleepTime * 0.2f)); 

        BedUI.SetActive(false);
        UpdateSleepTextDisplay();
    }

    void OnDropdownValueChanged()
    {
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedOptionNum = 0;
        int plusEnergy;
        int minusStress;

        if (selectedOptionString == "30 min") selectedOptionNum = 30;
        else if (selectedOptionString == "1 hr") selectedOptionNum = 60;
        else if (selectedOptionString == "2 hr") selectedOptionNum = 120;
        else if (selectedOptionString == "3 hr") selectedOptionNum = 180;
        else if (selectedOptionString == "4 hr") selectedOptionNum = 240;
        else if (selectedOptionString == "End of Day"){
            plusEnergy = 50;  // Custom boost
            minusStress = 40; // Custom stress reduction

            plusEnergyText.text = $"+ {plusEnergy} Energy";
            minusStressText.text = $"- {minusStress} Stress";
            UpdateSleepTextDisplay();
            return;
        }

        plusEnergy = (int)(selectedOptionNum * 0.2f);
        minusStress = (int)(selectedOptionNum * 0.3f);

        plusEnergyText.text = $"+ {plusEnergy} Energy";
        minusStressText.text = $"- {minusStress} Stress";

        UpdateSleepTextDisplay();
    }

    // Updates the player's Stats
    void UpdateSleepTextDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Hides the Sleep Menu
    public void CloseSleep()
    {
        BedUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseSleep();
        }
    }
}