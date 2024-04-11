//------------------------------------------------------------
// 作者:Eric Wang 此行为了编码
// Author: Eric Wang 
// Copyright © Eric Wang. All rights reserved.
// @Homepage: https://innook.top/
//------------------------------------------------------------
using UnityEngine;
using System.Collections;
//引入库
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using BestHTTP;
using LitJson;

namespace Wzg
{
    

    public class TcpServer : MonoBehaviour
    {
        //private void Update()
        //{
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        SocketSend("light1|1");
        //    }
        //}


        //以下默认都是私有的成员

        public static void SocketSend(string sendStr)
        {
            if (GameManager.IsServer)
            {
                string[] newStr = sendStr.Split('|');
                string light = newStr[0];
                string value = newStr[1];
                string url = RequestURLs.lightCmd + light + "/" + value;
                Debug.Log(url);
                WebRequestManager.Instance.PostRequest(url, "", OnReqestFinished);
            }
        }

        private static void OnReqestFinished(HTTPRequest originalRequest, HTTPResponse response)
        {
            if (response.StatusCode == 200)
            {
                ResponseFormat<object> responseFormat = JsonMapper.ToObject<ResponseFormat<object>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("tcpmsg" + responseFormat.msg);


                }
                else
                {
                    Debug.Log("获得tcp！发生错误！错误码：" + responseFormat.code + "错误信息：" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("获得tcp！ 发生网络错误！错误码：" + response.StatusCode);
            }
        }

    }
}

