using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Wzg {
    /// <summary>
    /// 这个脚本单例，只是用来方便获得XROrigin组件和更新人物坐标位置
    /// </summary>
    public class XROriginInstance : MonoBehaviour
    {
        private static XROriginInstance Instance = null;
        public XROrigin xROriginObject;
        public static XROrigin xROrigin 
        { 
            get 
            {
                return Instance.xROriginObject;   
            } 
        }
        private void Awake()
        {
            Instance = this;
        }


        

    }
}