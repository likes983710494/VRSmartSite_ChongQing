using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Wzg
{
    /// <summary>
    /// 自定义继承 Character Controller Driver 的脚本 扩展 用于解决相机碰撞高度只在运动中更新的问题
    /// </summary>
    public class CustomCharacterControllerDriver : CharacterControllerDriver
    {
        // Update is called once per frame
        void Update()
        {
            UpdateCharacterController();
        }
    }
}