using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.ParticleSystem;

namespace Wzg {
    public class TeleportationAnchorEffect : MonoBehaviour
    {
        public float particleSimulateTime = 5f;
        public GameObject cylinder;
        public ParticleSystem[] particleSystems;
        private TeleportationAnchor teleportationAnchor;


        public UnityEvent unityEvent;
        // Start is called before the first frame update
        void Start()
        {
            SetSimulationSpeed(0.2f);
            teleportationAnchor = GetComponent<TeleportationAnchor>();
            teleportationAnchor.teleporting.AddListener(OnTeleporting);
            teleportationAnchor.hoverEntered.AddListener(OnHoverEntered);
            //teleportationAnchor.hoverExited.AddListener(OnHoverExited);
            //teleportationAnchor.activated.AddListener(OnActivated);
            teleportationAnchor.deactivated.AddListener(OnDeactivated);
        }

        private void OnDeactivated(DeactivateEventArgs arg0)
        {
            Debug.Log("OnDeactivated");
            StopSimulation();
        }

        private void OnActivated(ActivateEventArgs arg0)
        {
            Debug.Log("OnActivated");
            StopSimulation();
        }

        private void OnHoverExited(HoverExitEventArgs arg0)
        {
            Debug.Log("OnHoverExited");
            SetSimulationSpeed(0.2f);
        }

        private void OnHoverEntered(HoverEnterEventArgs arg0)
        {

            Debug.Log("OnHoverEntered");
            SetSimulationSpeed(1f);
        }
        private void OnTeleporting(TeleportingEventArgs arg0)
        {
            Debug.Log("OnTeleporting");
            TeleportationManager.Instance.OnTeleportingOneAnchor(this);
            StopSimulation();
        }

        public void OnUnTeleportingThis()
        {
            cylinder.SetActive(true);
            SetSimulationSpeed(0.2f);
            unityEvent?.Invoke();
        }

        public void SetSimulationSpeed(float speed)
        {
            foreach (var item in particleSystems)
            {
                item.Simulate(particleSimulateTime);
                MainModule main = item.main;
                main.simulationSpeed = speed;
                item.Play();
            }
        }
        public void StopSimulation()
        {
            cylinder.SetActive(false);
            foreach (var item in particleSystems)
            {
                item.Stop();
            }
        }
    }
}