using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public interface RequestBaseInterface
    {
        /// <summary>
        /// ����������ʱ
        /// </summary>
        /// <param name="device"></param>
        void OnTriggerWebRequest(DevicesBase device);
    }
}

