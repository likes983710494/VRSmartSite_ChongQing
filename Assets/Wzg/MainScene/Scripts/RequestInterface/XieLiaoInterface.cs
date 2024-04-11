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
    public interface IXieLiaoAlarm : RequestBaseInterface
    {

    }
    /// <summary>
    /// 升降机数据更新类 这个类是为了将网络请求与设备分离
    /// </summary>
    public class XieLiaoInterface : MonoBehaviour, IXieLiaoAlarm
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        public void OnTriggerWebRequest(DevicesBase iDevice)
        {
            if (GameManager.IsServer)
            {
                XieLiaoUploadData alarmUploadData = new XieLiaoUploadData();
                if (iDevice != null && iDevice is XieLiaoDevice)
                {
                    XieLiaoDevice device = iDevice as XieLiaoDevice;
                    alarmUploadData.alarmState = device.alarmState;
                    alarmUploadData.alarmType = device.alarmType;
                    alarmUploadData.createTime = device.createTime;
                    alarmUploadData.deviceId = device.deviceId;
                    alarmUploadData.disposeState = device.disposeState;
                    alarmUploadData.id = device.id;
                    alarmUploadData.projectId = device.projectId;
                    alarmUploadData.weight = device.weight;
                }
                else
                {
                    alarmUploadData.alarmState = "2";
                    alarmUploadData.alarmType = "倾斜";
                    alarmUploadData.createTime = "";
                    alarmUploadData.deviceId = RequestURLs.xieLiaoPingTaiId;
                    alarmUploadData.disposeState = "";
                    alarmUploadData.id = "";
                    alarmUploadData.projectId = RequestURLs.projectId;
                    alarmUploadData.weight = 500;
                }
                string data = JsonMapper.ToJson(alarmUploadData);
                WebRequestManager.Instance.PostRequest(RequestURLs.addXieLiaoAlarm, data, OnReqestFinished);
            }
            else
            {
                OnSuccess?.Invoke();
            }
           
        }

        private void OnReqestFinished(HTTPRequest request, HTTPResponse response)
        {
            Debug.Log(request.RawData);
            if (response.StatusCode == 200)
            {
                ResponseFormat<bool> responseFormat = JsonMapper.ToObject<ResponseFormat<bool>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("更新卸料平台数据成功， 请求成功！" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("更新卸料平台数据失败， 发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("更新卸料平台数据失败， 发生错误！错误码：" + response.StatusCode + "错误信息：" + response.DataAsText);
            }
            OnFail?.Invoke();
        }
    }
}

