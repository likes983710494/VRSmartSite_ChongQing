using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// Ѳ���豸
    /// </summary>
    public class XunJianDevice : DevicesBase
    {
        //0a521158a1037ea1b3082bc937175527   ���������
        //6fda2a5da5067f67013d79d42955cab3   ��������

        /// <summary>
        /// Ѳ������
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
        /// Ѳ����id
        /// </summary>
        [Header("Ѳ����id")]
        public string inspectionId;
        /// <summary>
        /// Ѳ����id
        /// </summary>
        public string personnelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string personnelName { get; set; }
        /// <summary>
        /// ������Ŀid
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// Ѳ��״̬ 0���� 1�쳣
        /// </summary>
        [Header("Ѳ��״̬ 0���� 1�쳣")]
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