using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// �����豸
    /// </summary>
    public class HongWaiDevice : DevicesBase
    {
        public Animation animPlayer;
        /// <summary>
        /// ���ⱨ��
        /// </summary>
        [Header("������Ϣ")]
        public string alarmInfo;
        /// <summary>
        /// 
        /// </summary>
        public string alarmOriginInfo { get; set; }
        /// <summary>
        /// ����״̬
        /// </summary>
        [Header("����״̬")]
        public string alarmState;
        /// <summary>
        /// 
        /// </summary>
        public string alarmTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Header("��������")]
        public string alarmType;
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Header("�豸ID")]
        public string deviceId;
        /// <summary>
        /// 
        /// </summary>
        public string deviceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string disposeState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string projectId { get; set; }

        public IHongWaiAlarm hongWaiAlarm;

        // Start is called before the first frame update
        void Start()
        {
            hongWaiAlarm = GetComponent<IHongWaiAlarm>();
            projectId = RequestURLs.projectId;
            deviceId = RequestURLs.hongwaiId;
        }

        public void PlayHongWaiAnim()
        {
            gameObject.SetActive(true);
            animPlayer.Play();
        }
        /// <summary>
        /// �÷������ڷ�ǽ�������ŵ�ָ��֡ʱ���������ע���ﶯ���ؼ�֡�¼�
        /// </summary>
        public void OnTriggerHongWaiAlarm()
        {
            if (GameManager.IsServer)
            {
                Debug.Log("�����˺��ⱨ��");
                //alarmTime = WebRequestManager.Instance.GetNorTime();
                hongWaiAlarm.OnTriggerWebRequest(this);
            }
        }
    }
}