using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// 红外报警接口
    /// </summary>
    public interface IHongWaiAlarm : RequestBaseInterface
    {

    }
    /// <summary>
    /// 红外入侵报警请求 这个类是为了将网络请求与设备数据分离
    /// </summary>
    public class HongWaiInterface : MonoBehaviour, IHongWaiAlarm
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        public void OnTriggerWebRequest(DevicesBase iDevice)
        {
            if (GameManager.IsServer)
            {
                HongWaiUploadData alarmUploadData = new HongWaiUploadData();
                if (iDevice != null && iDevice is HongWaiDevice)
                {
                    HongWaiDevice device = iDevice as HongWaiDevice;
                    alarmUploadData.alarmInfo = device.alarmInfo;
                    alarmUploadData.alarmOriginInfo = device.alarmOriginInfo;
                    alarmUploadData.alarmState = device.alarmState;
                    alarmUploadData.alarmTime = device.alarmTime;
                    alarmUploadData.alarmType = device.alarmType;
                    alarmUploadData.createTime = device.createTime;
                    alarmUploadData.deviceId = device.deviceId;
                    alarmUploadData.deviceType = device.deviceType;
                    alarmUploadData.disposeState = device.disposeState;
                    alarmUploadData.id = device.id;
                    alarmUploadData.projectId = device.projectId;
                }
                else
                {
                    alarmUploadData.alarmInfo = "红外入侵";
                    alarmUploadData.alarmOriginInfo = "";
                    alarmUploadData.alarmState = "2";
                    alarmUploadData.alarmTime = "";
                    alarmUploadData.alarmType = "红外报警";
                    alarmUploadData.createTime = "";
                    alarmUploadData.deviceId = RequestURLs.hongwaiId;
                    alarmUploadData.deviceType = "";
                    alarmUploadData.disposeState = "";
                    alarmUploadData.id = "";
                    alarmUploadData.projectId = RequestURLs.projectId;
                }
                string data = JsonMapper.ToJson(alarmUploadData);
                WebRequestManager.Instance.PostRequest(RequestURLs.addHongWaiAlarm, data, OnReqestFinished);
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
                ResponseFormat<bool> responseFormat = JsonMapper.ToObject<ResponseFormat<bool>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("红外报警成功" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("红外报警失败！发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("红外报警失败！ 发生网络错误！错误码：" + response.StatusCode + "错误信息：" + response.DataAsText);
            }
            OnFail?.Invoke();
        }
    }
}

