using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI questionText;    // The text object that displays the question
    public Image questionImage1;            // First image for the sprite
    public Image questionImage2;            // Second image for the sprite
    public Image questionImage3;            // Third image for the sprite
    public Transform buttonContainer;       // Parent container with a Vertical Layout Group for buttons
    public GameObject buttonPrefab;         // Button prefab for choices

    [Header("Dialogue Data")]
    public Question[] questions;            // Array of questions set up in the Inspector

    private int currentQuestionIndex = 0;

    void Start()
    {
        // Display the first question when the game starts.
        DisplayQuestion(currentQuestionIndex);
    }

    // Displays the question at the given index and instantiates the corresponding choice buttons.
    void DisplayQuestion(int index)
    {
        // Clear previous buttons
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        // Safety check for a valid index
        if (index < 0 || index >= questions.Length)
        {
            questionText.text = "You failed Earth and didn't reach Alpha Centauri.";
            if (questionImage1 != null) questionImage1.enabled = false;
            if (questionImage2 != null) questionImage2.enabled = false;
            if (questionImage3 != null) questionImage3.enabled = false;
            return;
        }

        Question q = questions[index];
        questionText.text = q.questionText;

        // Update the images based on the question's sprites.
        UpdateImage(questionImage1, q.sprite1);
        UpdateImage(questionImage2, q.sprite2);
        UpdateImage(questionImage3, q.sprite3);

        // Create a button for each choice.
        for (int i = 0; i < q.choices.Count; i++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);

            // Set the text for the button (supporting TextMeshProUGUI or legacy Text)
            TextMeshProUGUI btnTMP = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (btnTMP != null)
            {
                btnTMP.text = q.choices[i];
            }
            else
            {
                Text btnText = buttonObj.GetComponentInChildren<Text>();
                if (btnText != null)
                {
                    btnText.text = q.choices[i];
                }
            }

            int choiceIndex = i; // Capture the index for the listener.
            buttonObj.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(q.nextQuestionIndices[choiceIndex]));
        }
    }

    // Helper method to update an Image component based on the provided sprite.
    void UpdateImage(Image img, Sprite sprite)
    {
        if (img != null)
        {
            if (sprite != null)
            {
                img.enabled = true;
                img.sprite = sprite;
            }
            else
            {
                img.enabled = false;
            }
        }
    }

    // Called when a choice button is clicked.
    public void OnChoiceSelected(int nextQuestionIndex)
    {
        currentQuestionIndex = nextQuestionIndex;
        DisplayQuestion(currentQuestionIndex);
    }
}
