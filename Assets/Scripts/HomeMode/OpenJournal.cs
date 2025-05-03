using UnityEngine;

public class OpenJounral : MonoBehaviour
{
    public GameObject calendarUI;
    public GameObject computerUI;
    public GameObject bedUI;
    public GameObject doorUI;
    public GameObject catUI;
    public GameObject recordUI;
    public GameObject journalUI;
    public GameObject booksUI;

    void OnMouseDown()
    {
        if (!computerUI.activeSelf && 
            !calendarUI.activeSelf && 
            !bedUI.activeSelf &&
            !doorUI.activeSelf &&
            !recordUI.activeSelf &&
            !catUI.activeSelf &&
            !booksUI.activeSelf)
        {
            journalUI.SetActive(true);
        }
    }
}

