using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;
using UnityEngine.Events;

namespace Wzg
{
    public interface IYanGanAlarm : RequestBaseInterface
    {
    }
    /// <summary>
    /// 烟感接口请求
    /// </summary>
    public class YanGanInterface : MonoBehaviour, IYanGanAlarm
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        public void OnTriggerWebRequest(DevicesBase iDevice)
        {
            if (GameManager.IsServer)
            {
                YanGanAlarmUploadData alarmUploadData = new YanGanAlarmUploadData();
                if (iDevice != null && iDevice is YanGanDevice)
                {
                    YanGanDevice device = iDevice as YanGanDevice;
                    //alarmUploadData.alarmInfo = device.alarmInfo;
                    //alarmUploadData.alarmOriginInfo = device.alarmOriginInfo;
                    //alarmUploadData.alarmState = device.alarmState;
                    //alarmUploadData.alarmTime = device.alarmTime;
                    //alarmUploadData.alarmType = device.alarmType;
                    //alarmUploadData.createTime = device.createTime;
                    alarmUploadData.deviceId = device.deviceId;
                    //alarmUploadData.deviceType = device.deviceType;
                    //alarmUploadData.disposeState = device.disposeState;
                    //alarmUploadData.id = device.id;
                    alarmUploadData.projectId = device.projectId;
                }
                else
                {
                    //alarmUploadData.alarmInfo = "";
                    //alarmUploadData.alarmOriginInfo = "";
                    //alarmUploadData.alarmState = "";
                    //alarmUploadData.alarmTime = "";
                    //alarmUploadData.alarmType = "烟雾";
                    //alarmUploadData.createTime ="";
                    alarmUploadData.deviceId = RequestURLs.yanGanId;
                    //alarmUploadData.deviceType = "";
                    //alarmUploadData.disposeState = "";
                    //alarmUploadData.id = "";
                    alarmUploadData.projectId = RequestURLs.projectId;
                }
                string data = JsonMapper.ToJson(alarmUploadData);
                WebRequestManager.Instance.PostRequest(RequestURLs.addYanGanAlarm, data, OnReqestFinished);
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
                    Debug.Log("烟感报警成功" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("烟感报警失败！发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("烟感报警失败！ 发生网络错误！错误码：" + response.StatusCode + "错误信息：" + response.DataAsText);
            }
            OnFail?.Invoke();
        }
    }
}

