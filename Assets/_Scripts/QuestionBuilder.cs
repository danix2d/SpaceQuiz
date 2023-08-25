using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionBuilder : MonoBehaviour
{
    public TMP_Text questionText;
    public List<Button> buttons = new List<Button>();

    private QuestionSO _question;
    public void BuildQuestion(QuestionSO question)
    {
        _question = question;

        questionText.text = question.question;

        for (int i = 0; i < buttons.Count; i++)
        {
            Button temp = buttons[i];
            int randomIndex = Random.Range(i, buttons.Count);
            buttons[i] = buttons[randomIndex];
            buttons[randomIndex] = temp;
        }

        for (int j = 0; j < buttons.Count; j++)
        {
            Answer answer = buttons[j].GetComponent<Answer>();
            answer.isCorrectAnswer = false;
            answer.text.text = question.answers[j];
            if(j == 0)
            {
                answer.isCorrectAnswer = true;
            }
        }
    }

    public void CorrectAnswer()
    {
        questionText.text = "That's Correct!";
    }

    public void WrongAnswer()
    {
        questionText.text = $"Wrong answer! Correct answer is {_question.answers[0]}!";
    }
}

