using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText;          // The question text
    public List<string> choices;         // List of choices for this question
    public List<int> nextQuestionIndices; // Corresponding next question indices (or -1 for end)
}
