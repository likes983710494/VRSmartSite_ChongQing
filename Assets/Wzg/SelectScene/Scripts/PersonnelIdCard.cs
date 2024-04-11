using BestHTTP;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    public class PersonnelIdCard : MonoBehaviour
    {
        public string id;
        public string imagePath;
        public Button btn;
        public Image image;
        public Text nameValue;
        public Text genderValue;
        public Text classValue;
        public Text codeValue;
        public Text workTypeValue;
        public Text jobValue;

        public PersonnelData personnelData;

        public Texture2D texture;

        private SelectCharacterPanel selectCharacterPanel;
        // Start is called before the first frame update
        void Start()
        {
            btn.onClick.AddListener(OnClickThisCard);
            //if(imagePath.Length != 0 && !imagePath.Length.Equals(""))
            //{
            //    WebRequestManager.Instance.GetRequest(imagePath, OnGetPictureFinished);
            //}
        }
        public void OnShow(SelectCharacterPanel selectCharacterPanel, PersonnelData personnelData)
        {
           this.selectCharacterPanel = selectCharacterPanel;
           this.personnelData = personnelData;
           id = personnelData.id;
           imagePath = personnelData.picture;
           nameValue.text = personnelData.name;
           genderValue.text = personnelData.gender;
           classValue.text = personnelData.idAuthority;
           codeValue.text = personnelData.code;
           workTypeValue.text = personnelData.workType;
           jobValue.text = personnelData.jobType;
            if (GameManager.IsServer)
            {
                if (imagePath.Length != 0 && !imagePath.Length.Equals(""))
                {
                    WebRequestManager.Instance.GetRequest(imagePath, OnGetPictureFinished);
                }
            }
            else
            {
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                image.sprite = sprite;
            }
            
        }
        

        void OnGetPictureFinished(HTTPRequest request, HTTPResponse response)
        {
            if (response.StatusCode == 200)
            {
                Debug.Log(gameObject.name + ":----------->图片下载完成！");
                Texture2D texture2D = response.DataAsTexture2D;
                texture = texture2D;
                Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
                image.sprite = sprite;
            }
            else
            {
                Debug.Log("发生网络错误！状态码：" + response.StatusCode);
            }
        }
        private void OnClickThisCard()
        {
            selectCharacterPanel.checkSelect.SetActive(true);
            selectCharacterPanel.checkSelectCard.OnShow(selectCharacterPanel, personnelData);
        }
    }
}