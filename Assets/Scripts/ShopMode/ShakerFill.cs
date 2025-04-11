using UnityEngine;

public class ShakerFill : MonoBehaviour
{
    public GameObject liquidObject;
    public string cartonTag = "Carton";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(liquidObject != null){
            liquidObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(cartonTag)){
            if(liquidObject != null){
                liquidObject.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
