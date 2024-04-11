using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    public class JiKengJianChaPanel : MonoBehaviour
    {
        public Button button;
        public XunJianDevice device;
        public Toggle[] toggles;
        public string[] toggleStr;
        // Start is called before the first frame update
        void Start()
        {
            toggleStr = new string[toggles.Length];
            button.onClick.AddListener(OnClick);
        }
        private void OnClick()
        {
            device.status = "0";
            
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                {
                    toggleStr[i] = "正常";
                }
                else
                {
                    toggleStr[i] = "异常";
                    device.status = "1";
                }
            }
            device.content = "边坡是否稳定(" + toggleStr[0] + ")，边坡上是否堆载过多(" + toggleStr[1] + ")、边坡上是否堆载过近(" + toggleStr[2] + ")，边坡防护是否到位(" + toggleStr[3] + ")，基坑内积水情况(" + toggleStr[4] + ")";
            device.OnTriggerAlarm();

        }

    }
}

