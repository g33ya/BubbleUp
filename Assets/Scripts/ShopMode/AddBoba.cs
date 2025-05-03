using UnityEngine;

public class AddBoba : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite bobaCupSprite;
    // public GameObject cupObject;

    void OnMouseDown()
    {
        if(CupButtonSpawner.currentCup != null && bobaCupSprite != null){

            SpriteRenderer sr = CupButtonSpawner.currentCup.GetComponent<SpriteRenderer>();
            if (sr != null){
                sr.sprite = bobaCupSprite;
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
