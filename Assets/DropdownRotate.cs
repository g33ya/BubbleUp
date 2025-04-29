using UnityEngine;

public class RotateDropdownIcon : MonoBehaviour
{
    public RectTransform dropdownIcon;
    private bool isExpanded = false;

    public void ToggleRotation()
    {
        isExpanded = !isExpanded;

        // Flip between 0 (down) and 180 (up) degrees on the Z-axis
        float targetAngle = isExpanded ? 180f : 0f;
        dropdownIcon.rotation = Quaternion.Euler(0, 0, targetAngle);
    }
}
