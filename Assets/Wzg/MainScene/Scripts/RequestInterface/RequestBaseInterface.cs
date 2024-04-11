using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public interface RequestBaseInterface
    {
        /// <summary>
        /// 当触发请求时
        /// </summary>
        /// <param name="device"></param>
        void OnTriggerWebRequest(DevicesBase device);
    }
}

