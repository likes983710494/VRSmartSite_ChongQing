
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    #region �����Ϣ
    public class PersonnelList
    {
        public List<PersonnelData> data;
    }
    [Serializable]
    /// <summary>
    /// ��Ա����
    /// </summary>
    public class PersonnelData
    {
        /// <summary>
        /// ��ַ
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// Ա������
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// string
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// ��ְ����
        /// </summary>
        public string hireDate { get; set; }
        /// <summary>
        /// ��ԱId
        /// </summary>
        public string id;// { get; set; }
        /// <summary>
        /// ��֤����
        /// </summary>
        public string idAuthority { get; set; }
        /// <summary>
        /// ֤����Ч�ڽ���
        /// </summary>
        public string idDataEnd { get; set; }
        /// <summary>
        /// ֤����Ч�ڿ�ʼ
        /// </summary>
        public string idDataStart { get; set; }
        /// <summary>
        /// ֤������
        /// </summary>
        public string idNo { get; set; }
        /// <summary>
        /// ֤������
        /// </summary>
        public string idType { get; set; }
        /// <summary>
        /// ��λ����
        /// </summary>
        public string jobType { get; set; }
        /// <summary>
        /// ��λ����X
        /// </summary>
        public float? locationX { get; set; }
        /// <summary>
        /// ��λ����Y
        /// </summary>
        public float? locationY { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string nation { get; set; }
        /// <summary>
        /// �ֻ���
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public string picture { get; set; }
        /// <summary>
        /// ������ĿId
        /// </summary>
        public string projectId;// { get; set; }
        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public string quitDate { get; set; }
        /// <summary>
        /// ʵ����״̬
        /// </summary>
        public string realNameState { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// �Ƿ�μӰ�ȫ��ѵ
        /// </summary>
        public bool? safetyTraining { get; set; }
        /// <summary>
        /// ��Ա������ҵ�ʸ�֤��
        /// </summary>
        public string specialWorkCode { get; set; }
        /// <summary>
        /// ��ְ״̬
        /// </summary>
        public string workState { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public string workType { get; set; }


        //public Sprite sprite { get; set; }
    }


    /// <summary>
    /// ��������
    /// </summary>
    public class HuanJingData
    {
        /// <summary>
        /// �豸Id
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// PM2.5
        /// </summary>
        public float pm25 { get; set; }
        /// <summary>
        /// pm10
        /// </summary>
        public float pm10 { get; set; }
        /// <summary>
        /// �¶�
        /// </summary>
        public float tem { get; set; }
        /// <summary>
        /// ʪ��
        /// </summary>
        public float hum { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public float noise { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public float wp { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public float ws { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public float wd360 { get; set; }
    }


    #endregion

    #region �ϴ���Ϣ
    /// <summary>
    /// ������������Я������
    /// </summary>
    public class HongWaiUploadData
    {
        /// <summary>
        /// 
        /// </summary>
        public string alarmInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmOriginInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceId { get; set; }
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
    }

    /// <summary>
    /// Ѳ������Я������
    /// </summary>
    public class XunJianUploadData
    {
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public string inspectionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string personnelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string personnelName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
    }

    /// <summary>
    /// ��������Я������
    /// </summary>
    public class KaoQinUploadData
    {
        /// <summary>
        /// ʱ��
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// ����id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// �볡��
        /// </summary>
        public string inGate { get; set; }
        /// <summary>
        /// �볡ͼƬ
        /// </summary>
        public string inPicture { get; set; }
        /// <summary>
        /// �볡ʱ��
        /// </summary>
        public string inTime { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public string kaoQinDate { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public string outGate { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string outTime { get; set; }
        /// <summary>
        /// ��Աid
        /// </summary>
        public string personnelId { get; set; }
        /// <summary>
        /// ������ĿId
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public string putPicture { get; set; }
        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public int type { get; set; }
    }



    /// <summary>
    /// ������Post����Я������
    /// </summary>
    public class ShengJiangJiUploadData
    {
        /// <summary>
        /// ����״̬��0δ���� 1Ԥ�� 2������
        /// </summary>
        public string alarmState { get; set; }
        /// <summary>
        /// �������ͣ��������߶ȣ��嶥�����ٶȡ���������б��
        /// </summary>
        public string alarmType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string authentication { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string backLock { get; set; }
        /// <summary>
        /// ʵʱ����
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// �豸id
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// ʵʱ���� 0ֹͣ 1�� 2��
        /// </summary>
        public string direction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string disposeState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string frontLock { get; set; }
        /// <summary>
        /// ʵʱ��б��1
        /// </summary>
        public int gradient1 { get; set; }
        /// <summary>
        /// ��б�ٷֱ�1
        /// </summary>
        public int gradient1Percent { get; set; }
        /// <summary>
        /// ʵʱ��б��2
        /// </summary>
        public int gradient2 { get; set; }
        /// <summary>
        /// ��б�ٷֱ�2
        /// </summary>
        public int gradient2Percent { get; set; }
        /// <summary>
        /// ʵʱ�߶�
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// �߶Ȱٷֱ�
        /// </summary>
        public int heightPercent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// ��ĿID
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// ʵʱ�ٶ�
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// ʵʱ������
        /// </summary>
        public int weight { get; set; }
        /// <summary>
        /// �����ٷֱ�
        /// </summary>
        public int weightPercent { get; set; }
    }

    [Serializable]
    public class ShenJiKengItemUploadData
    {
        /// <summary>
        /// 
        /// </summary>
        //[Serializable]
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int type;
        /// <summary>
        /// 
        /// </summary>
        public int value;
        /// <summary>
        /// 
        /// </summary>
        public int alarm;
        /// <summary>
        /// 
        /// </summary>
        public int isalarm;
    }


    public class ShenJiKengUploadData
    {
        /// <summary>
        /// �豸id
        /// </summary>
        public string devsn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ShenJiKengItemUploadData> data { get; set; }
       
        public void Def()
        {
            for (int i = 0; i < 16; i++)
            {
                ShenJiKengItemUploadData uploadData = new ShenJiKengItemUploadData();
                uploadData.id = "";
                uploadData.type = i + 1;
                uploadData.value = 0;
                uploadData.alarm = 0;
                uploadData.isalarm = 0;
                this.data.Add(uploadData);
            }
        }

    }

    /// <summary>
    /// ж��ƽ̨����
    /// </summary>
    public class XieLiaoUploadData
    {
        /// <summary>
        /// 
        /// </summary>
        public string alarmState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string alarmType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dipAngleX { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int dipAngleY { get; set; }
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
        /// <summary>
        /// 
        /// </summary>
        public int weight { get; set; }
    }

    /// <summary>
    /// �̸б�������Я������
    /// </summary>
    public class YanGanAlarmUploadData
    {
        /// <summary>
        /// 
        /// </summary>
        //public string alarmInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string alarmOriginInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string alarmState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string alarmTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string alarmType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string createTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string deviceType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string disposeState { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string projectId { get; set; }
    }

   



    /// <summary>
    /// ��Ա��λ
    /// </summary>
    public class PutPersonPosData
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }


        /// <summary>
        /// ��λ����X
        /// </summary>
        public float locationX { get; set; }
        /// <summary>
        /// ��λ����Y
        /// </summary>
        public float locationY { get; set; }

    }
    #endregion
}