using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int energyLevel;
    public int stressLevel;

    void increaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // max level
        {
            energyLevel = 100;
        }
    }

    void decreaseEnergyLevel(int amount)
    {
        energyLevel -= amount;
        if (energyLevel < 0) // min level
        {
            energyLevel = 0;
        }
    }

    void increaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // max level
        {
            energyLevel = 100;
        }
    }

    void decreaseEnergyLevel(int amount)
    {
        energyLevel += amount;
        if (energyLevel > 100) // min level
        {
            energyLevel = 100;
        }
    }

    void increaseStressLevel(int amount)
    {
        stressLevel += amount;
        if (stressLevel > 100) // max level
        {
            stressLevel = 100;
        }
    }

    void decreaseStressLevel(int amount)
    {
        stressLevel -= amount;
        if (stressLevel < 0) // min level
        {
            stressLevel = 0;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
