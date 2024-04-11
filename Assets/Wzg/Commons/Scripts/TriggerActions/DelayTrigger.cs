using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// �����ӳٴ���һ����Ϊ
    /// </summary>
    public class DelayTrigger : MonoBehaviour
    {
        /// <summary>
        /// �ӳٴ�����ʱ��
        /// </summary>
        public float delayTime = 3;
        /// <summary>
        /// ��������ʱֱ�Ӽ�ʱ
        /// </summary>
        public bool PlayOnStart = false;

        public bool RePlayOnEnable = false;
        /// <summary>
        /// ��OnDisable��ֹͣЭ��
        /// </summary>
        public bool StopTiggerOnOnDisable = true;

        /// <summary>
        /// �ӳٴ���
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