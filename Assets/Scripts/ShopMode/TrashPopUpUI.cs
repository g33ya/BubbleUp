using UnityEngine;
using UnityEngine.UI;

public class TrashConfirmUI : MonoBehaviour
{
    public GameObject Panel;        // The popup panel
    public Button yesButton;
    public Button noButton;

    private GameObject cupToTrash;

    void Start()
    {
        Panel.SetActive(false); // Hide popup initially

        yesButton.onClick.AddListener(() => {
            TrashCup();
        });

        noButton.onClick.AddListener(() => {
            Panel.SetActive(false);
            cupToTrash = null;
        });
    }

    public void ShowConfirmation(GameObject cup)
    {
        cupToTrash = cup;
        Panel.SetActive(true);
    }

    private void TrashCup()
    {
        if (cupToTrash != null)
        {
            Destroy(cupToTrash);
            CupButtonSpawner.currentCup = null;
        }

        Panel.SetActive(false);
    }
}
