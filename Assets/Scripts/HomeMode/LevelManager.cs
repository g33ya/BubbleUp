using TMPro;
using UnityEngine;

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
        UpdateEnergyLevelText();
    }

    public void DecreaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // min level
        {
            energyLevel = 100;
        }
        UpdateEnergyLevelText();
    }

    public void IncreaseStressLevel(int amount)
    {
        stressLevel += amount;
        if (stressLevel > 100) // max level
        {
            stressLevel = 100;
        }
        UpdateStressLevelText();
    }

    public void DecreaseStressLevel(int amount)
    {
        stressLevel -= amount;
        if (stressLevel < 0) // min level
        {
            stressLevel = 0;
        }
        UpdateStressLevelText();
    }

    public void UpdateEnergyLevelText()
    {
        energyLevelText.text = "Energy: " + energyLevel.ToString();
    }

    public void UpdateStressLevelText()
    {
        stressLevelText.text = "Stress: " + stressLevel.ToString();
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
