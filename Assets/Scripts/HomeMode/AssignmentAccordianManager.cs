using UnityEngine;
using System.Collections.Generic;

public class AssignmentAccordionManager : MonoBehaviour
{
    public List<AssignmentListToggle> dayToggles;

    public void ToggleDay(AssignmentListToggle selectedToggle)
    {
        // Only proceed if the selected toggle isn't already expanded
        if (!selectedToggle.IsExpanded())
        {
            foreach (var toggle in dayToggles)
            {
                if (toggle != selectedToggle)
                    toggle.Collapse();
            }

            selectedToggle.ToggleAssignments();
        }
    }
}
