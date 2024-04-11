using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class ShenJiKengDevice : DevicesBase
    {
        [Header("������豸ID")]
        public string devsn = "";
        /// <summary>
        /// type�ֶΣ�
        /// 1��������2��������ǣ�
        /// 3ˮƽλ�ƣ�4��ֱ������
        /// 5�¶ȼƣ�6ê����7��϶ˮѹ����
        /// 8������9�ֽ�����10��ѹ����
        /// 11������Ӧ����12����Ӧ����13ˮλ��
        /// 14���������15�����ƣ�16�ѷ��
        /// </summary>
        [Header("������豸���ݣ�16����")]
        
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