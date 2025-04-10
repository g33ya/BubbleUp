using UnityEngine;

public class Assignment
{
    public string name { get; set; }
    public int timeRequired { get; set; }
    public int currentProgress { get; set; }

    public Assignment(string name, int timeRequired, int currentProgress)
    {
        this.name = name;
        this.timeRequired = timeRequired;
        this.currentProgress = currentProgress;
    }

    public bool IsComplete()
    {
        return currentProgress >= 100;
    }
}