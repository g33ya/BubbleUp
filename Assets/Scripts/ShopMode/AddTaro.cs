using UnityEngine;

public class AddTaro : MonoBehaviour
{
    public Sprite taroOnlySprite;

    public Sprite taroWithAloeSprite;

    public Sprite taroWithBobaSprite;
    public Sprite taroWithPoppinSprite;

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
                    sr.sprite = taroWithBobaSprite;
                }
                else if(state.hasAloe){
                    sr.sprite = taroWithAloeSprite;
                }else if(state.hasPoppin){
                    sr.sprite = taroWithPoppinSprite;
                }
                else{
                     sr.sprite = taroOnlySprite;
                }
               
                state.hasTaro = true;
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
