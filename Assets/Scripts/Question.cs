using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    [TextArea(3, 10)]
    public string questionText;          // The question text

    public List<string> choices = new List<string>();         // List of choices for this question
    public List<int> nextQuestionIndices = new List<int>();     // Corresponding next question indices (or -1 for end)

    // Optional sprites for this question
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
}
