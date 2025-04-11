using UnityEngine;

public class PourScript : MonoBehaviour

{
   public GameObject inProgressCupPrefab;


    private void OnTriggerEnter2D(Collider2D inProgressCup)
    {
        //only react if we touch this cup
        if(inProgressCup.CompareTag("cup")){
            Vector3 cupPosition = inProgressCup.transform.position;
            Destroy(inProgressCup.gameObject);
            Instantiate(inProgressCupPrefab, cupPosition, Quaternion.identity); //this spawns the 'poured' cup
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
