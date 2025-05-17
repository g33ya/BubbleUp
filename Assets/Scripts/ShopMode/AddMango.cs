using UnityEngine;

public class AddMango : MonoBehaviour
{
    public Sprite mangoCupSprite;
    public Sprite mangoWithAloeSprite;

    public Sprite mangoWithBobaSprite;
    public Sprite mangoWithPoppinSprite;

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
                    sr.sprite = mangoWithBobaSprite;
                }
                else if(state.hasPoppin){
                    sr.sprite = mangoWithPoppinSprite;
                }
                else if(state.hasAloe){
                    sr.sprite = mangoWithAloeSprite;
                }else{
                    sr.sprite = mangoCupSprite;
                }
               
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