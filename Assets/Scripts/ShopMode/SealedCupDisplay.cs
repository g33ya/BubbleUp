using UnityEngine;

// This script is responsible for displaying the correct sealed cup sprite after sealing

public class SealedCupDisplay : MonoBehaviour
{
   public SpriteRenderer sr;

    public void SetSealedSprite(Sprite sealedSprite){

        // If a SpriteRenderer was assigned AND the sealed sprite is valid, use it
        if(sr != null && sealedSprite != null){
            sr.sprite = sealedSprite;
        }

        // If no SpriteRenderer was assigned in Unity, the script will automatically look
        // for a SpriteRenderer on the same GameObject and change its sprite.
        else if (sealedSprite != null){
            GetComponent<SpriteRenderer>().sprite = sealedSprite;
        }
    }
    



    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
