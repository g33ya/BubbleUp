using UnityEngine;

public class AddPopping : MonoBehaviour
{
     public Sprite poppinCupSprite;
    // public GameObject cupObject;

    void OnMouseDown()
    {
        if(CupButtonSpawner.currentCup != null && poppinCupSprite != null){

            SpriteRenderer sr = CupButtonSpawner.currentCup.GetComponent<SpriteRenderer>();
            if (sr != null){
                sr.sprite = poppinCupSprite;
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