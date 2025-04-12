using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject computerUI;
    public GameObject dayPanel;
    public GameObject assignmentPanel;
    public GameObject calendarUI;
    public GameObject bedUI;

    void OnMouseDown()
    {
        if(!assignmentPanel.activeSelf && !calendarUI.activeSelf && !bedUI.activeSelf)
        {
            computerUI.SetActive(true);
            dayPanel.SetActive(true);
        }
        
        
    }
}
