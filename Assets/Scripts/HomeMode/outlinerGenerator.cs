using UnityEngine;

public class outlinerGenerator : MonoBehaviour
{
    public Color outlineColor = Color.black;
    public float scaleFactor = 1.20f;

    private GameObject outlineObject;

    void Start()
    {
        // Duplicate the original sprite
        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localScale = Vector3.one * scaleFactor;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        SpriteRenderer outlineSR = outlineObject.AddComponent<SpriteRenderer>();

        outlineSR.sprite = sr.sprite;
        outlineSR.material = new Material(Shader.Find("Sprites/Default")); // Ensure alpha isn't affected
        outlineSR.sortingLayerID = sr.sortingLayerID;
        outlineSR.sortingOrder = sr.sortingOrder - 1;

        // Make sure the outline is fully opaque
        outlineSR.color = new Color(outlineColor.r, outlineColor.g, outlineColor.b, 1f);

        toggleOutline(false); // Disable outline by default
    }

/*My older Outline Generator vis the version Game versions V V V */

    /*void createOutline()
    {
        SpriteRenderer original = GetComponent<SpriteRenderer>();

        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localScale = Vector3.one + Vector3.one * outlineSize;

        SpriteRenderer outlineRenderer = outlineObject.AddComponent<SpriteRenderer>();
        outlineRenderer.sprite = original.sprite;
        outlineRenderer.sortingLayerName = "OutlineLayer";
        outlineRenderer.sortingOrder = original.sortingOrder + 1;
        outlineRenderer.color = outlineColor;
        outlineRenderer.material = outlineMaterial;
    }*/

    public void toggleOutline(bool show)
    {
        if (outlineObject != null)
            outlineObject.SetActive(show);
    }
}
