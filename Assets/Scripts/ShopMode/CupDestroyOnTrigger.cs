using UnityEngine;

// This script detects when a cup enters the sealing machine's trigger zone
// and passes that cup to the ShakeLever script for sealing

public class CupDestroyOnTrigger : MonoBehaviour
{
    // Reference to the ShakeLever script, which handles sealing logic
    public ShakeLever lever;

    public SpriteRenderer machineRenderer;       // The SpriteRenderer on the sealer
    public Sprite sealerEmptySprite;             // Sprite with no cup
    public Sprite sealerWithCupSprite;           // Sprite with cup
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cup") || other.GetComponent<CupState>() != null)
        {
            Debug.Log("✅ Cup entered sealer zone: " + other.name);

            // Tell the lever which cup is currently inside the sealer
            lever.SetCurrentCup(other.gameObject);

            // Change the sprite to show the cup in the machine
          if (machineRenderer != null && sealerWithCupSprite != null)
        {
            machineRenderer.sprite = sealerWithCupSprite;
        }
 
        }
    }
}
   