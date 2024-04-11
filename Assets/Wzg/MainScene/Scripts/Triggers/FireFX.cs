using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Wzg
{
    public class FireFX : MonoBehaviour
    {
        public float particleSimulateTime = 5f;
        public ParticleSystem[] particleSystems;
        public GameObject _light;
        public BoxCollider boxCollider;

        public float speedSize = 10;
        private float size = 1;
        // Start is called before the first frame update
        void Start()
        {
            StopSimulation();
        }

        public void SetSimulationSize()
        {
            size -= Time.deltaTime * speedSize;
            if (size > 0)
            {
                SetSimulationSize(size);
            }
            else
            {
                StopSimulation();
            }
            
        }


        public void SetSimulationSize(float size)
        {
            foreach (var item in particleSystems)
            {
                MainModule main = item.main;
                main.startSize = size;
            }
        }
        public void PlaySimulation()
        {
            size = 1;
            _light.SetActive(true);
            boxCollider.enabled = true;
            foreach (var item in particleSystems)
            {
                item.Simulate(particleSimulateTime);
                MainModule main = item.main;
                main.startSize = 1;
                item.Play();
            }
        }
        public void StopSimulation()
        {
            size = 0;
            _light.SetActive(false);
            boxCollider.enabled = false;
            foreach (var item in particleSystems)
            {
                MainModule main = item.main;
                main.startSize = 0;
                item.Stop();
            }
        }
    }
}

