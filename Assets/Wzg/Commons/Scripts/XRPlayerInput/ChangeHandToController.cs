using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Wzg
{
    public class ChangeHandToController : MonoBehaviour
    {
        public InputActionProperty actionProperty;
        private InputAction inputAction;

        public GameObject handObject;
        public GameObject controllerObject;

        void Start()
        {
            inputAction = actionProperty.action;
        }


        void Update()
        {
            bool isLeftTrigger = inputAction != null && inputAction.triggered;
            if (isLeftTrigger)
            {
                OnAppExit();
            }
        }
        private void OnAppExit()
        {
            if (handObject.activeSelf)
            {
                handObject.SetActive(false);
                controllerObject.SetActive(true);
            }
            else
            {
                handObject.SetActive(true);
                controllerObject.SetActive(false);
            }
        }


    }
}

