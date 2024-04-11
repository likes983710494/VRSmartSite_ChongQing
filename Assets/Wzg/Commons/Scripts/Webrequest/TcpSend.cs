//------------------------------------------------------------
// 作者:Eric Wang 此行为了编码
// Author: Eric Wang 
// Copyright © Eric Wang. All rights reserved.
// @Homepage: https://innook.top/
//------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class TcpSend : MonoBehaviour
    {
        private UDPManager manager;

        [Tooltip("沙盘指令")]
        public string msg;
        private void Awake()
        {
            manager =GameObject.Find("UDP").GetComponent<UDPManager>();
        }
      
        public void SendMsg()
        {
            //沙盘发送消息
            manager.UDPSendMessage("192.168.1.8", 8899, msg); //开启沙盘指令
            Debug.Log("开启："+gameObject.name+"|||"+msg);
           // TcpServer.SocketSend(msg);
        }

    }
}

