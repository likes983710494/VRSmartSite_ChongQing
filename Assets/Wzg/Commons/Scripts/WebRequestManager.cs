using BestHTTP;
using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class WebRequestManager : MonoBehaviour
    {
        public static WebRequestManager Instance = null;

        /// <summary>
        /// ѡ�����Աid
        /// </summary>
        public static string SelectPersonnelId = "";
        /// <summary>
        /// ѡ����Ա��ͼƬ �����ϴ�
        /// </summary>
        public static Texture2D SelectPersonnelTexture;
        /// <summary>
        /// ѡ����Ա�ľ���ͼ ������ʾ
        /// </summary>
        public static Sprite SelectPersonnelSprite;
        /// <summary>
        /// ѡ����Ա����Ϣ����
        /// </summary>
        public static PersonnelData SelectPersonnelData = null;

        private void Awake()
        {
            Instance = this;
        }


        /// <summary>
        /// Get����
        /// </summary>
        /// <param name="url">�����ַ</param>
        /// <param name="onReqestFinished">����ص�</param>
        public void GetRequest(string url, OnRequestFinishedDelegate onReqestFinished)
        {
            url = SetUrlTime(url);
            Uri uri = new Uri(url);
            HTTPRequest request = new HTTPRequest(uri, HTTPMethods.Get, onReqestFinished);
            request.Send();
        }

        /// <summary>
        /// Post����
        /// </summary>
        /// <param name="url">�����ַ</param>
        /// <param name="data">�ϴ���string��������</param>
        /// <param name="onReqestFinished">����ص�</param>
        public HTTPRequest PostRequest(string url, string data, OnRequestFinishedDelegate onReqestFinished,bool autoSend = true)
        {
            //string uploadStr = JsonMapper.ToJson(data);
            byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(data);
            Uri uri = new Uri(url);
            HTTPRequest request = new HTTPRequest(uri, HTTPMethods.Post, onReqestFinished);
            request.SetHeader("UC-USER", "1");
            request.SetHeader("TENANT-ID", "1");
            request.SetHeader("Content-Type", "application/json");
            //hTTPRequest.AddField("deviceAlarm", "admin");
            request.RawData = postBytes;
            if (autoSend)
            {
                request.Send();
            }
            return request;
        }


        public void PutRequest(string url, string data, OnRequestFinishedDelegate onReqestFinished)
        {
            byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(data);
            Uri uri = new Uri(url);
            HTTPRequest request = new HTTPRequest(uri, HTTPMethods.Put, onReqestFinished);
            request.SetHeader("UC-USER", "1");
            request.SetHeader("TENANT-ID", "1");
            request.SetHeader("Content-Type", "application/json");
            //hTTPRequest.AddField("deviceAlarm", "admin");
            request.RawData = postBytes;
            request.Send();
        }


        /// <summary>
        /// post����
        /// </summary>
        /// <param name="url">�����ַ</param>
        /// <param name="data">jsondata����</param>
        /// <param name="onReqestFinished">����ص�</param>
        public void PostRequest(string url, JsonData data, OnRequestFinishedDelegate onReqestFinished)
        {
            string uploadStr = JsonMapper.ToJson(data);
            byte[] postBytes = System.Text.Encoding.UTF8.GetBytes(uploadStr);
            Uri uri = new Uri(url);
            HTTPRequest request = new HTTPRequest(uri, HTTPMethods.Post, onReqestFinished);
            request.SetHeader("UC-USER", "1");
            request.SetHeader("TENANT-ID", "1");
            request.SetHeader("Content-Type", "application/json");
            //hTTPRequest.AddField("deviceAlarm", "admin");
            request.RawData = postBytes;
            request.Send();
        }
        /// <summary>
        /// ��ֹ���棬����ʱ���
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string SetUrlTime(string url)
        {
            string symbol = url.IndexOf("?") > -1 ? "&" : "?";
            url = string.Format("{0}{1}time={2}", url, symbol, GetNorTime());
            return url;
        }

        public string GetNorTime()
        {
            string norTime = string.Format("{0:yyyyMMddHHmmssffff}", DateTime.Now);
            return norTime;
        }

        public string GetNorWebTime()
        {
            string norTime = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            return norTime;
        }

        private Action<PersonnelList> onGetPersonnelListFinishedAction;
        public void OnGetPersonList(Action<PersonnelList> onGetFinished = null)
        {
            onGetPersonnelListFinishedAction = onGetFinished;
            GetRequest(RequestURLs.getPersonList, OnGetPersonListRequestFinished);
        }
        //����ص�
        void OnGetPersonListRequestFinished(HTTPRequest request, HTTPResponse response)
        {
            if(response.StatusCode == 200)
            {
                ResponseFormat<List<PersonnelData>> responseFormat = JsonMapper.ToObject<ResponseFormat<List<PersonnelData>>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("����ɹ���" + responseFormat.msg);
                    PersonnelList personnelList = new PersonnelList();
                    personnelList.data = responseFormat.data;
                    onGetPersonnelListFinishedAction?.Invoke(personnelList);
                }
                else
                {
                    Debug.Log("�������󣡴����룺" + responseFormat.code + "������Ϣ��" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("�����������״̬�룺" + response.StatusCode);
            }

        }
    }
}