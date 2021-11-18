using UnityEngine;

namespace _Poppadium.Scripts
{
   public class ActivateTimer : MonoBehaviour
   {
      #region Fields

      public StopWatch stopWatch;

      #endregion

   
      #region Methods

      private void OnTriggerEnter(Collider other)
      {
         if (other.gameObject.CompareTag($"Grabber"))
         {
            stopWatch.StartCountdown();
         }
      }

      #endregion
   }
}
