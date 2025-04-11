using UnityEngine;

public class toggelOutline : MonoBehaviour
{
    outlinerGenerator outlineGen;

    void Start()
    {
        outlineGen = GetComponent<outlinerGenerator>();
    }

    void OnMouseEnter()
    {
        outlineGen.toggleOutline(true);
    }

    void OnMouseExit()
    {
        outlineGen.toggleOutline(false);
    }
}
