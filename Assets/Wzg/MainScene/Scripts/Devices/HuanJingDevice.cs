using BestHTTP;
using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class HuanJingDevice : DevicesBase
    {
        public HuanJingPanel huanJingPanel;
        // Start is called before the first frame update
        void Start()
        {
            OnTriggerGetHuanJingData();
        }
        public void OnTriggerGetHuanJingData()
        {
            if (GameManager.IsServer)
            {
                WebRequestManager.Instance.GetRequest(RequestURLs.getHuanJingNowData + "?deviceId=" + RequestURLs.huanjingId, OnReqestFinished);
            }
        }

        private void OnReqestFinished(HTTPRequest originalRequest, HTTPResponse response)
        {
            if (response.StatusCode == 200)
            {
                ResponseFormat<HuanJingData> responseFormat = JsonMapper.ToObject<ResponseFormat<HuanJingData>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("获得环境数据成功" + responseFormat.msg);
                    Debug.Log(responseFormat.data.pm25.ToString());
                    //Debug.Log(response.DataAsText);
                    huanJingPanel.UpdateHuanJingData(responseFormat.data);
                    
                }
                else
                {
                    Debug.Log("获得环境数据失败！发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                    huanJingPanel.UpdateHuanJingData(null);
                }
            }
            else
            {
                Debug.Log("获得环境数据失败！ 发生网络错误！错误码：" + response.StatusCode);
                huanJingPanel.UpdateHuanJingData(null);
            }
        }
    }
}