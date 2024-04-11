using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Wzg
{
    /// <summary>
    /// 界面的基类
    /// </summary>
    public class PanelBase : MonoBehaviour
    {
        public UnityEvent onOpen { get; set; }
        public UnityEvent onClose{ get; set; }

    private void OnEnable()
        {
            onOpen?.Invoke();
        }
        private void OnDisable()
        {
            onClose?.Invoke();
        }
    }
}