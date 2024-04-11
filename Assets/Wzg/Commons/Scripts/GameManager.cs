using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wzg
{
    /// <summary>
    /// 这个脚本用来注册常驻节点
    /// 保证节点下的物体不随着场景加载而销毁
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