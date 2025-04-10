using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int energyLevel;
    public int stressLevel;
    public TMP_Text energyLevelText;
    public TMP_Text stressLevelText;


    void IncreaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // max level
        {
            energyLevel = 100;
        }
        UpdateEnergyLevelText();
    }

    void DecreaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // min level
        {
            energyLevel = 100;
        }
        UpdateEnergyLevelText();
    }

    void IncreaseStressLevel(int amount)
    {
        stressLevel += amount;
        if (stressLevel > 100) // max level
        {
            stressLevel = 100;
        }
        UpdateStressLevelText();
    }

    void DecreaseStressLevel(int amount)
    {
        stressLevel -= amount;
        if (stressLevel < 0) // min level
        {
            stressLevel = 0;
        }
        UpdateStressLevelText();
    }

    void UpdateEnergyLevelText()
    {
        energyLevelText.text = "Energy Level: " + energyLevel.ToString();
    }

    void UpdateStressLevelText()
    {
        stressLevelText.text = "Stress Level: " + stressLevel.ToString();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
