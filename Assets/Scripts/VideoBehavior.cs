using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoBehavior : MonoBehaviour
{
    private VideoPlayer vp;
    [Range(0,1f)]
    public float buttonDisplay = 1;
    private long framCount = 0;
    public List<GameObject> Buttons;
    void Awake()
    {
        vp = GetComponent<VideoPlayer>();
        framCount = System.Convert.ToInt64(vp.frameCount)-1;
        InvokeRepeating("checkOver", .1f,.1f);
    }
    private void checkOver()
    {
        long playerCurrentFrame = vp.frame;
        if(playerCurrentFrame <framCount * buttonDisplay)
        {
            //print ("VIDEO IS PLAYING");
        }
        else
        {
            print ("VIDEO IS OVER");
            foreach(GameObject b in Buttons){
                b.SetActive(true);
            }
            CancelInvoke("checkOver");
        }
    }
}
