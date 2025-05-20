using UnityEngine;

public class PermanentOutline : MonoBehaviour
{
    public Color outlineColor = Color.black;
    public float scaleFactor = 1.12f;

    private GameObject outlineObj;

    void Start()
    {
        // Duplicate the original sprite
        outlineObj = new GameObject("Outline");
        outlineObj.transform.parent = transform;
        outlineObj.transform.localPosition = Vector3.zero;
        outlineObj.transform.localScale = Vector3.one * scaleFactor;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        SpriteRenderer outlineSR = outlineObj.AddComponent<SpriteRenderer>();

        outlineSR.sprite = sr.sprite;
        outlineSR.sortingLayerID = sr.sortingLayerID;
        outlineSR.sortingOrder = sr.sortingOrder - 1;
        outlineSR.color = outlineColor;
    }
}

