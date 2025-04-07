using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject computerUI;

    void OnMouseDown()
    {
        computerUI.SetActive(true);
    }
}
