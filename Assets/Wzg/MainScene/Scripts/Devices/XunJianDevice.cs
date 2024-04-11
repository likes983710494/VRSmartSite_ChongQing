using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// 巡检设备
    /// </summary>
    public class XunJianDevice : DevicesBase
    {
        //0a521158a1037ea1b3082bc937175527   深基坑区域
        //6fda2a5da5067f67013d79d42955cab3   塔吊区域

        /// <summary>
        /// 巡检内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string inspectionArea { get; set; }
        /// <summary>
        /// 巡更点id
        /// </summary>
        [Header("巡更点id")]
        public string inspectionId;
        /// <summary>
        /// 巡检人id
        /// </summary>
        public string personnelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string personnelName { get; set; }
        /// <summary>
        /// 所属项目id
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 巡检状态 0正常 1异常
        /// </summary>
        [Header("巡检状态 0正常 1异常")]
        public string status;

        public IXunJian xunJian;

        void Start()
        {
            xunJian = GetComponent<IXunJian>();
            projectId = RequestURLs.projectId;
            personnelId = WebRequestManager.SelectPersonnelId;
        }
        public void OnTriggerAlarm()
        {
            xunJian.OnTriggerWebRequest(this);
        }
    }
}