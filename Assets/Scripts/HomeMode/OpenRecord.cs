using UnityEngine;

public class OpenRecord : MonoBehaviour
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
            !catUI.activeSelf &&
            !journalUI.activeSelf &&
            !booksUI.activeSelf)
        {
            recordUI.SetActive(true);
        }
    }
}

