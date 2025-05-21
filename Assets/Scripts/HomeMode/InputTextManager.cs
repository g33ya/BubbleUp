using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputTextManager: MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text warningText;
    public Button submitButton;

    void Start()
    {
        warningText.gameObject.SetActive(false);
        submitButton.onClick.AddListener(ValidateInput);
    }

    void ValidateInput()
    {
        string userInput = inputField.text;
        int wordCount = CountWords(userInput);

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
}
