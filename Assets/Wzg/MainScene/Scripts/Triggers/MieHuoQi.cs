using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    public class MieHuoQi : MonoBehaviour
    {
        private Vector3 initPos;
        private Quaternion initRot;

        public ParticleSystem _particleSystem;

        public FireFX fireFX;

        // Start is called before the first frame update
        void Start()
        {
            _particleSystem.Stop();
            initPos = transform.parent.position;
            initRot = transform.parent.rotation;

        }

        private void OnParticleCollision(GameObject other)
        {
            if(other.name == "WFX_Fire")
            {
                fireFX.SetSimulationSize();
            }
        }
        private void OnParticleTrigger()
        {
            Debug.Log("123456----->");
            fireFX.SetSimulationSize();
        }


        public void OnActive()
        {
            _particleSystem.Play();
        }
        public void OnUnActive()
        {
            _particleSystem.Stop();
        }

        public void OnExitedSelect()
        {
            _particleSystem.Stop();
            transform.parent.position = initPos;
            transform.parent.rotation = initRot;
        }
    }
}

