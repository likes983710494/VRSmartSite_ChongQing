using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class TestWebRequest : MonoBehaviour
    {
        public RequestBaseInterface[] requestBaseInterfaces;
        // Start is called before the first frame update
        void Start()
        {
            requestBaseInterfaces = transform.GetComponentsInChildren<RequestBaseInterface>();
            foreach (var item in requestBaseInterfaces)
            {
                item.OnTriggerWebRequest(null);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}