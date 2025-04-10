using UnityEngine;

public class Assignment
{
    public string name { get; set; }
    public int progressRequired { get; set; }
    public int currentProgress { get; set; }

    public Assignment(string name, int progressRequired)
    {
        this.name = name;
        this.progressRequired = progressRequired;
        currentProgress = 0;
    }

    public void UpdateProgress(int progressIncrease)
    {
        currentProgress += progressIncrease;
        if (currentProgress > 100)
            currentProgress = 100; 
        else if (currentProgress < 0f)
            currentProgress = 0; 
    }

    public bool IsComplete()
    {
        return currentProgress >= 100;
    }
}