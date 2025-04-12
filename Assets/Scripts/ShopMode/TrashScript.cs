using UnityEngine;

public class TrashScript : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D trash)
    {
        if (trash.CompareTag("cup") || trash.CompareTag("inProgressCup"))
        {
            Destroy(trash.gameObject);
            Debug.Log("🗑️ cup trashed!");
        }
    }
    
    AudioSource trashSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trashSound = GetComponent<AudioSource>();
        //add this later
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
