using System;
using TMPro;
using UnityEngine;

namespace _Poppadium.Scripts
{
    public class PushButtonPressedTimeSender : MonoBehaviour
    {
        #region Fields

        public bool timeSent;
        public TimeHolder timeHolder;
        public TMP_Text text;

        #endregion

        #region Methods

        public void SendTime()
        {
            if (timeSent == false)
            {
                timeHolder.pushButtonPressedTime = timeHolder.totalTime;
                TimeSpan timeSpan = TimeSpan.FromSeconds(timeHolder.pushButtonPressedTime);
                text.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:D2}";
                timeSent = true;
            }
        }

        #endregion
    }
}
