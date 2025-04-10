using UnityEngine;

public class OpenComputer : MonoBehaviour
{
    public GameObject computerUI;
    public GameObject dayPanel;
    public GameObject assignmentPanel;

    void OnMouseDown()
    {
        if(assignmentPanel.activeSelf == false)
        {
            computerUI.SetActive(true);
            dayPanel.SetActive(true);
        }
        
        
    }
}
