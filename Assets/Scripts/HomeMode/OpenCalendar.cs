using UnityEngine;

public class OpenCalendar : MonoBehaviour
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
            !bedUI.activeSelf && 
            !booksUI.activeSelf &&
            !doorUI.activeSelf &&
            !recordUI.activeSelf &&
            !journalUI.activeSelf &&
            !recordUI.activeSelf)
        {
            calendarUI.SetActive(true);
        }
    }
}
