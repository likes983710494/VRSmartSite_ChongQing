using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Wzg
{
    public class ChangeControllerManager : MonoBehaviour
    {
        public InputActionProperty rightTouchActionProperty;
        public InputActionProperty leftTouchActionProperty;
        private InputAction rightTouchAction;
        private InputAction leftTouchAction;

        public GameObject rightRayController;
        public GameObject leftRayController;

        void Start()
        {
            rightTouchAction = rightTouchActionProperty.action;
            leftTouchAction = leftTouchActionProperty.action;
        }

        private void Update()
        {
            Vector2 rightTriggerValue = rightTouchAction.ReadValue<Vector2>();
            Debug.Log(rightTriggerValue);
            //animator.SetFloat("Trigger", triggerValue);
            if(rightTriggerValue.y > 0.1f)
            {
                rightRayController.SetActive(true);
            }
            else
            {
                rightRayController.SetActive(false);
            }
            //float leftTriggerValue = leftTouchAction.ReadValue<float>();
            ////animator.SetFloat("Grip", gripValue);
            //if(leftTriggerValue > 0.1f)
            //{
            //    leftRayController.SetActive(true);
            //}
            //else
            //{
            //    leftRayController.SetActive(false);
            //}
        }
    }
}