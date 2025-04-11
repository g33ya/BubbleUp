using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject computerUI;
    public GameObject dayPanel;
    public GameObject assignmentPanel;
    public GameObject calendarUI;

    void OnMouseDown()
    {
        if(!assignmentPanel.activeSelf && !calendarUI.activeSelf)
        {
            computerUI.SetActive(true);
            dayPanel.SetActive(true);
        }
        
        
    }
}
