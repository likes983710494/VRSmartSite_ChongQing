using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Wzg
{
    public class TipsPanel : PanelBase
    {
        public Text tipsTitle;
        public Text tipsContext;
        public Button okBtn;
        public Button noBtn;
        public UnityEvent onOk;
        public UnityEvent onNo;
        private void Start()
        {
            if (okBtn)
            {
                okBtn.onClick.AddListener(() => { gameObject.SetActive(false); onOk?.Invoke(); });
            }
            if (noBtn)
            {
                noBtn.onClick.AddListener(() => { gameObject.SetActive(false); onNo?.Invoke(); });
            }
        }


        public void OnShow(string title, string context,string okStr,string noStr, UnityEvent onOk = null, UnityEvent onNo = null)
        {
            tipsTitle.text = title;
            tipsContext.text = context;
            okBtn.gameObject.SetActive(false);
            noBtn.gameObject.SetActive(false);
            if (okStr.Length != 0)
            {
                okBtn.gameObject.SetActive(true);
                this.onOk = onOk;
                okBtn.transform.GetChild(0).GetComponent<Text>().text = okStr;
            }
            else
            {
                okBtn.gameObject.SetActive(false);
            }
            if (noStr.Length != 0)
            {
                noBtn.gameObject.SetActive(true);
                this.onNo = onNo;
                noBtn.transform.GetChild(0).GetComponent<Text>().text = noStr;
            }
            else
            {
                noBtn.gameObject.SetActive(false);
            }
        }
    }
}