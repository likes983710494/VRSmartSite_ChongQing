using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// 烟感设备
    /// </summary>
    public class YanGanDevice : DevicesBase
    {
        /// <summary>
        /// 
        /// </summary>
        //[Header("报警信息")]
        public string alarmInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string alarmOriginInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Header("报警状态")]
        public string alarmState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[Header("报警类型")]
        public string alarmType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Header("设备id")]
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