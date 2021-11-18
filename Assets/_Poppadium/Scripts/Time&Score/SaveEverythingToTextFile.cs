using System.IO;
using UnityEngine;

namespace _Poppadium.Scripts
{
    public class SaveEverythingToTextFile : MonoBehaviour
    {

        #region Fields

        public TimeHolder timeHolder;
        public ScoreCounter scoreCounter;

        #endregion


        #region Methods

        public void CreateText()
        {
            string path = Application.persistentDataPath + "/Score.txt";
        
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "Score Data \n \n");
            }

            string content = "Total Gameplay Time: " + timeHolder.totalTime + ", First Shower Active Time: " +
                             timeHolder.firstShowerActiveTime + ", Second Shower Active Time: " +
                             timeHolder.secondShowerActiveTime + ", Final Score: " + scoreCounter.score; 
             
        
            File.AppendAllText(path,content);
        }

        #endregion
    }
}
