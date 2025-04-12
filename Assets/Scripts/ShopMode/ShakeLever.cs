using UnityEngine;

public class ShakeLever : MonoBehaviour
{

    public Sprite leverUp;
    public Sprite leverDown;
    public GameObject shakerCup;
    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;
    private int shakeCount = 0;
    private bool shakeUp = true;
    private Vector3 originalPosition;
   // public Vector3 pressOffset = new Vector3(0f, -0.2f, 0f);
  
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

            if(shakerCup != null){
                originalPosition = shakerCup.transform.localPosition;
                shakeCount = 0;
                InvokeRepeating("ShakeCupDown", 0f,0.1f);
            }

        }else{
            spriteRenderer.flipY = false;
           // transform.localPosition = originalPosition;
            isPressed = false;
            Debug.Log("level is reset to up");
        }
    }

    void ShakeCupDown(){
        float offset = 0.05f;

        if(shakeUp){
            shakerCup.transform.position = originalPosition + new Vector3(0f, offset, 0f);
        }else{
            shakerCup.transform.position = originalPosition - new Vector3(0f, offset, 0f);
        }
        
        shakeUp = !shakeUp;
        shakeCount++;

        if(shakeCount >= 6){ //shake the cup 3 full times up & down
            CancelInvoke("ShakeCupDown");
            shakerCup.transform.position = originalPosition; //reset to center
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
