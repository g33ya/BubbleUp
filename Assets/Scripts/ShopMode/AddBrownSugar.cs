using UnityEngine;

public class AddBrownSugar : MonoBehaviour
{
    public Sprite brownsugarOnlySprite;
    public Sprite brownsugarWithBobaSprite;

      private void OnMouseDown()
    {
        GameObject cup = CupButtonSpawner.currentCup;

        if (cup != null)
        {
            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();

            if (sr != null && state != null)
            {
                if(state.hasBoba){
                    sr.sprite = brownsugarWithBobaSprite;
                }
                else{
                    sr.sprite = brownsugarOnlySprite;
                }
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
