using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// ���������ݸ��½ӿ�
    /// </summary>
    public interface IXieLiaoAlarm : RequestBaseInterface
    {

    }
    /// <summary>
    /// ���������ݸ����� �������Ϊ�˽������������豸����
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
                    alarmUploadData.alarmType = "��б";
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
                    Debug.Log("����ж��ƽ̨���ݳɹ��� ����ɹ���" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("����ж��ƽ̨����ʧ�ܣ� �������󣡴����룺" + responseFormat.code + "������Ϣ��" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("����ж��ƽ̨����ʧ�ܣ� �������󣡴����룺" + response.StatusCode + "������Ϣ��" + response.DataAsText);
            }
            OnFail?.Invoke();
        }
    }
}

