﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour {

    public Transform lookAt;
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(lookAt);
	}
}
