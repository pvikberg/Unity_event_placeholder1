using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is some placeholder code for Unity event "handling". Currently just moves the cube according to data recieved

*/

//this guy "handles" events
public class eventlistenerscript : MonoBehaviour {
	Renderer rend;
	

	void OnEnable()
    	{
        eventcreatorscript.event1 += handle_event;
    	}
    
    
    	void OnDisable()
    	{
        eventcreatorscript.event1 -= handle_event;
    	}



	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//placeholder for event handling, change as you see fit
	void handle_event(int id, Color col, float x, float y, float z,float xr, float yr, float zr,float xm,float ym,float zm,int button) {
	transform.position = new Vector3(x, y, z);
	transform.rotation = Quaternion.Euler(xr, yr, zr);
	// For now, can't figure out what to do with: id, xm, ym, zm, button 
	rend.material.SetColor("_Color", col);
	}
}
