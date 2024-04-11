using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class XieLiaoDevice : DevicesBase
    {
        /// <summary>
        /// 报警状态（0未报警 1预警 2报警）
        /// </summary>
        [Header("报警状态（0未报警 1预警 2报警）")]
        public string alarmState;
        /// <summary>
        /// 报警类型（重量、倾斜）
        /// </summary>
        [Header("报警类型（重量、倾斜）")]
        public string alarmType;
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        [Header("设备ID")]
        public string deviceId;
        /// <summary>
        /// 倾角X
        /// </summary>
        [Header("倾角X")]
        public int dipAngleX;
        /// <summary>
        /// 倾角Y
        /// </summary>
        [Header("倾角Y")]
        public int dipAngleY;
        /// <summary>
        /// 
        /// </summary>
        public string disposeState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 所属项目id
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        [Header("重量")]
        public int weight;

        [Header("更新数据间隔")]
        public float uploadDelayTime = 60;
        private float nowTime;

        private IXieLiaoAlarm xieLiaoAlarm;

        // Start is called before the first frame update
        void Start()
        {
            xieLiaoAlarm = GetComponent<IXieLiaoAlarm>();
            deviceId = RequestURLs.xieLiaoPingTaiId;
            projectId = RequestURLs.projectId;
            OnTriggerXieLiaoAlarm();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if (nowTime < uploadDelayTime)
            {
                nowTime += Time.fixedDeltaTime;
            }
            if (nowTime >= uploadDelayTime)
            {
                nowTime = 0;
                OnTriggerXieLiaoAlarm();
            }
        }

        public void OnAddWeight()
        {
            if (GameManager.IsServer)
            {
                weight = 600;
                OnTriggerXieLiaoAlarm();
            }
           
        }

        public void OnTriggerXieLiaoAlarm()
        {
            if (GameManager.IsServer)
            {
                if (weight < 550)
                {
                    alarmState = "0";
                    alarmType = "正常";
                    dipAngleX = 0;
                    dipAngleY = 0;
                }
                else
                {
                    alarmState = "2";
                    alarmType = "倾斜";
                    dipAngleX = 15;
                    dipAngleY = 0;
                }
                xieLiaoAlarm.OnTriggerWebRequest(this);
            }
           
        }
    }
}