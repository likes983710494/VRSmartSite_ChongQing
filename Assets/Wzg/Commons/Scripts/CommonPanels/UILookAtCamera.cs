using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// 使用这个脚本可以让UI对着摄像机
    /// </summary>
    public class UILookAtCamera : MonoBehaviour
    {
        private Transform cameraTransform;
        // Start is called before the first frame update
        void Start()
        {
            cameraTransform = XROriginInstance.xROrigin.Camera.transform;
        }

        // Update is called once per frame
        void Update()
        {
            transform.forward = Vector3.Normalize(transform.position - cameraTransform.position);
        }
    }
}