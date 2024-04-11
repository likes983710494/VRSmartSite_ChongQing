using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// ��������ݸ��½ӿ�
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
                    Debug.Log("������������ݳɹ��� ����ɹ���" + responseFormat.msg);
                    OnSuccess?.Invoke();
                    return;
                }
                else
                {
                    Debug.Log("�������������ʧ�ܣ� �������󣡴����룺" + responseFormat.code + "������Ϣ��" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("�������������ʧ�ܣ� �������󣡴����룺" + response.StatusCode + "������Ϣ��" + response.DataAsText );
            }
            OnFail?.Invoke();
        }
    }
}

