using System;
using _Poppadium.Scripts.Animation;
using TMPro;
using UnityEngine;

namespace _Poppadium.Scripts
{
    public class SecondShowerActiveTimeSender : MonoBehaviour
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
                timeHolder.secondShowerActiveTime = timeHolder.totalTime;
                TimeSpan timeSpan = TimeSpan.FromSeconds(timeHolder.secondShowerActiveTime);
                text.text = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:D2}";
                timeSent = true;
                gazedAnimation.PopUpGazed();
            }
        }

        #endregion
    }
}
