using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Wzg
{
    public class OpenZhaJiTrigger : MonoBehaviour
    {
        public Transform rightMesh;
        public Transform leftMesh;

        public bool OpenState = false;


        public void OnOpenZhaJi()
        {
            if (!OpenState)
            {
                rightMesh.DOLocalRotate(new Vector3(0, 0, 34), 0.3f);
                leftMesh.DOLocalRotate(new Vector3(0, 0, -34), 0.3f);
                OpenState = true;
            }
            
        }

        public void OnCloseZhaJi()
        {
            if (OpenState)
            {
                rightMesh.DOLocalRotate(new Vector3(0, 0, 0), 0.3f);
                leftMesh.DOLocalRotate(new Vector3(0, 0, 0), 0.3f);
                OpenState = false;
            }
        }


        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.name == "XR Origin")
        //    {
        //        rightMesh.DOLocalRotate(new Vector3(0, 0, 34), 0.3f);
        //        leftMesh.DOLocalRotate(new Vector3(0, 0, -34), 0.3f);
        //    }
        //}
        private void OnTriggerExit(Collider other)
        {
            if (other.name == "XR Origin")
            {
                OnCloseZhaJi();
            }
        }
    }
}