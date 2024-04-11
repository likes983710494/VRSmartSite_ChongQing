using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;

namespace Wzg
{
    /// <summary>
    /// 升降机设备
    /// </summary>
    public class ShengJiangJiDevice : DevicesBase
    {
        /// <summary>
        /// 报警状态（0未报警 1预警 2报警）
        /// </summary>
        [Header("报警状态（0未报警 1预警 2报警）")]
        public string alarmState;
        /// <summary>
        /// 报警类型（重量、高度（冲顶）、速度、人数、倾斜）
        /// </summary>
        [Header("报警类型（重量、高度（冲顶）、速度、人数、倾斜）")]
        public string alarmType;
        /// <summary>
        /// 实时人数
        /// </summary>
        [Header("实时人数")]
        public int count;
        /// <summary>
        /// 设备id
        /// </summary>
        [Header("设备id")]
        public string deviceId;
        /// <summary>
        /// 实时方向 0停止 1上 2下
        /// </summary>
        [Header("实时方向 0停止 1上 2下")]
        public string direction;
        /// <summary>
        /// 实时倾斜度1
        /// </summary>
        [Header("实时倾斜度1")]
        public int gradient1;
        /// <summary>
        /// 倾斜百分比1
        /// </summary>
        [Header("倾斜百分比1")]
        public int gradient1Percent;
        /// <summary>
        /// 实时倾斜度2
        /// </summary>
        [Header("实时倾斜度2")]
        public int gradient2;
        /// <summary>
        /// 倾斜百分比2
        /// </summary>
        [Header("倾斜百分比2")]
        public int gradient2Percent;
        /// <summary>
        /// 实时高度
        /// </summary>
        [Header("实时高度")]
        public int height;
        /// <summary>
        /// 高度百分比
        /// </summary>
        [Header("高度百分比")]
        public int heightPercent;
        /// <summary>
        /// 实时速度
        /// </summary>
        [Header("实时速度")]
        public int speed;
        /// <summary>
        /// 实时起重量
        /// </summary>
        [Header("实时起重量")]
        public int weight;
        /// <summary>
        /// 重量百分比
        /// </summary>
        [Header("重量百分比")]
        public int weightPercent;
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string authentication { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string backLock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string disposeState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frontLock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }

        public float uploadDelayTime = 5;
        private float nowTime;
        private IShengJiangJiAlarm shengJiangJiAlarm;
        // Start is called before the first frame update
        void Start()
        {
            shengJiangJiAlarm = GetComponent<IShengJiangJiAlarm>();
            deviceId = RequestURLs.shengJiangJiId;
            projectId = RequestURLs.projectId;
            //alarmState = "0";
            //direction = "0";
            //gradient1 = 0;
            //gradient1Percent = 0;
            //gradient2 = 0;
            //gradient2Percent = 0;
            //height = 0;
            //heightPercent = 0;
            UploadShengJiangJiData();
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
                UploadShengJiangJiData();
            }
        }

        private void UploadShengJiangJiData()
        {
            if (GameManager.IsServer)
            {
                shengJiangJiAlarm.OnTriggerWebRequest(this);
            }
           
        }


        public void AddCount(int num)
        {
            count += num;
            if (count >= 6)
            {
                alarmState = "2";
                alarmType = "重量";
                weight = count * 100;
                weightPercent = 1;
            }
            else if(count > 5 && count < 7)
            {

            }
            UploadShengJiangJiData();
        }


        public void SubCount(int num)
        {
            count -= num;
            if (count < 6 && count >= 0)
            {
                alarmState = "0";
                alarmType = "正常";
                weight = count * 100;
                weightPercent = 1;
            }
            UploadShengJiangJiData();
        }

    }
}