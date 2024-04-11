using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Wzg
{
    public class AppExit : MonoBehaviour
    {
        public InputActionProperty leftMenuInputActionProperty;
        private InputAction leftMenuInputAction;

        public InputActionProperty rightMenuInputActionProperty;
        private InputAction rightMenuInputAction;
        void Start()
        {
            leftMenuInputAction = leftMenuInputActionProperty.action;
            rightMenuInputAction = rightMenuInputActionProperty.action;
           
        }


        void Update()
        {
            bool isLeftTrigger = leftMenuInputAction != null && leftMenuInputAction.triggered;
            if (isLeftTrigger)
            {
                OnAppExit();
            }
            bool isRightTrigger = rightMenuInputAction != null && rightMenuInputAction.triggered;
            if (isRightTrigger)
            {
                OnAppExit();
            }
        }


        private void OnAppExit()
        {
            bool openState = UIFollowManager.Instance.PanelState("MenuPanel");
            if (openState)
            {
                UIFollowManager.Instance.ClosePanel("MenuPanel");
            }
            else
            {
                UIFollowManager.Instance.OpenPanel("MenuPanel");
            }
        }
        
    }
}

