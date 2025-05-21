using UnityEngine;

//This script adds Mango to the currently selected cup when the Mango carton is clicked

public class AddMango : MonoBehaviour
{
    public Sprite mangoCupSprite; //Mango Only
    public Sprite mangoWithAloeSprite; //Mango + Aloe
    public Sprite mangoWithBobaSprite; //Mango + Boba
    public Sprite mangoWithPoppinSprite; //Mango + Poppin
    public AudioSource pour;

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
                //cup already has Boba, then add Mango so now the cup changes to Sprite Mango + Boba
                if (state.hasBoba)
                {
                    sr.sprite = mangoWithBobaSprite;
                    pour.Play();
                }
                //cup already has Poppin, then add Mango so now the cup changes to Sprite Mango + Poppin
                else if (state.hasPoppin)
                {
                    sr.sprite = mangoWithPoppinSprite;
                    pour.Play();
                }
                //cup already has Aloe, then add Mango so now the cup changes to Sprite Mango + Aloe
                else if (state.hasAloe)
                {
                    sr.sprite = mangoWithAloeSprite;
                    pour.Play();

                }
                else
                {
                    sr.sprite = mangoCupSprite;
                    pour.Play();
                }

                //mark that mango was added
                state.hasMango = true;
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