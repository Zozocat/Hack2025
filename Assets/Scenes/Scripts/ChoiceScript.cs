using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceScript : MonoBehaviour
{
    public GameObject TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public int ChoiceMade = 0;

    private Text uiText;
    private TextMeshProUGUI tmpText;

    void Start()
    {
        if (TextBox != null)
        {
            uiText = TextBox.GetComponent<Text>();
            tmpText = TextBox.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogError("TextBox is not assigned in the Inspector!");
        }
    }

    public void ChoiceOption1()
    {
        if (!ValidateTextBox()) return;
        SetText("Meeow Meeow?");
        ChoiceMade = 1;
        HideChoices();
    }

    public void ChoiceOption2()
    {
        if (!ValidateTextBox()) return;
        SetText("AHH IT HURTS KMS?");
        ChoiceMade = 2;
        HideChoices();
    }

    public void ChoiceOption3()
    {
        if (!ValidateTextBox()) return;
        SetText("WHY SJAHFJHK?");
        ChoiceMade = 3;
        HideChoices();
    }

    void SetText(string message)
    {
        if (uiText != null)
        {
            uiText.text = message;
        }
        else if (tmpText != null)
        {
            tmpText.text = message;
        }
        else
        {
            Debug.LogError("TextBox does not have a Text or TextMeshProUGUI component!");
        }
    }

    void HideChoices()
    {
        if (Choice01 == null || Choice02 == null || Choice03 == null)
        {
            Debug.LogError("One or more choice buttons are not assigned in the Inspector!");
            return;
        }
        Choice01.SetActive(false);
        Choice02.SetActive(false);
        Choice03.SetActive(false);
    }

    bool ValidateTextBox()
    {
        if (TextBox == null)
        {
            Debug.LogError("TextBox is not assigned in the Inspector!");
            return false;
        }
        if (uiText == null && tmpText == null)
        {
            Debug.LogError("TextBox does not have a Text or TextMeshProUGUI component!");
            return false;
        }
        return true;
    }
}
