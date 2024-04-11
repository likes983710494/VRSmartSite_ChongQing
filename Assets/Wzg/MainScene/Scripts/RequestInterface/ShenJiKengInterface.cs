using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// 深基坑数据更新接口
    /// </summary>
    public interface IShenJiKengAlarm : RequestBaseInterface
    {

    }
    public class ShenJiKengInterface : MonoBehaviour, IShenJiKengAlarm
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        public void OnTriggerWebRequest(DevicesBase iDevice)
        {
            if (GameManager.IsServer)
            {
                ShenJiKengUploadData uploadData = new ShenJiKengUploadData();
                if (iDevice != null && iDevice is ShenJiKengDevice)
                {
                    ShenJiKengDevice device = iDevice as ShenJiKengDevice;
                    uploadData.devsn = device.devsn;
                    uploadData.data = device.shenJiKengItemUploadDatas;
                }
                else
                {
                    uploadData.Def();
                }
                string data = JsonMapper.ToJson(uploadData);
                WebRequestManager.Instance.PostRequest(RequestURLs.addShenJiKengData, data, OnReqestFinished);
            }
            else
            {
                OnSuccess?.Invoke();
            }
            
        }

        private void OnReqestFinished(HTTPRequest request, HTTPResponse response)
        {
            if (response.StatusCode == 200)
            {
                ResponseFormat<string> responseFormat = JsonMapper.ToObject<ResponseFormat<string>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("更新深基坑数据成功， 请求成功！" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("更新深基坑数据失败， 发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("更新深基坑数据失败， 发生错误！错误码：" + response.StatusCode + "错误信息：" + response.DataAsText );
            }
            OnFail?.Invoke();
        }
    }
}

