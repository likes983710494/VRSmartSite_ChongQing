using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// ������ʾ����
    /// </summary>
    public class PopTipsPanel : MonoBehaviour
    {
        //public string panelNameIfNeed;

        public string tipsTitle;
        [TextArea]
        public string tipsContext;
        public string okBtnStr;
        public string noBtnStr;
        public UnityEvent onOk;
        public UnityEvent onNo;


        public void OpenPanel()
        {
            
            UIFollowManager.Instance.OpenTipsPanel("TipsPanel", tipsTitle, tipsContext, "��", "", onOk, onNo);
        }
    }
}