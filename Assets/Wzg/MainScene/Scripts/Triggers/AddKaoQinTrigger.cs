using BestHTTP;
using BestHTTP.JSON.LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Wzg
{
    public class AddKaoQinTrigger : MonoBehaviour
    {

        public int KaoQinType = 0;
        public int EquipCode = 0;

        public float triggerWaitTime = 5;

        private bool IsTrigger = false;
        public UnityEvent OnSuccess;
        public UnityEvent OnFail;

        private void OnTriggerEnter(Collider other)
        {
            if (GameManager.IsServer)
            {
                if (!IsTrigger)
                {
                    Debug.Log("´¥·¢¿¼ÇÚ----------->" + KaoQinType);
                    KaoQinUploadData kaoQinUploadData = new KaoQinUploadData();
                    kaoQinUploadData.personnelId = WebRequestManager.SelectPersonnelId;
                    kaoQinUploadData.projectId = WebRequestManager.SelectPersonnelData.projectId;
                    kaoQinUploadData.type = KaoQinType;
                    string data = JsonMapper.ToJson(kaoQinUploadData);
                    WebRequestManager.Instance.PostRequest(RequestURLs.addKaoQin, data, OnPostKaoQinRequestFinished);
                    IsTrigger = true;
                    //StartCoroutine(OnTriggerWait(triggerWaitTime));
                }
            }
            else
            {
                OnSuccess?.Invoke();
            }
        }

        void OnPostKaoQinRequestFinished(HTTPRequest request, HTTPResponse response)
        {
            IsTrigger = false;
            gameObject.SetActive(false);
            if (response.StatusCode == 200)
            {
                Debug.Log(response.DataAsText);
                ResponseFormat<bool> responseFormat = JsonMapper.ToObject<ResponseFormat<bool>>(response.DataAsText);
                if (responseFormat.code == 0)
                {
                    Debug.Log("¿¼ÇÚ³É¹¦" + responseFormat.msg);
                    OnSuccess?.Invoke();
                }
                else
                {
                    Debug.Log("¿¼ÇÚÊ§°Ü£¡·¢Éú´íÎó£¡´íÎóÂë£º" + responseFormat.code + "´íÎóÐÅÏ¢£º" + responseFormat.msg);
                    OnFail?.Invoke();
                }
            }
            else
            {
                Debug.Log("¿¼ÇÚÊ§°Ü£¡ ·¢ÉúÍøÂç´íÎó£¡´íÎóÂë£º" + response.StatusCode);
            }
        }

        IEnumerator OnTriggerWait(float triggerWaitTime)
        {
            yield return new WaitForSeconds(triggerWaitTime);
            IsTrigger = false;
        }

    }
}