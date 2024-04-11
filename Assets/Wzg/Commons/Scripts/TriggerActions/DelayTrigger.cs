using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// 用来延迟触发一个行为
    /// </summary>
    public class DelayTrigger : MonoBehaviour
    {
        /// <summary>
        /// 延迟触发的时间
        /// </summary>
        public float delayTime = 3;
        /// <summary>
        /// 程序运行时直接计时
        /// </summary>
        public bool PlayOnStart = false;

        public bool RePlayOnEnable = false;
        /// <summary>
        /// 当OnDisable是停止协程
        /// </summary>
        public bool StopTiggerOnOnDisable = true;

        /// <summary>
        /// 延迟触发
        /// </summary>
        public UnityEvent OnDelayTrigger;

        private IEnumerator enumerator;

        private void OnEnable()
        {
            if (RePlayOnEnable)
            {
                Play();
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            if (PlayOnStart)
            {
                Play();
            }
        }
        public void Play()
        {
            enumerator = WaitTimeTrigger(delayTime);
            StartCoroutine(enumerator);
        }

        IEnumerator WaitTimeTrigger(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            OnDelayTrigger?.Invoke();
        }

        private void OnDisable()
        {
            if (StopTiggerOnOnDisable)
            {
                StopCoroutine(enumerator);
            }
        }

    }
}