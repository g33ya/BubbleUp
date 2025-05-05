using UnityEngine;

public class AddAloe : MonoBehaviour
{
      public Sprite aloeCupSprite;
    // public GameObject cupObject;

    void OnMouseDown()
    {
        if(CupButtonSpawner.currentCup != null && aloeCupSprite != null){

            SpriteRenderer sr = CupButtonSpawner.currentCup.GetComponent<SpriteRenderer>();
            if (sr != null){
                sr.sprite = aloeCupSprite;
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