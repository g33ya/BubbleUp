using UnityEngine;

public class CupButtonSpawner : MonoBehaviour
{
     public GameObject cupPrefab;    
    public Transform spawnPoint;   

     public static GameObject currentCup;
    //private bool hasSpawned = false;

    public void SpawnCup(){
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
