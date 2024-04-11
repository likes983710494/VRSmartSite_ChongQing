using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;

namespace Wzg
{
    /// <summary>
    /// �������豸
    /// </summary>
    public class ShengJiangJiDevice : DevicesBase
    {
        /// <summary>
        /// ����״̬��0δ���� 1Ԥ�� 2������
        /// </summary>
        [Header("����״̬��0δ���� 1Ԥ�� 2������")]
        public string alarmState;
        /// <summary>
        /// �������ͣ��������߶ȣ��嶥�����ٶȡ���������б��
        /// </summary>
        [Header("�������ͣ��������߶ȣ��嶥�����ٶȡ���������б��")]
        public string alarmType;
        /// <summary>
        /// ʵʱ����
        /// </summary>
        [Header("ʵʱ����")]
        public int count;
        /// <summary>
        /// �豸id
        /// </summary>
        [Header("�豸id")]
        public string deviceId;
        /// <summary>
        /// ʵʱ���� 0ֹͣ 1�� 2��
        /// </summary>
        [Header("ʵʱ���� 0ֹͣ 1�� 2��")]
        public string direction;
        /// <summary>
        /// ʵʱ��б��1
        /// </summary>
        [Header("ʵʱ��б��1")]
        public int gradient1;
        /// <summary>
        /// ��б�ٷֱ�1
        /// </summary>
        [Header("��б�ٷֱ�1")]
        public int gradient1Percent;
        /// <summary>
        /// ʵʱ��б��2
        /// </summary>
        [Header("ʵʱ��б��2")]
        public int gradient2;
        /// <summary>
        /// ��б�ٷֱ�2
        /// </summary>
        [Header("��б�ٷֱ�2")]
        public int gradient2Percent;
        /// <summary>
        /// ʵʱ�߶�
        /// </summary>
        [Header("ʵʱ�߶�")]
        public int height;
        /// <summary>
        /// �߶Ȱٷֱ�
        /// </summary>
        [Header("�߶Ȱٷֱ�")]
        public int heightPercent;
        /// <summary>
        /// ʵʱ�ٶ�
        /// </summary>
        [Header("ʵʱ�ٶ�")]
        public int speed;
        /// <summary>
        /// ʵʱ������
        /// </summary>
        [Header("ʵʱ������")]
        public int weight;
        /// <summary>
        /// �����ٷֱ�
        /// </summary>
        [Header("�����ٷֱ�")]
        public int weightPercent;
        /// <summary>
        /// ��ĿID
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
                alarmType = "����";
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
                alarmType = "����";
                weight = count * 100;
                weightPercent = 1;
            }
            UploadShengJiangJiData();
        }

    }
}