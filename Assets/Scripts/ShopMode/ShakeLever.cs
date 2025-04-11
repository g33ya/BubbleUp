using UnityEngine;

public class ShakeLever : MonoBehaviour
{

    public Sprite leverUp;
    public Sprite leverDown;

    private SpriteRenderer spriteRenderer;
    //private Vector3 originalPosition;
   // public Vector3 pressOffset = new Vector3(0f, -0.2f, 0f);
    private bool isPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //originalPosition = transform.localPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverUp;
    }

    void OnMouseDown(){
        if(!isPressed){
            spriteRenderer.flipY = true;
            //transform.localPosition = originalPosition + pressOffset;
            isPressed = true;
            Debug.Log("lever is pressed down");
        }else{
            spriteRenderer.flipY = false;
           // transform.localPosition = originalPosition;
            isPressed = false;
            Debug.Log("level is reset to up");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
