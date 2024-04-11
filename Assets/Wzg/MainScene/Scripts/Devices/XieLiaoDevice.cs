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
        /// ����״̬��0δ���� 1Ԥ�� 2������
        /// </summary>
        [Header("����״̬��0δ���� 1Ԥ�� 2������")]
        public string alarmState;
        /// <summary>
        /// �������ͣ���������б��
        /// </summary>
        [Header("�������ͣ���������б��")]
        public string alarmType;
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// �豸id
        /// </summary>
        [Header("�豸ID")]
        public string deviceId;
        /// <summary>
        /// ���X
        /// </summary>
        [Header("���X")]
        public int dipAngleX;
        /// <summary>
        /// ���Y
        /// </summary>
        [Header("���Y")]
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
        /// ������Ŀid
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        [Header("����")]
        public int weight;

        [Header("�������ݼ��")]
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
                    alarmType = "����";
                    dipAngleX = 0;
                    dipAngleY = 0;
                }
                else
                {
                    alarmState = "2";
                    alarmType = "��б";
                    dipAngleX = 15;
                    dipAngleY = 0;
                }
                xieLiaoAlarm.OnTriggerWebRequest(this);
            }
           
        }
    }
}