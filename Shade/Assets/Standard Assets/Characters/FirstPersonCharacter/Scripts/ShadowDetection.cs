﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShadowDetection : MonoBehaviour
{
    public Image shadowDetector;
    
	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	    
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
        if (coll.GetComponent<Collider>().name == "Head")
        {
            //shadowDetector.color.r -= 10;
        }
    }
}