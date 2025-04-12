using UnityEngine;

public class SnapToStation : MonoBehaviour
{
    public Transform snapPoint;
    public float snapThreshold = .7f;
    private bool isSnapped = false;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSnapped && snapPoint != null){
            float distance = Vector3.Distance(transform.position, snapPoint.position);

            if(distance < snapThreshold){
                transform.position = snapPoint.position;

                ShopEventScript dragscript = GetComponent<ShopEventScript>();
                if(dragscript != null){
                    dragscript.enabled = false;
                }

                isSnapped = true;
            }
        }
    }
}
