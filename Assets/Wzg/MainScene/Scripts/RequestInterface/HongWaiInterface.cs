using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.JSON.LitJson;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// ���ⱨ���ӿ�
    /// </summary>
    public interface IHongWaiAlarm : RequestBaseInterface
    {

    }
    /// <summary>
    /// �������ֱ������� �������Ϊ�˽������������豸���ݷ���
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
                    alarmUploadData.alarmInfo = "��������";
                    alarmUploadData.alarmOriginInfo = "";
                    alarmUploadData.alarmState = "2";
                    alarmUploadData.alarmTime = "";
                    alarmUploadData.alarmType = "���ⱨ��";
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
                    Debug.Log("���ⱨ���ɹ�" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("���ⱨ��ʧ�ܣ��������󣡴����룺" + responseFormat.code + "������Ϣ��" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("���ⱨ��ʧ�ܣ� ����������󣡴����룺" + response.StatusCode + "������Ϣ��" + response.DataAsText);
            }
            OnFail?.Invoke();
        }
    }
}

