using UnityEngine;

public class OpenBed : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject computerUI;
    public GameObject bedUI;

    void OnMouseDown()
    {
        if (!computerUI.activeSelf && !calendarUI.activeSelf)
        {
            bedUI.SetActive(true);
        }
    }
}