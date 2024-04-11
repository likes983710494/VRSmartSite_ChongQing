using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class PopPanel : MonoBehaviour
    {
        public string panelName;
        public void OpenPanel()
        {
            UIFollowManager.Instance.OpenPanel(panelName);
        }
    }
}

