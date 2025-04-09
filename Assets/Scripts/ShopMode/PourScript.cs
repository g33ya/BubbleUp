using UnityEngine;

public class PourScript : MonoBehaviour

{
    ParticleSystem myParticleSystem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Angle(Vector3.down, transform.forward) <= 90f){
            myParticleSystem.Play();
        }else{
            myParticleSystem.Stop();
        }
    }
}
