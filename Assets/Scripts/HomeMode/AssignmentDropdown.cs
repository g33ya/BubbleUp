using UnityEngine;
using UnityEngine.UI;

public class AssignmentListToggle : MonoBehaviour
{
    public GameObject assignmentsPanel; // only the panel with assignments!
    public AssignmentAccordionManager manager;
    private bool isExpanded = false;

    void Start()
    {
        assignmentsPanel.SetActive(false);
    }

    public void ToggleAssignments()
    {
        isExpanded = true;
        assignmentsPanel.SetActive(true);
    }

    public void Collapse()
    {
        isExpanded = false;
        assignmentsPanel.SetActive(false);
    }

    public bool IsExpanded()
    {
        return isExpanded;
    }
}
