using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI questionText; // Assign your QuestionText object here
    public Transform buttonContainer;    // Assign your ButtonContainer (with Vertical Layout Group)
    public GameObject buttonPrefab;      // Assign your ChoiceButton prefab

    [Header("Dialogue Data")]
    public Question[] questions;         // Array of questions to set up in the Inspector

    private int currentQuestionIndex = 0;

    void Start()
    {
        // Display the first question when the game starts.
        DisplayQuestion(currentQuestionIndex);
    }

    // Clears any existing buttons and displays the question at index 'index'
    void DisplayQuestion(int index)
    {
        // Clear previous buttons
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        // Safety check for valid index
        if (index < 0 || index >= questions.Length)
        {
            questionText.text = "End of Dialogue!";
            return;
        }

        Question q = questions[index];
        questionText.text = q.questionText;

        // Create a button for each choice
        for (int i = 0; i < q.choices.Count; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            // Set the text for the button
            TextMeshProUGUI btnText = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (btnText != null)
            {
                btnText.text = q.choices[i];
            }
            else
            {
                // Fallback for legacy UI Text component
                Text legacyText = buttonObj.GetComponentInChildren<Text>();
                if (legacyText != null)
                {
                    legacyText.text = q.choices[i];
                }
            }

            int choiceIndex = i; // capture current value for the listener
            buttonObj.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(q.nextQuestionIndices[choiceIndex]));
        }
    }

    // This method is called when a choice button is clicked.
    public void OnChoiceSelected(int nextQuestionIndex)
    {
        currentQuestionIndex = nextQuestionIndex;
        DisplayQuestion(currentQuestionIndex);
    }
}
