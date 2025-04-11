using UnityEngine;

public class outlinerGenerator : MonoBehaviour
{
    public Material outlineMaterial;
    public Color outlineColor = Color.white;
    public float outlineSize = 0.03f;
    private GameObject outlineObject;

    void Start()
    {
        createOutline();
        toggleOutline(false);
    }

    void createOutline()
    {
        SpriteRenderer original = GetComponent<SpriteRenderer>();

        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform;
        outlineObject.transform.localPosition = Vector3.zero;
        outlineObject.transform.localScale = Vector3.one + Vector3.one * outlineSize;

        SpriteRenderer outlineRenderer = outlineObject.AddComponent<SpriteRenderer>();
        outlineRenderer.sprite = original.sprite;
        outlineRenderer.sortingLayerName = "OutlineLayer";
        outlineRenderer.sortingOrder = original.sortingOrder - 1;
        outlineRenderer.color = outlineColor;
        outlineRenderer.material = outlineMaterial;
    }

    public void toggleOutline(bool show)
    {
        if (outlineObject != null)
            outlineObject.SetActive(show);
    }
}
