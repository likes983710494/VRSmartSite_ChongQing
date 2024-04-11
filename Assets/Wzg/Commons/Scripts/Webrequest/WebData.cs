
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    #region 获得信息
    public class PersonnelList
    {
        public List<PersonnelData> data;
    }
    [Serializable]
    /// <summary>
    /// 人员数据
    /// </summary>
    public class PersonnelData
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 员工工号
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// string
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 入职日期
        /// </summary>
        public string hireDate { get; set; }
        /// <summary>
        /// 人员Id
        /// </summary>
        public string id;// { get; set; }
        /// <summary>
        /// 发证机关
        /// </summary>
        public string idAuthority { get; set; }
        /// <summary>
        /// 证件有效期结束
        /// </summary>
        public string idDataEnd { get; set; }
        /// <summary>
        /// 证件有效期开始
        /// </summary>
        public string idDataStart { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string idNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string idType { get; set; }
        /// <summary>
        /// 岗位类型
        /// </summary>
        public string jobType { get; set; }
        /// <summary>
        /// 定位坐标X
        /// </summary>
        public float? locationX { get; set; }
        /// <summary>
        /// 定位坐标Y
        /// </summary>
        public float? locationY { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string nation { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 人像图片
        /// </summary>
        public string picture { get; set; }
        /// <summary>
        /// 所属项目Id
        /// </summary>
        public string projectId;// { get; set; }
        /// <summary>
        /// 离职时间
        /// </summary>
        public string quitDate { get; set; }
        /// <summary>
        /// 实名制状态
        /// </summary>
        public string realNameState { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 是否参加安全培训
        /// </summary>
        public bool? safetyTraining { get; set; }
        /// <summary>
        /// 人员特种作业资格证号
        /// </summary>
        public string specialWorkCode { get; set; }
        /// <summary>
        /// 在职状态
        /// </summary>
        public string workState { get; set; }
        /// <summary>
        /// 工种
        /// </summary>
        public string workType { get; set; }


        //public Sprite sprite { get; set; }
    }


    /// <summary>
    /// 环境数据
    /// </summary>
    public class HuanJingData
    {
        /// <summary>
        /// 设备Id
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
        /// 温度
        /// </summary>
        public float tem { get; set; }
        /// <summary>
        /// 湿度
        /// </summary>
        public float hum { get; set; }
        /// <summary>
        /// 噪声
        /// </summary>
        public float noise { get; set; }
        /// <summary>
        /// 风力
        /// </summary>
        public float wp { get; set; }
        /// <summary>
        /// 风速
        /// </summary>
        public float ws { get; set; }
        /// <summary>
        /// 风向
        /// </summary>
        public float wd360 { get; set; }
    }


    #endregion

    #region 上传信息
    /// <summary>
    /// 红外入侵请求携带数据
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
    /// 巡检请求携带数据
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
    /// 考勤请求携带数据
    /// </summary>
    public class KaoQinUploadData
    {
        /// <summary>
        /// 时长
        /// </summary>
        public int duration { get; set; }
        /// <summary>
        /// 考勤id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 入场口
        /// </summary>
        public string inGate { get; set; }
        /// <summary>
        /// 入场图片
        /// </summary>
        public string inPicture { get; set; }
        /// <summary>
        /// 入场时间
        /// </summary>
        public string inTime { get; set; }
        /// <summary>
        /// 考勤日期
        /// </summary>
        public string kaoQinDate { get; set; }
        /// <summary>
        /// 出场口
        /// </summary>
        public string outGate { get; set; }
        /// <summary>
        /// 出场时间
        /// </summary>
        public string outTime { get; set; }
        /// <summary>
        /// 人员id
        /// </summary>
        public string personnelId { get; set; }
        /// <summary>
        /// 所属项目Id
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// 出场图片
        /// </summary>
        public string putPicture { get; set; }
        /// <summary>
        /// 出场图片
        /// </summary>
        public int type { get; set; }
    }



    /// <summary>
    /// 升降机Post请求携带数据
    /// </summary>
    public class ShengJiangJiUploadData
    {
        /// <summary>
        /// 报警状态（0未报警 1预警 2报警）
        /// </summary>
        public string alarmState { get; set; }
        /// <summary>
        /// 报警类型（重量、高度（冲顶）、速度、人数、倾斜）
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
        /// 实时人数
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 设备id
        /// </summary>
        public string deviceId { get; set; }
        /// <summary>
        /// 实时方向 0停止 1上 2下
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
        /// 实时倾斜度1
        /// </summary>
        public int gradient1 { get; set; }
        /// <summary>
        /// 倾斜百分比1
        /// </summary>
        public int gradient1Percent { get; set; }
        /// <summary>
        /// 实时倾斜度2
        /// </summary>
        public int gradient2 { get; set; }
        /// <summary>
        /// 倾斜百分比2
        /// </summary>
        public int gradient2Percent { get; set; }
        /// <summary>
        /// 实时高度
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 高度百分比
        /// </summary>
        public int heightPercent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId { get; set; }
        /// <summary>
        /// 实时速度
        /// </summary>
        public int speed { get; set; }
        /// <summary>
        /// 实时起重量
        /// </summary>
        public int weight { get; set; }
        /// <summary>
        /// 重量百分比
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
        /// 设备id
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
    /// 卸料平台数据
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
    /// 烟感报警请求携带数据
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
    /// 人员定位
    /// </summary>
    public class PutPersonPosData
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }


        /// <summary>
        /// 定位坐标X
        /// </summary>
        public float locationX { get; set; }
        /// <summary>
        /// 定位坐标Y
        /// </summary>
        public float locationY { get; set; }

    }
    #endregion
}