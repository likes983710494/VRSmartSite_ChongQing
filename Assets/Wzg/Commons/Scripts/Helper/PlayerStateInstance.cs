using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// 这个脚本是用来记录玩家状态的
    /// 储存玩家的打卡信息等
    /// </summary>
    public class PlayerStateInstance : MonoBehaviour
    {
        public static PlayerStateInstance Instance = null;


        public bool firstKaoQinIn = false;
        public bool firstKaoQinOut = false;


        private void Awake()
        {
            Instance = this;
        }


        public float delayUploadPosTime = 5;
        private float nowTime;
        // Start is called before the first frame update
        void Start()
        {
            UploadPosData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            if (nowTime < delayUploadPosTime)
            {
                nowTime += Time.fixedDeltaTime;
            }
            if (nowTime >= delayUploadPosTime)
            {
                nowTime = 0;
                UploadPosData();
            }
        }

        private void UploadPosData()
        {
            if (GameManager.IsServer)
            {
                PutPersonPosData putPersonPosData = new PutPersonPosData();
                putPersonPosData.id = WebRequestManager.SelectPersonnelId;
                putPersonPosData.locationX = transform.position.x;
                putPersonPosData.locationY = transform.position.z;
                string data = JsonMapper.ToJson(putPersonPosData);
                WebRequestManager.Instance.PutRequest(RequestURLs.updatePerson, data, OnReqestFinished);
            }
            else
            {

            }
        }

        void OnReqestFinished(HTTPRequest request, HTTPResponse response)
        {
            if (response.StatusCode == 200)
            {
             
                ResponseFormat<object> responseFormat = JsonMapper.ToObject<ResponseFormat<object>>(response.DataAsText);
                Debug.Log("response.DataAsText" + response.DataAsText + "||" + responseFormat.code);
                if (responseFormat.code == 0)
                {
                    Debug.Log("更新人员位置成功！" + responseFormat.msg);
                }
                else
                {
                    Debug.Log("更新人员位置失败，发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("更新人员位置失败，发生网络错误！状态码：" + response.StatusCode);
            }
        }

    }
}