using UnityEngine;

// This script spawns a new cup when the player clicks the cup button
// It prevents multiple cups from being spawned at once

public class CupButtonSpawner : MonoBehaviour
{
    public GameObject cupPrefab; //The cup prefab to be spawned 
    public Transform spawnPoint;  //The position in the scene where the new cup will appear

    // A static reference to the currently spawned cup (shared across scripts)
    public static GameObject currentCup;


   public void SpawnCup()
{
    if (currentCup == null && cupPrefab != null && spawnPoint != null)
    {
        currentCup = Instantiate(cupPrefab, spawnPoint.position, Quaternion.identity);
        Debug.Log("Spawned: " + cupPrefab.name);
    }
}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (currentCup == null)
        {
            
        }
    }
}
