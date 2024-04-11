using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// 升降机数据更新接口
    /// </summary>
    public interface IShengJiangJiAlarm : RequestBaseInterface
    {

    }
    /// <summary>
    /// 升降机数据更新类 这个类是为了将网络请求与设备分离
    /// </summary>
    public class ShengJiangJiInterface : MonoBehaviour, IShengJiangJiAlarm
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        public void OnTriggerWebRequest(DevicesBase iDevice)
        {
            if (GameManager.IsServer)
            {
                ShengJiangJiUploadData alarmUploadData = new ShengJiangJiUploadData();
                if (iDevice != null && iDevice is ShengJiangJiDevice)
                {
                    ShengJiangJiDevice device = iDevice as ShengJiangJiDevice;
                    alarmUploadData.alarmState = device.alarmState;
                    alarmUploadData.alarmType = device.alarmType;
                    alarmUploadData.authentication = device.authentication;
                    alarmUploadData.backLock = device.backLock;
                    alarmUploadData.count = device.count;
                    alarmUploadData.createTime = device.createTime;
                    alarmUploadData.deviceId = device.deviceId;
                    alarmUploadData.direction = device.direction;
                    alarmUploadData.disposeState = device.disposeState;
                    alarmUploadData.frontLock = device.frontLock;
                    alarmUploadData.gradient1 = device.gradient1;
                    alarmUploadData.gradient1Percent = device.gradient1Percent;
                    alarmUploadData.gradient2 = device.gradient2;
                    alarmUploadData.gradient2Percent = device.gradient2Percent;
                    alarmUploadData.height = device.height;
                    alarmUploadData.id = device.id;
                    alarmUploadData.projectId = device.projectId;
                    alarmUploadData.speed = device.speed;
                    alarmUploadData.weight = device.weight;
                    alarmUploadData.weightPercent = device.weightPercent;
                }
                else
                {
                    alarmUploadData.alarmState = "2";
                    alarmUploadData.alarmType = "设备断开连接";
                    alarmUploadData.authentication = "";
                    alarmUploadData.backLock = "";
                    alarmUploadData.count = 0;
                    alarmUploadData.createTime = "";
                    alarmUploadData.deviceId = RequestURLs.shengJiangJiId;
                    alarmUploadData.direction = "";
                    alarmUploadData.disposeState = "";
                    alarmUploadData.frontLock = "";
                    alarmUploadData.gradient1 = 0;
                    alarmUploadData.gradient1Percent = 0;
                    alarmUploadData.gradient2 = 0;
                    alarmUploadData.gradient2Percent = 0;
                    alarmUploadData.height = 0;
                    alarmUploadData.id = "";
                    alarmUploadData.projectId = RequestURLs.projectId;
                    alarmUploadData.speed = 0;
                    alarmUploadData.weight = 0;
                    alarmUploadData.weightPercent = 0;
                }
                string data = JsonMapper.ToJson(alarmUploadData);
                WebRequestManager.Instance.PostRequest(RequestURLs.addShengJiangJiData, data, OnReqestFinished);
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
                    Debug.Log("更新升降机数据成功， 请求成功！" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("更新升降机数据失败， 发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("更新升降机数据失败， 发生错误！错误码：" + response.StatusCode);
            }
            OnFail?.Invoke();
        }
    }
}

