using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputTextManager: MonoBehaviour //ChatGPT helped with some construction of this code
{
    public GameObject rJournalUI;
    public TMP_InputField inputField;
    public TMP_Text warningText;
    public GameObject closeButton;
    public Button submitButton;

    public TimeManager timeManager;

    void Start()
    {
        warningText.gameObject.SetActive(false);
        rJournalUI.gameObject.SetActive(false);
        submitButton.onClick.AddListener(ValidateInput);
        closeButton.GetComponent<Button>().onClick.AddListener(CloseBook);

    }

    void ValidateInput()
    {
        string userInput = inputField.text;
        int wordCount = CountWords(userInput);
        inputField.characterLimit = 1000;


        if (wordCount < 20)
        {
            warningText.text = $"Please write at least 20 words. You’ve written {wordCount}.";
            warningText.color = Color.red;
            warningText.gameObject.SetActive(true);
        }
        else
        {
            warningText.text = "Thanks! You've written enough.";
            warningText.color = Color.green;
            warningText.gameObject.SetActive(true);
            SceneManager.LoadScene("OutsideCafeScene");
            // You can continue your logic here (e.g., save input, close UI, etc.)
        }
    }

    int CountWords(string input)
    {
        // Split input by space and filter out empty strings
        string[] words = input.Split(' ', '\n', '\t');
        int count = 0;
        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                count++;
            }
        }
        return count;
    }

    // Hides Menu
    public void CloseBook()
    {
        rJournalUI.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseBook();
        }
    }
}
