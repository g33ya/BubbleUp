using UnityEngine;

public class AddBoba : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite bobaCupSprite;
    // public GameObject cupObject;

    void OnMouseDown()
    {
        GameObject cup = CupButtonSpawner.currentCup;
        if(cup == null){
            return;
        }
       
        if(cup != null && bobaCupSprite != null){

            SpriteRenderer sr = cup.GetComponent<SpriteRenderer>();
            CupState state = cup.GetComponent<CupState>();
            if (sr != null && state != null){
                sr.sprite = bobaCupSprite;
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
