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
        Debug.Log("Computer clicked!");
        if(!calendarUI.activeSelf && !bedUI.activeSelf && !assignmentPanel.activeSelf)
        {
            computerUI.SetActive(true);
            dayPanel.SetActive(true);
            Debug.Log("Set active!");

        }
        
        
    }
}
