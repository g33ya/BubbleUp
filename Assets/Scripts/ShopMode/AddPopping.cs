using UnityEngine;

public class AddPopping : MonoBehaviour
{
     public Sprite poppinCupSprite;
    // public GameObject cupObject;
    public Sprite matchaWithPoppinSprite;
    


    void OnMouseDown()
    {

         GameObject cup = CupButtonSpawner.currentCup;
        if(cup == null){
            return;
        }
        if(cup != null && poppinCupSprite != null){

            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();
            if (sr != null && state != null){
                if(state.hasMatcha){
                    sr.sprite = matchaWithPoppinSprite;
                }
                else{
                     sr.sprite = poppinCupSprite;
                }
              
                state.hasPoppin = true;
    
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}