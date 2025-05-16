using System;
using UnityEngine;

public class ShakeLever : MonoBehaviour
{

   public Sprite leverUp;
    public Sprite leverDown;
    private SpriteRenderer spriteRenderer;
    private bool isPressed = false;

    public SpriteRenderer machineRenderer;
    public Sprite sealerEmptySprite;

    public CupState currentCupState;
    public Transform spawnPoint;         // where the sealed cup appears
    public GameObject currentCup;        // the cup currently in the machine

    public GameObject mangoSealed, mangoBobaSealed, mangoAloeSealed, mangoPoppinSealed;
    public GameObject taroSealed, taroBobaSealed, taroPoppinSealed, taroAloeSealed;
    public GameObject milkSealed, milkBobaSealed, milkAloeSealed, milkPoppinSealed;
    public GameObject brownsugarSealed, brownsugarBobaSealed;
    public GameObject matchaSealed, matchaBobaSealed, matchaPoppinSealed, matchaAloeSealed;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = leverUp;
    }

   void OnMouseDown()
    {
        Debug.Log("Lever clicked");

        // Get current cup from CupButtonSpawner if needed
        if (currentCup == null)
            currentCup = CupButtonSpawner.currentCup;
       

        if (currentCup != null && currentCupState == null)
            currentCupState = currentCup.GetComponent<CupState>();

        Debug.Log("Current Cup: " + currentCup);
        Debug.Log("Current Cup State: " + currentCupState);

        if (!isPressed && currentCup != null && currentCupState != null && spawnPoint != null)
        {
            spriteRenderer.sprite = leverDown;
            isPressed = true;
            Debug.Log("Lever pulled!");

            GameObject prefabToSpawn = GetSealedCupPrefab(currentCupState);

            if (prefabToSpawn != null)
            {
                Debug.Log("Spawning sealed prefab: " + prefabToSpawn.name);
                Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
                Destroy(currentCup);
                CupButtonSpawner.currentCup = null;

                 if (machineRenderer != null && sealerEmptySprite != null)
                 {
                     machineRenderer.sprite = sealerEmptySprite;
                }

                StartCoroutine(ResetLever());
            }
            else
            {
                Debug.LogWarning("No matching sealed cup prefab found for ingredients!");
                spriteRenderer.sprite = leverUp;
                isPressed = false;
            }
        }
        else if (currentCup == null || currentCupState == null)
        {
            Debug.LogWarning("No cup ready to seal!");
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
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.sprite = leverUp;
        isPressed = false;
        currentCup = null;
        currentCupState = null;

    }

    internal void SetCurrentCup(GameObject cup)
    {
        currentCup = cup;
        currentCupState = cup.GetComponent<CupState>();
    }
}


