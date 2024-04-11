using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class ShenJiKengDevice : DevicesBase
    {
        [Header("深基坑设备ID")]
        public string devsn = "";
        /// <summary>
        /// type字段：
        /// 1：重量，2：立杆倾角，
        /// 3水平位移，4垂直沉降，
        /// 5温度计，6锚力，7孔隙水压力，
        /// 8轴力，9钢筋力，10土压力，
        /// 11混凝土应力，12表面应力，13水位，
        /// 14表面沉降，15雨量计，16裂缝计
        /// </summary>
        [Header("深基坑设备数据（16个）")]
        
        public List<ShenJiKengItemUploadData> shenJiKengItemUploadDatas = new List<ShenJiKengItemUploadData>();

        private IShenJiKengAlarm shenJiKengAlarm;

        void Start()
        {
            shenJiKengAlarm = GetComponent<IShenJiKengAlarm>();
            devsn = RequestURLs.shenJiKengId;
        }
        //private void Update()
        //{
            
        //}
        public void OnTriggerAlarm()
        {
            shenJiKengAlarm.OnTriggerWebRequest(this);
        }

       
    }
}