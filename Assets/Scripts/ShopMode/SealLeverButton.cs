using UnityEngine;

public class SealLeverButton : MonoBehaviour
{
    public Sprite noCup;
    public Sprite withCup;
    public GameObject sealedCupPrefab;
    public Transform spawnPoint; //where the sealed cup will appear, like location
    private SpriteRenderer spriteRenderer; //changes the image during the game

     public Sprite mangoSealed;
    public Sprite mangoBobaSealed;
    public Sprite mangoAloeSealed;
    public Sprite mangoPoppinSealed;
    public Sprite taroSealed;
    public Sprite taroBobaSealed;
    public Sprite taroPoppinSealed;
    public Sprite taroAloeSealed;
    public Sprite milkSealed;
    public Sprite milkBobaSealed;
    public Sprite milkAloeSealed;
    public Sprite milkPoppinSealed;
    public Sprite brownsugarSealed;
    public Sprite brownsugarBobaSealed;
    public Sprite matchaSealed;
    public Sprite matchaBobaSealed;
    public Sprite matchaPoppinSealed;
    public Sprite matchaAloeSealed;

    private bool cupIsSealed = false;
    private GameObject currentCup;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = noCup; //the game will start with no cup
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(!cupIsSealed && other.CompareTag("inProgressCup")){
            spriteRenderer.sprite = withCup; //when you drag the cup, now the cup should appear in the machine
            currentCup = other.gameObject;
           // Destroy(other.gameObject); //removes the cup after you have dragged it to the seal machine
        }
    }

void OnMouseDown()
{
    Debug.Log("lever clicked");
    //only run if we havent already sealed a cup
    if (!cupIsSealed && sealedCupPrefab != null && spawnPoint != null && currentCup != null)
    {
        SpriteRenderer oldSR = currentCup.GetComponent<SpriteRenderer>();
        CupState state = currentCup.GetComponent<CupState>();

        Sprite sealedSprite = null;

        if (state != null)
        {
            if (state.hasMango && state.hasBoba){
                sealedSprite = mangoBobaSealed;
            }
            else if (state.hasMango && state.hasAloe){
                sealedSprite = mangoAloeSealed;
            }
            else if (state.hasMango && state.hasPoppin){
                sealedSprite = mangoPoppinSealed;
            }
            else if (state.hasMango){
                sealedSprite = mangoSealed;
            }
            else if (state.hasTaro){
                sealedSprite = taroSealed;
            }
            else if(state.hasTaro &&state.hasBoba){
                sealedSprite = taroBobaSealed;
            }
            else if(state.hasTaro && state.hasAloe){
                sealedSprite = taroAloeSealed;
            }
            else if(state.hasTaro && state.hasPoppin){
                sealedSprite = taroPoppinSealed;
            }
            else if(state.hasMilk){
                sealedSprite = milkSealed;
            }
             else if(state.hasMilk && state.hasPoppin){
                sealedSprite = milkPoppinSealed;
            }
             else if(state.hasMilk && state.hasBoba){
                sealedSprite = milkBobaSealed;
            }
             else if(state.hasMilk && state.hasAloe){
                sealedSprite = milkAloeSealed;
            }
            else if(state.hasMatcha){
                sealedSprite = matchaSealed;
            }
            else if(state.hasMatcha && state.hasBoba){
                sealedSprite = matchaBobaSealed;
            }
            else if(state.hasMatcha && state.hasAloe){
                sealedSprite = matchaAloeSealed;
            }
            else if(state.hasMatcha && state.hasPoppin){
                sealedSprite = matchaPoppinSealed;
            }
            else if(state.hasBrownSugar){
                sealedSprite = brownsugarSealed;
            }
            else if(state.hasBrownSugar && state.hasBoba){
                sealedSprite = brownsugarBobaSealed;
            }
        }

        Destroy(currentCup);

        GameObject sealedCup = Instantiate(sealedCupPrefab, spawnPoint.position, Quaternion.identity);

        SealedCupDisplay display = sealedCup.GetComponent<SealedCupDisplay>();
        if (display != null)
        {
            display.SetSealedSprite(sealedSprite);
        }

        cupIsSealed = true;
        StartCoroutine(ResetLever());
    }
}
    private System.Collections.IEnumerator ResetLever(){
        yield return new WaitForSeconds(0.5f); // wait half a second
        spriteRenderer.sprite = noCup; //seeting sprite back to empty
        cupIsSealed = false; // allow next cup to be sealed
    }


//      void OnMouseDown(){
//         Debug.Log("lever clicked");
//         //only run if we havent already sealed a cup
//         if(!cupIsSealed && sealedCupPrefab != null && spawnPoint != null){
//             spriteRenderer.sprite = withCup; 
//             Instantiate(sealedCupPrefab, spawnPoint.position, Quaternion.identity);
//             cupIsSealed = true;

//             StartCoroutine(ResetLever());
//         }
//     }

//     private System.Collections.IEnumerator ResetLever(){
//     yield return new WaitForSeconds(0.5f); // wait half a second
//     spriteRenderer.sprite = noCup; //seeting sprite back to empty
//     cupIsSealed = false; // allow next cup to be sealed
// }


     
    // Update is called once per frame
    void Update()
    {
        
    }
}
