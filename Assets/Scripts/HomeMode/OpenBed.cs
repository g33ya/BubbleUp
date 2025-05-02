using UnityEngine;

public class OpenBed : MonoBehaviour
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
            !doorUI.activeSelf &&
            !catUI.activeSelf &&
            !recordUI.activeSelf &&
            !journalUI.activeSelf &&
            !booksUI.activeSelf)
        {
            bedUI.SetActive(true);
        }
    }
}
