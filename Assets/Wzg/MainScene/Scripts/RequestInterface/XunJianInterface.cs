using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Wzg
{
    public interface IXunJian : RequestBaseInterface
    {
    }
    /// <summary>
    /// �̸нӿ�����
    /// </summary>
    public class XunJianInterface : MonoBehaviour, IXunJian
    {
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        public void OnTriggerWebRequest(DevicesBase iDevice)
        {
            if (GameManager.IsServer)
            {
                XunJianUploadData alarmUploadData = new XunJianUploadData();
                if (iDevice != null && iDevice is XunJianDevice)
                {
                    XunJianDevice device = iDevice as XunJianDevice;
                    alarmUploadData.content = device.content;
                    alarmUploadData.inspectionId = device.inspectionId;
                    alarmUploadData.personnelId = device.personnelId;
                    alarmUploadData.projectId = device.projectId;
                    alarmUploadData.status = device.status;
                }
                else
                {
                    alarmUploadData.content = "Ĭ��Ѳ���";
                    alarmUploadData.inspectionId = "0a521158a1037ea1b3082bc937175527";
                    alarmUploadData.personnelId = "1445025796fbe2b0b38ffa143250e863";
                    alarmUploadData.projectId = RequestURLs.projectId;
                    alarmUploadData.status = "0";
                }
                string data = JsonMapper.ToJson(alarmUploadData);
                WebRequestManager.Instance.PostRequest(RequestURLs.addInspectionRecord, data, OnReqestFinished);
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
                    Debug.Log("Ѳ���ϴ��ɹ�" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    gameObject.SetActive(false);
                    return;
                }
                else
                {
                    Debug.Log("Ѳ���ϴ�ʧ�ܣ��������󣡴����룺" + responseFormat.code + "������Ϣ��" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("Ѳ���ϴ�ʧ�ܣ� ����������󣡴����룺" + response.StatusCode + "������Ϣ��" + response.DataAsText);
            }
            OnFail?.Invoke();
            gameObject.SetActive(false);
        }
    }
}

