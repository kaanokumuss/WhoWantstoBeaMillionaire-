using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
   // [SerializeField] private Board board;
   [SerializeField] private TextMeshProUGUI scoreText;
   
   public int Score { get; private set; }
   
   // private readonly Dictionary<char, int> _letterValues = new()
   // {
   //    { 'E', 1 }, { 'A', 1 }, { 'O', 1 }, { 'N', 1 }, { 'R', 1 }, { 'T', 1 }, { 'L', 1 }, { 'S', 1 }, { 'U', 1 },
   //    { 'I', 1 },
   //    { 'D', 2 }, { 'G', 2 },
   //    { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
   //    { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
   //    { 'K', 5 },
   //    { 'J', 8 }, { 'X', 8 },
   //    { 'Q', 10 }, { 'Z', 10 }
   // };

   public void GainScore(string word)
   {
      // var wordScore = 0;
      //
      // foreach (var letter in word.ToUpperInvariant())
      // {
      //    if (_letterValues.TryGetValue(letter, out var letterScore))
      //    {
      //       wordScore += letterScore;
      //    }
      // }
      //
      // wordScore *= 10 * word.Length;
      //
      // Score = Mathf.Max(0, Score + wordScore);
      // scoreText.text = $"Score: {Score}";
   }

   public void PenaltyScore()
   {
      // var unusedLetters = board.GetActiveTiles().Count;
      //
      // Score = Mathf.Max(0, Score - unusedLetters * 100);
   }
}
