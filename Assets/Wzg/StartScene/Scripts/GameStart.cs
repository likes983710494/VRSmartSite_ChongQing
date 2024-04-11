using BestHTTP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class GameStart : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GameManager.LoadScene("Select"); 
            
           //GameManager.LoadScene("MainScene"); 
            //WebRequestManager.Instance.GetRequest(RequestURLs.getHuanJingNowData + "?deviceId=" + RequestURLs.huanjingId, OnReqestFinished);
        }

        // Update is called once per frame
        void Update()
        {
            
        }


        //void OnReqestFinished(HTTPRequest request, HTTPResponse response)
        //{
        //    if (response.StatusCode == 200)
        //    {
        //        GameManager.IsServer = true;
        //    }
        //    else
        //    {
        //        GameManager.IsServer = false;
        //    }
        //    GameManager.LoadScene("Select");
        //}
    }
}

