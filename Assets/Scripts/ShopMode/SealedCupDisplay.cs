using UnityEngine;

public class SealedCupDisplay : MonoBehaviour
{
   public SpriteRenderer sr;

    public void SetSealedSprite(Sprite sealedSprite){
        if(sr != null && sealedSprite != null){
            sr.sprite = sealedSprite;
        }
        else if (sealedSprite != null){
            GetComponent<SpriteRenderer>().sprite = sealedSprite;
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
