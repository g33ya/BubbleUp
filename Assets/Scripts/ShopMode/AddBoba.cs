using UnityEngine;

// This script adds Boba to the currently selected cup (S/L) when the Boba ingredient is clicked
public class AddBoba : MonoBehaviour
{
    // Sprite that represent Boba Only
    public Sprite bobaCupSprite;


    // Called automatically when the player clicks this GameObject (Boba Clickable)
    void OnMouseDown()
    {
        GameObject cup = CupButtonSpawner.currentCup;

        // If no cup is currently selected, do nothing
        if (cup == null)
        {
            return;
        }

        // Make sure both the cup and the boba sprite exist before continuing
        if (cup != null && bobaCupSprite != null)
        {

            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();
            if (sr != null && state != null)
            {
                sr.sprite = bobaCupSprite; //change the cup appearance to now have boba

                //mark that the cup has boba added
                state.hasBoba = true;

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
