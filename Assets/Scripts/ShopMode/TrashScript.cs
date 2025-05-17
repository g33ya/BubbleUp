using UnityEngine;

// This script handles trashing (deleting) cups when they enter the trash area

public class TrashScript : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D trash)
    {
        // Check if the object entering the trigger has the tag "cup"
        // OR if it has the SealedCup component (which marks it as a sealed drink)
        if (trash.CompareTag("cup") || trash.GetComponent<SealedCup>() != null)
        {
            Destroy(trash.gameObject);
            Debug.Log("🗑️ cup trashed!"); //this just used for debugging
        }
    }
    
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }
    bool isNearCup = false;
    // Update is called once per frame
    void Update()
    {
        if(isNearCup){
            //will make trash hightlight
        }
    }

}
