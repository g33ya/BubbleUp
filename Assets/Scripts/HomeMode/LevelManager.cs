using TMPro;
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int energyLevel;
    public int stressLevel;
    public TMP_Text energyLevelText;
    public TMP_Text stressLevelText;

    public void IncreaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // max level
        {
            energyLevel = 100;
        }
        StartCoroutine(DelayedEnergyDisplay()); // Update energy level text
    }

    public void DecreaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // min level
        {
            energyLevel = 100;
        }
        StartCoroutine(DelayedEnergyDisplay()); // Update energy level text
    }

    public void IncreaseStressLevel(int amount)
    {
        stressLevel += amount;
        if (stressLevel > 100) // max level
        {
            stressLevel = 100;
        }
        StartCoroutine(DelayedStressDisplay()); // Update stress level text
    }

    public void DecreaseStressLevel(int amount)
    {
        stressLevel -= amount;
        if (stressLevel < 0) // min level
        {
            stressLevel = 0;
        }
        StartCoroutine(DelayedStressDisplay()); // Update stress level text
    }

    public void UpdateEnergyLevelText()
    {
        energyLevelText.text = "Energy: " + PlayerPrefs.GetInt("EnergyLevel").ToString();
    }

    public void UpdateStressLevelText()
    {
        stressLevelText.text = "Stress: " + PlayerPrefs.GetInt("StressLevel").ToString();
    }

    private IEnumerator DelayedStressDisplay()
    {
        // Wait for 1 second before updating the time display
        yield return new WaitForSeconds(1f);
        UpdateStressLevelText(); // Update stress level text
    }

    private IEnumerator DelayedEnergyDisplay()
    {
        // Wait for 1 second before updating the time display
        yield return new WaitForSeconds(1f);
        UpdateEnergyLevelText(); // Update stress level text
    }

    void Start()
    {
        energyLevel = 50; // Initial energy level
        stressLevel = 20; // Initial stress level
        UpdateEnergyLevelText();
        UpdateStressLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
