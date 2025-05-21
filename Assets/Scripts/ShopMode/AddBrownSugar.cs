using UnityEngine;

//This script adds Brown Sugar to the currently selected cup when the Brown Sugar carton is clicked

public class AddBrownSugar : MonoBehaviour
{
    public Sprite brownsugarOnlySprite; //sprite with only brownsugar added
    public Sprite brownsugarWithBobaSprite; //sprite with brownsugar and boba added
    public AudioSource pour;

    private void OnMouseDown()
    {

        GameObject cup = CupButtonSpawner.currentCup; // Get the currently selected cup

        // Make sure a cup exists and the sprite is assigned
        if (cup != null)
        {
            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();

            //only procedd if a cup is selected 
            if (sr != null && state != null)
            {
                //if cup already has boba, add the brownsugar sprite so now its brownsugar + boba cup
                if (state.hasBoba)
                {
                    sr.sprite = brownsugarWithBobaSprite;
                    pour.Play();
                }
                else
                {
                    sr.sprite = brownsugarOnlySprite;
                    pour.Play();
                }
                 state.ResetDrinkBase();
                //mark that brownsugar was added
                state.hasBrownSugar = true;
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
