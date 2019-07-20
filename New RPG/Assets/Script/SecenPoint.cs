﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecenPoint : MonoBehaviour
{
    public string BillegeStart; // 맵이동후 해당맵의 시작점
    private PlayerManager thePlayer;
    private CameraManager theCamera;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
        theCamera = FindObjectOfType<CameraManager>();
        if (BillegeStart == thePlayer.currenMapName)
        {
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
