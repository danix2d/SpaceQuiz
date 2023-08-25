using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public GameEvent CorrectAnswer;
    public GameEvent WrongAnswer;

    public IntVariable answeredQuestions;
    public TMP_Text text;
    public bool isCorrectAnswer;
    
    public void SelectAnswer()
    {
        if (isCorrectAnswer)
        {
            answeredQuestions.Value++;
            CorrectAnswer.Raise();
        }
        else
        {
            WrongAnswer.Raise();
        }
    }
}
