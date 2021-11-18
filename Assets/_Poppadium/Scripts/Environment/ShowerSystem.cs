using UnityEngine;

namespace _Poppadium.Scripts.Environment
{
    public class ShowerSystem : MonoBehaviour
    {
        #region Fields

        public ParticleSystem rainParticle;
        public float showerDurationInSecond;
        public bool firstShower;
        public FirstShowerActiveTimeSender firstShowerActiveTimeSender;
        public SecondShowerActiveTimeSender secondShowerActiveTimeSender;

        #endregion

        #region Methods

        private void OnTriggerEnter(Collider other)
        {
            CancelInvoke();
            StartShower();
            Invoke(nameof(StopShower), showerDurationInSecond);
            if (firstShower)
            {
                firstShowerActiveTimeSender.SendTime();
            }

            if (!firstShower)
            {
                secondShowerActiveTimeSender.SendTime();
            }
        }

        private void StartShower()
        {
            rainParticle.Play();
        }
    
        private void StopShower()
        {
            rainParticle.Stop();
        }

        #endregion
    
    }
}
