using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// ������������ʱ����һЩ����
    /// </summary>
    public class OpenGameObjectOnTrigger : MonoBehaviour
    {
        public bool open;
        public GameObject[] gameObjects;

        private void OnTriggerEnter(Collider other)
        {
            foreach (GameObject item in gameObjects)
            {
                item.SetActive(open);
            }
        }
    }
}