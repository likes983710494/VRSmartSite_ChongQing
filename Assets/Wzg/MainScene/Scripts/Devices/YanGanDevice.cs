using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// �̸��豸
    /// </summary>
    public class YanGanDevice : DevicesBase
    {
        /// <summary>
        /// 
        /// </summary>
        //[Header("������Ϣ")]
        public string alarmInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string alarmOriginInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Header("����״̬")]
        public string alarmState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Header("��������")]
        public string alarmType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Header("�豸id")]
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

        public IYanGanAlarm yanGanAlarm;

        void Start()
        {
            yanGanAlarm = GetComponent<IYanGanAlarm>();
            projectId = RequestURLs.projectId;
            deviceId = RequestURLs.yanGanId;
        }
        public void OnTriggerYanGanAlarm()
        {
            yanGanAlarm.OnTriggerWebRequest(this);
        }
    }
}