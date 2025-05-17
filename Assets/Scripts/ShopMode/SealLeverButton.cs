using UnityEngine;

public class SealLeverButton : MonoBehaviour
{
    public Sprite noCup;
    public Sprite withCup;
    public Transform spawnPoint;
    private SpriteRenderer spriteRenderer;

    public GameObject mangoSealed, mangoBobaSealed, mangoAloeSealed, mangoPoppinSealed;
    public GameObject taroSealed, taroBobaSealed, taroPoppinSealed, taroAloeSealed;
    public GameObject milkSealed, milkBobaSealed, milkAloeSealed, milkPoppinSealed;
    public GameObject brownsugarSealed, brownsugarBobaSealed;
    public GameObject matchaSealed, matchaBobaSealed, matchaPoppinSealed, matchaAloeSealed;

    private bool cupIsSealed = false;
    private GameObject currentCup;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = noCup;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!cupIsSealed && other.CompareTag("cup"))
        {
            spriteRenderer.sprite = withCup;
            currentCup = other.gameObject;
           
        }
    }

    void OnMouseDown()
    {
        Debug.Log("lever clicked");

        if (!cupIsSealed && spawnPoint != null && currentCup != null)
        {
            CupState state = currentCup.GetComponent<CupState>();
            GameObject prefabToSpawn = GetSealedCupPrefab(state);

            if (prefabToSpawn != null)
            {
                Debug.Log("Spawning sealed cup: " + prefabToSpawn.name);
                Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
                Destroy(currentCup); //destroys hidden cup
                cupIsSealed = true;
                StartCoroutine(ResetLever());
            }
            else
            {
                Debug.LogWarning("No matching sealed cup prefab found.");
            }
        }
    }
private GameObject GetSealedCupPrefab(CupState state)
    {
        if (state == null) return null;

        if (state.hasMango && state.hasBoba) return mangoBobaSealed;
        if (state.hasMango && state.hasAloe) return mangoAloeSealed;
        if (state.hasMango && state.hasPoppin) return mangoPoppinSealed;
        if (state.hasMango) return mangoSealed;

        if (state.hasTaro && state.hasBoba) return taroBobaSealed;
        if (state.hasTaro && state.hasAloe) return taroAloeSealed;
        if (state.hasTaro && state.hasPoppin) return taroPoppinSealed;
        if (state.hasTaro) return taroSealed;

        if (state.hasMilk && state.hasBoba) return milkBobaSealed;
        if (state.hasMilk && state.hasAloe) return milkAloeSealed;
        if (state.hasMilk && state.hasPoppin) return milkPoppinSealed;
        if (state.hasMilk) return milkSealed;

        if (state.hasBrownSugar && state.hasBoba) return brownsugarBobaSealed;
        if (state.hasBrownSugar) return brownsugarSealed;

        if (state.hasMatcha && state.hasBoba) return matchaBobaSealed;
        if (state.hasMatcha && state.hasAloe) return matchaAloeSealed;
        if (state.hasMatcha && state.hasPoppin) return matchaPoppinSealed;
        if (state.hasMatcha) return matchaSealed;

        return null;
    }

    private System.Collections.IEnumerator ResetLever()
    {
        yield return new WaitForSeconds(0.5f); // wait half a second
        spriteRenderer.sprite = noCup; //seeting sprite back to empty
        cupIsSealed = false; // allow next cup to be sealed
    }
}


//        // Destroy(currentCup);
//         if(prefabToSpawn != null){
//              GameObject sealedCup = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);

//         // SealedCupDisplay display = sealedCup.GetComponent<SealedCupDisplay>();
//         // if (display != null)
//         // {
//         //     display.SetSealedSprite(sealedSprite);
//         // }

//         cupIsSealed = true;
//         StartCoroutine(ResetLever());
//         }
//     }
// }
//     private System.Collections.IEnumerator ResetLever(){
//         yield return new WaitForSeconds(0.5f); // wait half a second
//         spriteRenderer.sprite = noCup; //seeting sprite back to empty
//         cupIsSealed = false; // allow next cup to be sealed
//     }



//      void OnMouseDown(){
//         Debug.Log("lever clicked");
//         //only run if we havent already sealed a cup
//         if(!cupIsSealed && sealedCupPrefab != null && spawnPoint != null){
//             spriteRenderer.sprite = withCup; 
//             Instantiate(sealedCupPrefab, spawnPoint.position, Quaternion.identity);
//             cupIsSealed = true;

//             StartCoroutine(ResetLever());
//         }
//     }

//     private System.Collections.IEnumerator ResetLever(){
//     yield return new WaitForSeconds(0.5f); // wait half a second
//     spriteRenderer.sprite = noCup; //seeting sprite back to empty
//     cupIsSealed = false; // allow next cup to be sealed
// }


    

     
    // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
