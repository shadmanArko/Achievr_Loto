using UnityEngine;

namespace _Poppadium.Scripts
{
    [CreateAssetMenu]
    public class TimeHolder : ScriptableObject
    {
        #region Fields

        public float totalTime;
        public float firstShowerActiveTime;
        public float secondShowerActiveTime;
        public float pushButtonPressedTime;
        public float totalScore;

        #endregion
    }
}
