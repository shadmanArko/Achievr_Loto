using DG.Tweening;
using UnityEngine;

namespace _Poppadium.Scripts.Animation
{
    public class PushButtonAnimatiion : MonoBehaviour
    {
        public PushButtonPressedTimeSender pushButtonPressedTimeSender;
        public Transform buttonDownPosition;
        public Transform buttonUpPosition;
        public float duration;
        public ScoreCounter scoreCounter;
    
    
        [ContextMenu("ButtonDown")]
        public void ButtonDown()
        {
            transform.DOMove(buttonDownPosition.position, duration);
            pushButtonPressedTimeSender.SendTime();
            scoreCounter.CountScore();
        }
    
        [ContextMenu("ButtonUp")]
        public void ButtonUp()
        {
            transform.DOMove(buttonUpPosition.position, duration);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag($"Grabber"))
            {
                ButtonDown();
            }
        }

        // private void OnTriggerExit(Collider other)
        // {
        //     if (other.gameObject.CompareTag("Grabber"))
        //     {
        //         ButtonUp();
        //     }
        // }
    }
}
