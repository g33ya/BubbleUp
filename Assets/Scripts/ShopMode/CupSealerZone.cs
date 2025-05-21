using UnityEngine;

//ChapGPT assist
public class CupSealerZone : MonoBehaviour
{
    public ShakeLever lever;

    // SpriteRenderer on the sealing machine to change its appearance
    public SpriteRenderer machineRenderer;

    // Sprites for the sealer (with or without a cup)
    public Sprite sealerEmptySprite;
    public Sprite sealerWithCupSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is a cup (by tag or by having CupState)
        if (other.CompareTag("cup") || other.GetComponent<CupState>() != null)
        {
            Debug.Log("✅ Cup entered sealer zone: " + other.name);

            // Tell the lever which cup is currently in the sealer
            lever.SetCurrentCup(other.gameObject);
            

            // Change the appearance of the sealer to show that it now has a cup
            if (machineRenderer != null && sealerWithCupSprite != null)
            {
                machineRenderer.sprite = sealerWithCupSprite;
            }
        }
    }
}
