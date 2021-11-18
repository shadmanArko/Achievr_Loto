using DG.Tweening;
using UnityEngine;

namespace _Poppadium.Scripts.Animation
{
    public class GazedAnimation : MonoBehaviour
    {
        public Vector3 destination;
        public float duration;
        public FirstShowerActiveTimeSender firstShowerActiveTimeSender;
        public SecondShowerActiveTimeSender secondShowerActiveTimeSender;

        [ContextMenu("Pop up gazed")]
        public void PopUpGazed()
        {
            if (firstShowerActiveTimeSender.timeSent  && secondShowerActiveTimeSender.timeSent )
            {
                transform.DOMove(destination, duration);
            }
        }
    
    }
}
