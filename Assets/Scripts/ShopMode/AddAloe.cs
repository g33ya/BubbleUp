using UnityEngine;

public class AddAloe : MonoBehaviour
{
      public Sprite aloeCupSprite;
      public Sprite matchaWithAloeSprite;

      public Sprite mangoWithAloeSprite;
      public Sprite taroWithAloeSprite;
      public Sprite milkWithAloeSprite;
    // public GameObject cupObject;

    void OnMouseDown()
    {
        if(CupButtonSpawner.currentCup != null && aloeCupSprite != null){
            GameObject cup = CupButtonSpawner.currentCup;
        SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
        CupState state = cup.GetComponent<CupState>();
            if (sr != null && state != null){
                if(state.hasMatcha){
                    sr.sprite = matchaWithAloeSprite;
                }else if(state.hasMango){
                    sr.sprite = mangoWithAloeSprite;
                }else if(state.hasTaro){
                    sr.sprite = mangoWithAloeSprite;
                }
                else if(state.hasMilk){
                    sr.sprite = milkWithAloeSprite;
                }
                else{
                     sr.sprite = aloeCupSprite;
                }
               state.hasAloe = true;
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