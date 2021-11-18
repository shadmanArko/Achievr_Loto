using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace _Poppadium.Scripts
{
    public class StopWatch : MonoBehaviour
    {
        #region Fields

        public TMP_Text timer;
        public float time;
        public TimeHolder timeHolder;
        
        #endregion

        
        #region Methods

        [ContextMenu("Start Countdown")]
        public void StartCountdown()
        {
            StartCoroutine(nameof(StopWatchTimer));
        }
    
        public void StopCountdown()
        {
            StopCoroutine(nameof(StopWatchTimer));
        }
    
        IEnumerator StopWatchTimer()
        {
            while (true)
            {
                time += Time.deltaTime;
            
                TimeSpan timeSpan = TimeSpan.FromSeconds(time);
            
                timeHolder.totalTime = time;

                timer.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:D2}";

                yield return null;
            }
        }

        #endregion
    
    }
}
