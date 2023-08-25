using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateQuestionsSO", fileName = "Question")]
public class QuestionSO : ScriptableObject
{
    public Sprite spriteImage;

    public string question;

    [Header("The right answer is aways the first element.")]
    public List<string> answers;

    public Difficulty difficulty;
    public Category category;
}

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public enum Category
{
    Food,
    Books,
    Music,
    Math
}