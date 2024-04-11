using BestHTTP;
using BestHTTP.JSON.LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Wzg
{
    public class SelectCharacterPanel : MonoBehaviour
    {
        public ScrollRect scrollRect;
        public GameObject cloneObj;



        public GameObject checkSelect;
        public Sprite personnelSprite;
        public PersonnelIdCard checkSelectCard;
        public Button closeCheckButton;
        public Button enterSceneButton;

        void Start()
        {
            if (GameManager.IsServer)
            {
                WebRequestManager.Instance.GetRequest(RequestURLs.getPersonList, OnGetPersonListRequestFinished);
            }
            else
            {
                GameObject go = Instantiate(cloneObj, scrollRect.content);
                PersonnelIdCard personnelIdCard = go.GetComponent<PersonnelIdCard>();
                PersonnelData personnelData = new PersonnelData();
                personnelData.id = "123";
                personnelData.picture = "";
                personnelData.name = "����";
                personnelData.gender = "��";
                personnelData.idAuthority = "������";
                personnelData.code = "gd001";
                personnelData.workType = "���";
                personnelData.jobType = "����";
                personnelIdCard.OnShow(this, personnelData);

            }
            
            enterSceneButton.onClick.AddListener(OnClickEnterSceneButton);
            closeCheckButton.onClick.AddListener(OnClickCloseCheckButton);
        }

        private void OnClickCloseCheckButton()
        {
            checkSelect.SetActive(false);
        }

        private void OnClickEnterSceneButton()
        {
            WebRequestManager.SelectPersonnelId = checkSelectCard.id;
            WebRequestManager.SelectPersonnelTexture = checkSelectCard.texture;
            WebRequestManager.SelectPersonnelSprite = checkSelectCard.image.sprite;
            WebRequestManager.SelectPersonnelData = checkSelectCard.personnelData;
            GameManager.LoadScene("MainScene");
        }

        void OnGetPersonListRequestFinished(HTTPRequest request, HTTPResponse response)
        {
            if (response.StatusCode == 200)
            {
                ResponseFormat<List<PersonnelData>> responseFormat = JsonMapper.ToObject<ResponseFormat<List<PersonnelData>>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("����ɹ���" + responseFormat.msg);
                    if (responseFormat.data != null)
                    {
                        foreach (PersonnelData item in responseFormat.data)
                        {
                            GameObject go = Instantiate(cloneObj, scrollRect.content);
                            PersonnelIdCard personnelIdCard = go.GetComponent<PersonnelIdCard>();
                            personnelIdCard.OnShow(this,item);
                           
                        }
                    }
                }
                else
                {
                    Debug.Log("�������󣡴����룺" + responseFormat.code + "������Ϣ��" + responseFormat.msg);
                }
            }
            else
            {
                Debug.Log("�����������״̬�룺" + response.StatusCode);
            }

        }


    }
}