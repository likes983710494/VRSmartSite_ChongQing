using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    public class SelectScenePanel : MonoBehaviour
    {
        public GameObject selectCharacterPanel;


        public GameObject tipsPanel;
        public Button btnYes;

        public Button btnLeft;
        public Button btnRight;

        // Start is called before the first frame update
        void Start()
        {
            btnYes.onClick.AddListener(OnClickTipsYesBtn);
            btnLeft.onClick.AddListener(OnSelectLeftScene);
            btnRight.onClick.AddListener(OnSelectRightScene);
        }

        private void OnClickTipsYesBtn()
        {
            tipsPanel.SetActive(false);
            gameObject.SetActive(false);
            selectCharacterPanel.SetActive(true);
        }

        public void OnSelectRightScene()
        {
            tipsPanel.SetActive(true);
        }
        public void OnSelectLeftScene()
        {
            GameManager.LoadScene("Guide");
        }
    }
}