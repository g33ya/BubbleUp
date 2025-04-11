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

    // Fade-to-black panel information
    public Image fadePanel;
    private float fadeDuration = 1f;

    void Start()
    {
        BedUI.SetActive(false);

        // Hook up button clicks
        dropdown.onValueChanged.AddListener(delegate { UpdateSleepPreview(); });
        closeButton.GetComponent<Button>().onClick.AddListener(CloseSleep);
        startButton.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(HandleSleepWithFade()));

        // Set initial values
        BedUI.SetActive(false);
        fadePanel.color = new Color(0, 0, 0, 0); // Fully transparent at start
    }

    // This runs when the player hits the sleep "Start" button
    IEnumerator HandleSleepWithFade()
    {
        int sleepTime = GetSelectedSleepTime();

        // Fade to black
        yield return StartCoroutine(FadeIn());

        // Simulate sleep effects
        timeManager.AddTime(sleepTime);
        levelManager.IncreaseEnergyLevel((int)(sleepTime * 0.2f));
        levelManager.DecreaseStressLevel((int)(sleepTime * 0.3f));

        UpdateSleepTextDisplay();

        // Wait for 1 second while screen is black
        yield return new WaitForSeconds(1f);

        // Fade back to normal
        yield return StartCoroutine(FadeOut());

        // Close the sleep UI
        BedUI.SetActive(false);
    }

    // Fade IN/Out screen to black - Heavily Credited to ChatGPT
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

    // Updates the "+Energy" and "-Stress" preview text
    void UpdateSleepPreview()
    {
        int time = GetSelectedSleepTime();
        plusEnergyText.text = $"+ {(int)(time * 0.2f)} Energy";
        minusStressText.text = $"- {(int)(time * 0.3f)} Stress";
        UpdateSleepTextDisplay();
    }

    // Gets the number of minutes from the dropdown selection
    int GetSelectedSleepTime()
    {
        string label = dropdown.options[dropdown.value].text;

        return label switch
        {
            "30 min" => 30,
            "1 hr" => 60,
            "2 hr" => 120,
            "3 hr" => 180,
            "4 hr" => 240,
            _ => 0
        };
    }

    // Updates the player's main stats
    void UpdateSleepTextDisplay()
    {
        stressText.text = "Stress: " + levelManager.stressLevel;
        energyText.text = "Energy: " + levelManager.energyLevel;
    }

    // Hides the sleep menu
    public void CloseSleep()
    {
        BedUI.SetActive(false);
    }

    // Press ESC to exit sleep menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseSleep();
        }
    }
}
