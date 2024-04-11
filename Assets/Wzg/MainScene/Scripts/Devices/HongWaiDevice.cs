using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// 红外设备
    /// </summary>
    public class HongWaiDevice : DevicesBase
    {
        public Animation animPlayer;
        /// <summary>
        /// 红外报警
        /// </summary>
        [Header("报警信息")]
        public string alarmInfo;
        /// <summary>
        /// 
        /// </summary>
        public string alarmOriginInfo { get; set; }
        /// <summary>
        /// 报警状态
        /// </summary>
        [Header("报警状态")]
        public string alarmState;
        /// <summary>
        /// 
        /// </summary>
        public string alarmTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Header("报警类型")]
        public string alarmType;
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Header("设备ID")]
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
        /// 该方法会在翻墙动画播放到指定帧时触发，请关注人物动画关键帧事件
        /// </summary>
        public void OnTriggerHongWaiAlarm()
        {
            if (GameManager.IsServer)
            {
                Debug.Log("触发了红外报警");
                //alarmTime = WebRequestManager.Instance.GetNorTime();
                hongWaiAlarm.OnTriggerWebRequest(this);
            }
        }
    }
}