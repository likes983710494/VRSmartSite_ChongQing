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
                    toggleStr[i] = "����";
                }
                else
                {
                    toggleStr[i] = "�쳣";
                    device.status = "1";
                }
            }
            device.content = "�����Ƿ��ȶ�(" + toggleStr[0] + ")���������Ƿ���ع���(" + toggleStr[1] + ")���������Ƿ���ع���(" + toggleStr[2] + ")�����·����Ƿ�λ(" + toggleStr[3] + ")�������ڻ�ˮ���(" + toggleStr[4] + ")";
            device.OnTriggerAlarm();

        }

    }
}

