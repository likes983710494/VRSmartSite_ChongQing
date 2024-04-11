
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    void Start()
    {


    }

   public void StartReached()
    {
        videoPlayer.Play();

    }
public    void EndReached()
    {
        videoPlayer.Stop();
    }
}
