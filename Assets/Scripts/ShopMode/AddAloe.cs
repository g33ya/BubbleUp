using UnityEngine;

// This script adds Aloe to the currently selected cup (S/L) when the Aloe ingredient is clicked

public class AddAloe : MonoBehaviour
{
     // Sprites that represent the different combinations of Aloe with other base drinks
      public Sprite aloeCupSprite; //Aloe Only Cup
      public Sprite matchaWithAloeSprite; //Matcha with Aloe Cup
      public Sprite mangoWithAloeSprite; //Mango with Aloe Cup
      public Sprite taroWithAloeSprite; //Taro with Aloe Cup
      public Sprite milkWithAloeSprite; //Milk with Aloe Cup
 

    // Called automatically when the player clicks this GameObject (Aloe Clickable)
    void OnMouseDown()
    {
        //Makes sure there's a cup current selected and the base aloe sprite exists
        if(CupButtonSpawner.currentCup != null && aloeCupSprite != null){
            GameObject cup = CupButtonSpawner.currentCup; //get the current cup GameObject

        //Access the cup sprite rendereder so we can change the cup appearance
        SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();

        //Access the cup state (which ingredients it already has)
        CupState state = cup.GetComponent<CupState>();

            //if everything is good we do this
            if (sr != null && state != null){
               
               //check the base cup has the correct sprite
                if(state.hasMatcha){
                    sr.sprite = matchaWithAloeSprite;
                }else if(state.hasMango){
                    sr.sprite = mangoWithAloeSprite;
                }else if(state.hasTaro){
                    sr.sprite = taroWithAloeSprite;
                }
                else if(state.hasMilk){
                    sr.sprite = milkWithAloeSprite;
                }
                else{
                    //if the cup has no base yet, just show the aloe by itself
                     sr.sprite = aloeCupSprite;
                }
                //Mark that the cup has now Aloe added
                  state.hasAloe = true;
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

