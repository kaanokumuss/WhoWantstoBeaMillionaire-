using System.IO;
using UnityEngine;

public static class QuestionsWriter
{
    public static void SaveQuestionToJson(QuestionDataSO questionDataSO)
    {
        string path = Application.dataPath + "/Resources/questions.json"; // JSON dosyanın konumunu belirt
        
        QuestionDataWrapper wrapper = new QuestionDataWrapper
        {
            questions = questionDataSO.questions
        };

        string json = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, json);
        Debug.Log("Questions saved to JSON.");
    }
}