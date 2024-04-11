using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    /// <summary>
    /// ��ʾ�����Ƿ�ɹ�����壬��բ����ʹ�á�
    /// ������ڳɹ��ᵯ��������Ϣ
    /// </summary>
    public class KaoQinStateMsgPanel : MonoBehaviour
    {
        public Image kaoQinImage;
        public Text kaoQinName;
        public Text kaoQinCode;
        public Text kaoQinState;

        public void OnInSuccessShow()
        {
            gameObject.SetActive(true);
            if(PlayerStateInstance.Instance.firstKaoQinIn == false)
            {
                kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
                kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
                kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
                kaoQinState.color = Color.green;
                kaoQinState.text = "�ϰ�򿨳ɹ���";
                PlayerStateInstance.Instance.firstKaoQinIn = true;
            }
            else
            {
                kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
                kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
                kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
                kaoQinState.color = Color.green;
                kaoQinState.text = "��Ա��֤�ɹ���";
            }
        }
        public void OnInFailShow()
        {
            gameObject.SetActive(true);
            kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
            kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
            kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
            kaoQinState.color = Color.red;
            kaoQinState.text = "��ʧ�ܣ�����ϵ����Ա��";
        }

        public void OnOutSuccessShow()
        {
            gameObject.SetActive(true);
            if (PlayerStateInstance.Instance.firstKaoQinOut == false)
            {
                kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
                kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
                kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
                kaoQinState.color = Color.green;
                kaoQinState.text = "�°�򿨳ɹ���";
                PlayerStateInstance.Instance.firstKaoQinOut = true;
            }
            else
            {
                kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
                kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
                kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
                kaoQinState.color = Color.green;
                kaoQinState.text = "�����°�򿨳ɹ���";
            }
        }
        public void OnOutFailShow()
        {
            gameObject.SetActive(true);
            kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
            kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
            kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
            kaoQinState.color = Color.red;
            kaoQinState.text = "��ʧ�ܣ�����ϵ����Ա��";
        }
    }
}