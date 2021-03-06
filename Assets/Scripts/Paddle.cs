﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 PaddlePos = new Vector2( mousePosInUnits , transform.position.y);
        PaddlePos.x = Mathf.Clamp(mousePosInUnits , minX , maxX);
        transform.position = PaddlePos;
	}
}
