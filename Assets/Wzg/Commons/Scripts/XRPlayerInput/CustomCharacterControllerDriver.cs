using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Wzg
{
    /// <summary>
    /// �Զ���̳� Character Controller Driver �Ľű� ��չ ���ڽ�������ײ�߶�ֻ���˶��и��µ�����
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