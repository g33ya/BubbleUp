using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public AudioClip computerSound;
    public Button initialWorkOnButton;
    public Button initialWorkOnButton2;
    public TMP_Text assignmentCompleteText; // Text to display the name of the assignment
    public TMP_Text assignmentCompleteText2; // Text to display the name of the assignment

    void OnMouseDown() {
    Debug.Log("Computer clicked!");

    if (!calendarUI.activeSelf &&
        !catUI.activeSelf&&
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
        SoundPlayer.instance.PlaySFX(computerSound);
    }

    if (PlayerPrefs.GetInt("Assignment1Progress") >= 100)
        {
            initialWorkOnButton.interactable = false; // Lock the button (disable interaction)
            assignmentCompleteText.gameObject.SetActive(true);
        }

    if (PlayerPrefs.GetInt("Assignment2Progress") >= 100)
        {
            initialWorkOnButton2.interactable = false; // Lock the button (disable interaction)
            assignmentCompleteText2.gameObject.SetActive(true);
        }

}
}
