using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    // Game systems
    public TimeManager timeManager;
    public LevelManager levelManager;

    // Fade-to-black Panel
    public Image fadePanel;
    private float fadeDuration = 1f;

    void Start()
    {
        BedUI.SetActive(false);
        fadePanel.color = new Color(0, 0, 0, 0);

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

        timeManager.AddTime(selectedSleepTime); // Simulate time passing - Gia

        // Energy gain & stress relief
        levelManager.IncreaseEnergyLevel((int)(selectedSleepTime * 0.3f)); 
        levelManager.DecreaseStressLevel((int)(selectedSleepTime * 0.2f)); 

        BedUI.SetActive(false);
        HandleSleepWithFade();
    }

    void OnDropdownValueChanged()
    {
        int selectedIndex = dropdown.value;
        string selectedOptionString = dropdown.options[selectedIndex].text;
        int selectedOptionNum = 0;

        if (selectedOptionString == "30 min") selectedOptionNum = 30;
        else if (selectedOptionString == "1 hr") selectedOptionNum = 60;
        else if (selectedOptionString == "2 hr") selectedOptionNum = 120;
        else if (selectedOptionString == "3 hr") selectedOptionNum = 180;
        else if (selectedOptionString == "4 hr") selectedOptionNum = 240;

        int plusEnergy = (int)(selectedOptionNum * 0.2f);
        int minusStress = (int)(selectedOptionNum * 0.3f);

        plusEnergyText.text = $"+ {plusEnergy} Energy";
        minusStressText.text = $"- {minusStress} Stress";

        UpdateSleepTextDisplay();
    }

    IEnumerator HandleSleepWithFade()
    {
        yield return StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeOut());

        UpdateSleepTextDisplay();
    }

    // Fade IN/Out screen to black - Help with ChatGPT
    IEnumerator FadeIn()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
    
    IEnumerator FadeOut()
    {
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(t / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
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
