using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionDataSO", menuName = "Quiz/Question Data")]
public class QuestionDataSO : ScriptableObject
{
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public List<string> options;
        public string correctAnswer;
    }

    public List<Question> questions;
}