using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    public class TaDiaoJianChaPanel : MonoBehaviour
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
            device.content = "各限载装置是否正常(" + toggleStr[0] + ")，钢丝绳有无断丝断股(" + toggleStr[1] + ")、大勾保险装置是否正常(" + toggleStr[2] + ")，塔吊基础有无被水泡(" + toggleStr[3] + ")，地脚螺栓情况(" + toggleStr[4] + ")，标准节螺栓有无松动(" + toggleStr[5] + ")";
            device.OnTriggerAlarm();

        }

    }
}

