using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Wzg
{
    public class TeleportationManager : MonoBehaviour
    {
        public static TeleportationManager Instance;
        private TeleportationAnchorEffect[] teleportationAnchorEffects;

        private void Awake()
        {
            Instance = this;
            teleportationAnchorEffects = GetComponentsInChildren<TeleportationAnchorEffect>();
        }


        public void OnTeleportingOneAnchor(TeleportationAnchorEffect teleportationAnchorEffect)
        {
            for (int i = 0; i < teleportationAnchorEffects.Length; i++)
            {
                if(teleportationAnchorEffects[i] != teleportationAnchorEffect)
                {
                    teleportationAnchorEffects[i].OnUnTeleportingThis();
                }
            }
        }


    }
}