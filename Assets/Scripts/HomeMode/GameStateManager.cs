using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public int energyLevel;
    public int stressLevel;

    public Assignment assignment1;
    public Assignment assignment2;

    private void Awake()
    {
        assignment1 = new Assignment("Assignment 1", 180);
        assignment2 = new Assignment("Assignment 2", 225);
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
}
