using UnityEngine;

public class CupButtonSpawner : MonoBehaviour
{
     public GameObject cupPrefab;    
    public Transform spawnPoint;    
    private bool hasSpawned = false;

    public void SpawnCup(){
    if (!hasSpawned && cupPrefab != null && spawnPoint != null)
        {
            Instantiate(cupPrefab, spawnPoint.position, Quaternion.identity);
            hasSpawned = true;
            Debug.Log("🧋 Spawned: " + cupPrefab.name);
        }  
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
