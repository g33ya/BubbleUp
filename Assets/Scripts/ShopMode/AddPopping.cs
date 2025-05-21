using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// This script adds Poppin to the currently selected cup (S/L) when the Poppin ingredient is clicked
//ChatGPT assist
public class AddPopping : MonoBehaviour
{

    // Sprites that represent the different combinations of Aloe with other base drinks
    public Sprite poppinCupSprite; //Poppin Only

    public Sprite matchaWithPoppinSprite; //Matcha + Poppin

    public Sprite mangoWithPoppinSprite; //Mango + Poppin

    public Sprite taroWithPoppinSprite; //Taro + Poppin
    public Sprite milkWithPoppinSprite; //Milk + Poppin



    void OnMouseDown()
    {
        //Makes sure there's a cup current selected and the base Poppin sprite exists
        if (CupButtonSpawner.currentCup != null && poppinCupSprite != null)
        {

            GameObject cup = CupButtonSpawner.currentCup;  //get the current cup GameObject

            //Access the cup sprite rendereder so we can change the cup appearance
            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();

            //Access the cup state (which ingredients it already has)
            CupState state = cup.GetComponent<CupState>();


            //if everything is good we do this
            if (sr != null && state != null)
            {

                //check the base cup has the correct sprite
                if (state.hasMango)
                {
                    sr.sprite = mangoWithPoppinSprite;
                }
                else if (state.hasTaro)
                {
                    sr.sprite = taroWithPoppinSprite;
                }
                else if (state.hasMilk)
                {
                    sr.sprite = milkWithPoppinSprite;
                }
                else if (state.hasMatcha)
                {
                    sr.sprite = matchaWithPoppinSprite;
                }
                else
                {
                    //if the cup has no base yet, just show the Poppin by itself
                    sr.sprite = poppinCupSprite;
                }

                //Mark that the cup has now Poppin added
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