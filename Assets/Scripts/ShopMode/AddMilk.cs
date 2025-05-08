using UnityEngine;

public class AddMilk : MonoBehaviour
{
    public Sprite milkOnlySprite;
    public Sprite milkWithBobaSprite;
    public Sprite milkWithAloeSprite;
    public Sprite milkWithPoppinSprite;

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
                    sr.sprite = milkWithBobaSprite;
                }
                else if(state.hasAloe){
                    sr.sprite = milkWithAloeSprite;
                }
                else if(state.hasPoppin){
                    sr.sprite = milkWithPoppinSprite;
                }else{
                    sr.sprite = milkOnlySprite;
                }
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
