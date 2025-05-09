using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject computerUI;
    public GameObject dayPanel;
    public GameObject assignmentPanel;
    public GameObject calendarUI;
    public GameObject bedUI;
    public GameObject doorUI;
    public GameObject catUI;
    public GameObject recordUI;
    public GameObject journalUI;
    public GameObject booksUI;

    void OnMouseDown() {
    Debug.Log("Computer clicked!");

    if (!calendarUI.activeSelf &&
        !bedUI.activeSelf &&
        !assignmentPanel.activeSelf &&
        !booksUI.activeSelf &&
        !doorUI.activeSelf &&
        !recordUI.activeSelf &&
        !journalUI.activeSelf)
    {
        computerUI.SetActive(true);
        dayPanel.SetActive(true);
        Debug.Log("Computer UI and Day Panel activated!");
    }
}
}
