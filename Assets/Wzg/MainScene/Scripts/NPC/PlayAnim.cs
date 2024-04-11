using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wzg
{
    /// <summary>
    /// ²¥·Å¶¯»­
    /// </summary>
    public class PlayAnim : MonoBehaviour
    {
        public Animator animPlayer;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayAnimByName(string animName)
        {
            animPlayer.Play(animName);
        }
    }
}