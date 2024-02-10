using System;
using UnityEngine;

namespace Utils
{
    // Enable and Disable gameobject on start
    public class UIStartEnabler : MonoBehaviour
    {
        public bool IsActive;

        private void Start()
        {
            gameObject.SetActive(IsActive);
        }
    }
}