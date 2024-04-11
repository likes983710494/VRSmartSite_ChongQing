using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace Wzg
{
    /// <summary>
    /// 让ui出现在vr视野的前方，漂浮在一定的高度上
    /// 注意：ui会跟随视野移动
    /// </summary>
    public class UIFollowManager : MonoBehaviour
    {
        public XROrigin xROrigin;
        public static UIFollowManager Instance;

        public Transform UIFollowAnchors;

        //public float x;

        private void Awake()
        {
            Instance = this;
        }
        public void SetUIToFollowPoint(Transform ui)
        {
            ui.SetParent(transform);
        }


        public Dictionary<string, GameObject> panels = new Dictionary<string, GameObject>();
        //public Dictionary<string, PanelBase> panelBase = new Dictionary<string, PanelBase>();

        public bool PanelState(string panelName)
        {
            if (panels.ContainsKey(panelName))
            {
                GameObject panel = panels[panelName];
                return panel.activeSelf;
                //return;
            }
            else
            {
                return false;
            }
        }
        public void OpenPanel(string panelName)
        {
            MatchUIStayCameraForward();
            if (panels.ContainsKey(panelName))
            {
                GameObject panel = panels[panelName];
                panel.SetActive(true);
                return;
            }
            try
            {
                GameObject go = Resources.Load<GameObject>("UIPanels/" + panelName);
                GameObject newPanel = Instantiate<GameObject>(go, UIFollowAnchors);
                panels.Add(panelName, newPanel);
                newPanel.SetActive(true);
            }
            catch (System.Exception)
            {
                Debug.LogError("Resources下没有这个UI");
            }
            
        }

        public void OpenTipsPanel(string panelName,string tipsTitle, string tipsContext, string okBtnStr,string noBtnStr,UnityEvent onOk = null,UnityEvent onNo = null)
        {
            MatchUIStayCameraForward();
            if (panels.ContainsKey(panelName))
            {
                GameObject panel = panels[panelName];
                TipsPanel tipsPanel = panel.GetComponent<TipsPanel>();
                tipsPanel.OnShow(tipsTitle, tipsContext, okBtnStr, noBtnStr, onOk, onNo);
                panel.SetActive(true);
                return;
            }
            try
            {
                GameObject go = Resources.Load<GameObject>("UIPanels/" + panelName);
                GameObject newPanel = Instantiate<GameObject>(go, UIFollowAnchors);
                TipsPanel tipsPanel = newPanel.GetComponent<TipsPanel>();
                tipsPanel.OnShow(tipsTitle, tipsContext, okBtnStr, noBtnStr, onOk, onNo);
                panels.Add(panelName, newPanel);
                newPanel.SetActive(true);
            }
            catch (System.Exception)
            {
                Debug.LogError("Resources下没有这个UI");
            }
            
        }



        public void ClosePanel(string panelName)
        {
            if (panels.ContainsKey(panelName))
            {
                GameObject panel = panels[panelName];
                panel.SetActive(false);
                //return;
            }
        }

        /// <summary>
        /// 根据摄像机朝向，计算出ui正确悬浮位置
        /// </summary>
        public void MatchUIStayCameraForward()
        {
            MatchUIUpUIForward(xROrigin.transform.up, xROrigin.Camera.transform.forward);
        }

        public bool MatchUIUpUIForward(Vector3 destinationUp, Vector3 destinationForward)
        {
            if (MatchOriginUp(destinationUp))
            {
                // The angle that we want the XR Origin to rotate is the signed angle between the origin's forward and destinationForward, after the up vectors are matched.
                var signedAngle = Vector3.SignedAngle(transform.forward, destinationForward, destinationUp);

                RotateAroundCameraPosition(destinationUp, signedAngle);

                return true;
            }

            return false;
        }
        public bool MatchOriginUp(Vector3 destinationUp)
        {
            if (transform.up == destinationUp)
                return true;

            var rigUp = Quaternion.FromToRotation(transform.up, destinationUp);
            transform.rotation = rigUp * transform.rotation;

            return true;
        }

        public bool RotateAroundCameraPosition(Vector3 vector, float angleDegrees)
        {
            if (xROrigin.Camera == null)
            {
                return false;
            }

            // Rotate around the camera position
            transform.RotateAround(xROrigin.Camera.transform.position, vector, angleDegrees);

            return true;
        }
    }
}