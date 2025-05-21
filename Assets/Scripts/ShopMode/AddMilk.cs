using UnityEngine;

//This script adds Milk to the currently selected cup when the Milk carton is clicked
public class AddMilk : MonoBehaviour
{
    public Sprite milkOnlySprite; //Milk Only
    public Sprite milkWithBobaSprite; //Milk + Boba
    public Sprite milkWithAloeSprite; //Milk + Aloe
    public Sprite milkWithPoppinSprite; //Milk + Poppin

     private void OnMouseDown()
    {
        GameObject cup = CupButtonSpawner.currentCup;

        // Only proceed if a cup is actually selected
        if (cup != null)
        {
            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();

            if (sr != null && state != null)
            {
                 //cup already has Boba, then add Milk so now the cup changes to Sprite Milk + Boba
                if(state.hasBoba){
                    sr.sprite = milkWithBobaSprite;
                }
                 //cup already has Aloe, then add Milk so now the cup changes to Sprite Milk + Aloe
                else if(state.hasAloe){
                    sr.sprite = milkWithAloeSprite;
                }
                //cup already has Poppin, then add Milk so now the cup changes to Sprite Milk + Poppin
                else if(state.hasPoppin){
                    sr.sprite = milkWithPoppinSprite;
                }else
                {
                    sr.sprite = milkOnlySprite;
                }

                //mark that milk was added
                state.hasMilk = true;
                }
            }
        }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
