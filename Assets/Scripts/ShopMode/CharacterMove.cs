using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public GameObject character;
    public GameObject counterPosition;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //character.transform.position=Vector3.MoveTowards(character.transform.position, counterPosition.transform.position,speed);
    }

    // Update is called once per frame
    void Update()
    {
        character.transform.position=Vector3.MoveTowards(character.transform.position, counterPosition.transform.position,speed);
    }
}
