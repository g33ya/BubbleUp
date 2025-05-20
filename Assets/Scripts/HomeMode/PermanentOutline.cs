using UnityEngine;

public class PermanentOutline : MonoBehaviour
{
    public Color outlineColor = Color.black;
    public float scaleFactor = 1.12f;

    private GameObject outlineObject;

    void Start()
    {
        outlineObject = new GameObject("Outline"); // Duplicate the original sprite
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localScale = Vector3.one * scaleFactor;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        SpriteRenderer outlineSR = outlineObject.AddComponent<SpriteRenderer>();

        outlineSR.sprite = sr.sprite;
        outlineSR.sortingLayerID = sr.sortingLayerID;
        outlineSR.sortingOrder = sr.sortingOrder - 1;
        outlineSR.color = outlineColor;
    }
}

