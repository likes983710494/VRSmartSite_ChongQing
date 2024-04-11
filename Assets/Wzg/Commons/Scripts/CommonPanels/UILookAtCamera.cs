using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// ʹ������ű�������UI���������
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