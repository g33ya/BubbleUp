using UnityEngine;

public class AddPopping : MonoBehaviour
{
     public Sprite poppinCupSprite;
    // public GameObject cupObject;
    public Sprite matchaWithPoppinSprite;

    public Sprite mangoWithPoppinSprite;

    public Sprite taroWithPoppinSprite;
    public Sprite milkWithPoppinSprite;
    


    void OnMouseDown()
    {
        if(CupButtonSpawner.currentCup != null && poppinCupSprite != null){

           GameObject cup = CupButtonSpawner.currentCup;
            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();
    

            
            if (sr != null && state != null){
                if(state.hasMango){
                    sr.sprite = mangoWithPoppinSprite;
                }
                else if(state.hasMatcha){
                    sr.sprite = matchaWithPoppinSprite;
                }else if(state.hasTaro){
                    sr.sprite = taroWithPoppinSprite;
                }
                else if(state.hasMilk){
                    sr.sprite = milkWithPoppinSprite;
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