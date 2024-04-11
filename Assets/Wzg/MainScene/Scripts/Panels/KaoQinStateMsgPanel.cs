using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    /// <summary>
    /// 显示考勤是否成功的面板，在闸机处使用。
    /// 如果考勤成功会弹出考勤信息
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
                kaoQinState.text = "上班打卡成功！";
                PlayerStateInstance.Instance.firstKaoQinIn = true;
            }
            else
            {
                kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
                kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
                kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
                kaoQinState.color = Color.green;
                kaoQinState.text = "人员验证成功！";
            }
        }
        public void OnInFailShow()
        {
            gameObject.SetActive(true);
            kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
            kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
            kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
            kaoQinState.color = Color.red;
            kaoQinState.text = "打卡失败，请联系管理员！";
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
                kaoQinState.text = "下班打卡成功！";
                PlayerStateInstance.Instance.firstKaoQinOut = true;
            }
            else
            {
                kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
                kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
                kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
                kaoQinState.color = Color.green;
                kaoQinState.text = "更新下班打卡成功！";
            }
        }
        public void OnOutFailShow()
        {
            gameObject.SetActive(true);
            kaoQinImage.sprite = WebRequestManager.SelectPersonnelSprite;
            kaoQinName.text = WebRequestManager.SelectPersonnelData.name;
            kaoQinCode.text = WebRequestManager.SelectPersonnelData.code;
            kaoQinState.color = Color.red;
            kaoQinState.text = "打卡失败，请联系管理员！";
        }
    }
}