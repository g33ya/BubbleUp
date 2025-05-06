using UnityEngine;

public class AddAloe : MonoBehaviour
{
      public Sprite aloeCupSprite;
      public Sprite matchaWithAloeSprite;
    // public GameObject cupObject;

    void OnMouseDown()
    {
        
        GameObject cup = CupButtonSpawner.currentCup;
        if(cup == null){
            return;
        }
        
        if(cup != null && aloeCupSprite != null){

            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();
            if (sr != null && state != null){
                if(state.hasMatcha){
                    sr.sprite = matchaWithAloeSprite;
                }else{
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