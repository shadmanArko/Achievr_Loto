using System;
using _Poppadium.Scripts.Animation;
using TMPro;
using UnityEngine;

namespace _Poppadium.Scripts
{
    public class FirstShowerActiveTimeSender : MonoBehaviour
    {
        #region Fields

        public bool timeSent;
        public TimeHolder timeHolder;
        public TMP_Text text;
        public GazedAnimation gazedAnimation;

        #endregion

        #region Methods

        public void SendTime()
        {
            if (timeSent == false)
            {
                timeSent = true;
                timeHolder.firstShowerActiveTime = timeHolder.totalTime;
                TimeSpan timeSpan = TimeSpan.FromSeconds(timeHolder.firstShowerActiveTime);
                text.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:D2}";
                gazedAnimation.PopUpGazed();
            }
        }

        #endregion
    }
}
