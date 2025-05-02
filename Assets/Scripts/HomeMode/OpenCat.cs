using UnityEngine;

public class OpenCat : MonoBehaviour
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
            !journalUI.activeSelf &&
            !booksUI.activeSelf)
        {
            catUI.SetActive(true);
        }
    }
}

