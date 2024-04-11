using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Wzg
{
    public class MenuPanel : MonoBehaviour
    {
        public Text text;
        public Button restartSceneButton;
        //public Button returnMenuButton;
        public Button returnDesktopButton;

        // Start is called before the first frame update
        void Start()
        {
            restartSceneButton.onClick.AddListener(OnClickRestartSceneButton);
            //returnMenuButton.onClick.AddListener(OnClickReturnMenuButton);
            returnDesktopButton.onClick.AddListener(OnClickReturnDesktopButton);
        }
        private void OnClickRestartSceneButton()
        {
            //SceneManager.LoadScene("MainScene");
            SceneManager.LoadScene("Select");
        }
        private void OnClickReturnMenuButton()
        {
            SceneManager.LoadScene("Select");
        }
        private void OnClickReturnDesktopButton()
        {
            Application.Quit();
        }
    }
}