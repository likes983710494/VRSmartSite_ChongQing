using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Wzg {
    /// <summary>
    /// ����ű�������ֻ������������XROrigin����͸�����������λ��
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