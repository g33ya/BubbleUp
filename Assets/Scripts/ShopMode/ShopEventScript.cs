using UnityEngine;
using UnityEngine.EventSystems;
public class ShopEventScript : MonoBehaviour, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    Vector3 cameraOffset;
    public Transform snapPoint;
    public float snapThreshold = 0.7f;
    public void OnBeginDrag(PointerEventData eventData){}

    public void OnDrag(PointerEventData eventData){
          Debug.Log("OnDrag" + eventData.position);
          transform.position= Camera.main.ScreenToWorldPoint(eventData.position)+cameraOffset;
    }

    public void OnEndDrag(PointerEventData eventData){
      if (snapPoint != null)
        {
            float distance = Vector3.Distance(transform.position, snapPoint.position);
            Debug.Log("Dropped. Distance to snap point: " + distance);

            if (distance < snapThreshold)
            {
                transform.position = snapPoint.position;
                Debug.Log("✅ Snapped to center!");
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("OnPointerClick");
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start(){
    cameraOffset=Camera.main.ScreenToWorldPoint(new Vector3(0,0,0));
    cameraOffset.x=0;
    cameraOffset.y=0;
    cameraOffset.z=-cameraOffset.z;
    Debug.Log("camerOffset:"+cameraOffset);
  }

}