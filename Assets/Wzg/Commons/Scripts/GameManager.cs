using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wzg
{
    /// <summary>
    /// ����ű�����ע�᳣פ�ڵ�
    /// ��֤�ڵ��µ����岻���ų������ض�����
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public static bool IsServer
        {
            get
            {
                return Instance.m_IsServer;
            }
        }
        [SerializeField]
        private bool m_IsServer;
        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        public static void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }
        public static void LoadScene(string Name)
        {
            SceneManager.LoadScene(Name);
        }
    }
}