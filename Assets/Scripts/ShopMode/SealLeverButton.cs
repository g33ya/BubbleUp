using UnityEngine;

public class SealLeverButton : MonoBehaviour
{
    public Sprite noCup;

    public Sprite withCup;

    private SpriteRenderer spriteRenderer; //changes the image during the game

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = noCup; //the game will start with no cup
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("cup")){
            spriteRenderer.sprite = withCup; //when you drag the cup, now the cup should appear in the machine
            Destroy(other.gameObject); //removes the cup after you have dragged it to the seal machine
        }
    }

        //May not need the code below anymore becuase of the Destroy trigger

    //  private void OnTriggerExit2D(Collider2D other){
    //     if(other.CompareTag("cup")){
    //         spriteRenderer.sprite = noCup;
    //     }
    // }
    // Update is called once per frame
    void Update()
    {
        
    }
}
