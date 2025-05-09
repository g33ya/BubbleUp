using UnityEngine;

public class SealLeverButton : MonoBehaviour
{
    public Sprite noCup;

    public Sprite withCup;
    public GameObject sealedCupPrefab;
    public Transform spawnPoint; //where the sealed cup will appear, like location
    private SpriteRenderer spriteRenderer; //changes the image during the game

    private bool cupIsSealed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = noCup; //the game will start with no cup
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("inProgressCup")){
            spriteRenderer.sprite = withCup; //when you drag the cup, now the cup should appear in the machine
            Destroy(other.gameObject); //removes the cup after you have dragged it to the seal machine
        }
    }

     void OnMouseDown(){
        Debug.Log("lever clicked");
        //only run if we havent already sealed a cup
        if(!cupIsSealed && sealedCupPrefab != null && spawnPoint != null){
            spriteRenderer.sprite = withCup; 
            Instantiate(sealedCupPrefab, spawnPoint.position, Quaternion.identity);
            cupIsSealed = true;

            StartCoroutine(ResetLever());
        }
    }

    private System.Collections.IEnumerator ResetLever(){
    yield return new WaitForSeconds(0.5f); // wait half a second
    spriteRenderer.sprite = noCup; //seeting sprite back to empty
    cupIsSealed = false; // allow next cup to be sealed
}


     
    // Update is called once per frame
    void Update()
    {
        
    }
}
