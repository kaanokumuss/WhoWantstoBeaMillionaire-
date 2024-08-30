using System.Collections.Generic;
using UnityEngine;

public class QuestionShaker : MonoBehaviour
{
    public List<int> ShuffleQuestions(int questionCount)
    {
        List<int> indices = new List<int>();

        // Tüm indeksleri listeye ekle
        for (int i = 0; i < questionCount; i++)
        {
            indices.Add(i);
        }

        for (int i = 0; i < indices.Count; i++)
        {
            int randomIndex = Random.Range(0, indices.Count);
            int temp = indices[i];
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        return indices;
    }
}