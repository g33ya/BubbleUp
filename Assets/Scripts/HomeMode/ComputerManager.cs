using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerManager : MonoBehaviour
{
    Assignment assignment1;
    Assignment assignment2;
    public Button startWorkingButton;
    public TMP_Dropdown dropdown; // Used to get duration to work on assignment
    public TMP_Text currentProgressText; // Used to display current progress of assignment
    public TMP_Text stressText; // Used to display stress level of the player
    public TMP_Text energyText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Assignment assignment1 = new Assignment("Assignment 1", 180);
        startWorkingButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        int selectedIndex = dropdown.value;  // Get selected index
        string selectedOption = dropdown.options[selectedIndex].text;  // Get selected option's text

        if (selectedOption == "30 min")
        {
            assignment1.UpdateProgress(10);
        }
        else if (selectedOption == "1 hr")
        {
            assignment1.UpdateProgress(20);
        }
        else if (selectedOption == "2 hr")
        {
            assignment1.UpdateProgress(40);
        }
        else if (selectedOption == "3 hr")
        {
            assignment1.UpdateProgress(60);
        }
        else if (selectedOption == "4 hr")
        {
            assignment1.UpdateProgress(80);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
