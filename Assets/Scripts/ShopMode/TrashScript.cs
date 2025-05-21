using System;
using UnityEngine;

// This script handles trashing (deleting) cups when they enter the trash area

public class TrashScript : MonoBehaviour
{
      public TrashConfirmUI confirmUI; 

    // This method is automatically called by Unity when another object enters the trash trigger zone
    private void OnTriggerEnter2D(Collider2D trash)
    {
        // Check if the object entering the trigger has the tag "cup"
        // OR if it has the SealedCup component (which marks it as a sealed drink)
        if (trash.CompareTag("cup") || trash.GetComponent<SealedCup>() != null && confirmUI != null)
        {

            confirmUI.ShowConfirmation(trash.gameObject);


            // Print a message to the console for debugging
            Debug.Log("🗑️ cup trashed!");
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
        if (isNearCup)
        {
            //will make trash hightlight
        }
    }

}

// internal class SealedCup
// {
// }

// public class TrashConfirmUI
// {
//     internal void ShowConfirmation(GameObject gameObject)
//     {
//         throw new NotImplementedException();
//     }
// }