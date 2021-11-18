using System.IO;
using TMPro;
using UnityEngine;

namespace _Poppadium.Scripts
{
    public class ScoreCounter : MonoBehaviour
    {
        #region Fields

        public TimeHolder timeHolder;
        public float scoreLimit;
        public int score;
        public TMP_Text text;
        public StopWatch stopWatch;

        #endregion

        #region Methods

        public void CountScore()
        {
            stopWatch.StopCountdown();
            timeHolder.totalScore = timeHolder.totalTime;
            score = (int) (scoreLimit / timeHolder.totalScore);
            text.text = score.ToString();
            CreateText();
        }
    
        public void CreateText()
        {
            string path = Application.persistentDataPath + "/Score.txt";
        
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Score Data \n \n");
            }

            string content = "Total Gameplay Time: " + timeHolder.totalTime + ", First Shower Active Time: " +
                             timeHolder.firstShowerActiveTime + ", Second Shower Active Time: " +
                             timeHolder.secondShowerActiveTime + ", Final Score: " + score + "\n"; 
        
            File.AppendAllText(path,content);
        }

        #endregion
    }
}
