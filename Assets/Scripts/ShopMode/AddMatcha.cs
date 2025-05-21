using UnityEngine;

//This script adds Matcha to the currently selected cup when the Matcha carton is clicked
//ChatGPT assist

public class AddMatcha : MonoBehaviour
{
    public Sprite matchaOnlySprite; //sprite with only Matcha added
    public Sprite matchaWithBobaSprite; //sprite with Matcha + Boba

    public Sprite matchaWithAloeSprite; //sprite with Matcha + Aloe

    public Sprite matchaWithPoppinSprite; //sprite with Matcha + Poppin
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
                //cup already has Boba, then add Matcha so now the cup changes to Sprite Matcha + Boba
                if (state.hasBoba)
                {
                    sr.sprite = matchaWithBobaSprite;
                }
                //cup already has Aloe, then add Matcha so now the cup changes to Sprite Matcha + Aloe
                else if (state.hasAloe)
                {
                    sr.sprite = matchaWithAloeSprite;
                }
                //cup already has Poppin, then add Matcha so now the cup changes to Sprite Matcha + Poppin
                else if (state.hasPoppin)
                {
                    sr.sprite = matchaWithPoppinSprite;
                }
                else
                {
                    sr.sprite = matchaOnlySprite;
                }

                //mark that matcha was added
                state.hasMatcha = true;
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
