using System;
using TMPro;
using UnityEngine;

namespace _Poppadium.Scripts.Environment
{
    public class ViewportPointToRay : MonoBehaviour
    {
        #region Fields

        private Camera _camera;

        public TMP_Text text;

        #endregion

        #region Methods

        void Start()
        {
            _camera = GetComponent<Camera>();
        }

        void Update()
        {
            Ray ray = _camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                //print("I'm looking at " + hit.transform.name);
            {
                if (hit.transform.gameObject.GetComponent<LookingTimeCounter>() != null)
                {
                    hit.transform.gameObject.GetComponent<LookingTimeCounter>().time+= Time.deltaTime;
                    TimeSpan timeSpan = TimeSpan.FromSeconds(hit.transform.gameObject.GetComponent<LookingTimeCounter>().time);
                    text.text = hit.transform.name + "  " +
                                $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}:{timeSpan.Milliseconds:D2}";
                }
                else
                {
                    hit.transform.gameObject.AddComponent<LookingTimeCounter>();
                }
            }
        }

        #endregion
    }
}
