using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Assertions;

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;


/*
This is some placeholder code for unity event creation 

Warning: probably will change a lot in the future

Brief instuctions:
Modify parameters as you see fit between comments that tell you to

Currently sends sine signals each with configurable offset, speed and amplitude

When it is running, you can press space to indicate whether "button" is being pressed, 
and change id by pressing 1,2,3,4 or 5

*/

// this guy creates some placeholder events to play around with
public class eventcreatorscript : MonoBehaviour {


	public delegate void eventaction1(int id, Color col,float x,float y,float z,float xr,float yr,float zr,float xm,float ym,float zm,int button);
	public static event eventaction1 event1;

        public Text eventhistory_text;

	public Color col;
	public Color col1;
	public Color col2;
	public Color col3;
	public Color col4;
	public Color col5;
	float tempTime;
	int id;
	int button;

	float seconds_between_events;

	float x_offset;
	float y_offset;
	float z_offset;
	float x_speed;
	float y_speed;
	float z_speed;
	float x_amplitude;
	float y_amplitude;
	float z_amplitude;

	float xr_offset;
	float yr_offset;
	float zr_offset;
	float xr_speed;
	float yr_speed;
	float zr_speed;
	float xr_amplitude;
	float yr_amplitude;
	float zr_amplitude;	

	float xm_offset;
	float ym_offset;
	float zm_offset;
	float xm_speed;
	float ym_speed;
	float zm_speed;
	float xm_amplitude;
	float ym_amplitude;
	float zm_amplitude;




    	string[] eventhistory_list = {"-","-","-","-","-","-","-"};
	// Use this for initialization
	void Start () {
		eventhistoryupdate("IT BEGINS!");
		col1 = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		col2 = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		col3 = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		col4 = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		col5 = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
		col = col1;
		tempTime = 0.0f;
		id = 1;
		button = 0;


		//Change the below parameters to what you like

		
		seconds_between_events = 0.05f; // because we should'nt expect an event at every frame

		x_offset = 0;
		y_offset = 0;
		z_offset = 0;
		x_speed = 1;
		y_speed = 0.5f;
		z_speed = 0;
		x_amplitude = 2;
		y_amplitude = 2;
		z_amplitude = 2;


		xr_offset = 0;
		yr_offset = 0;
		zr_offset = 0;
		xr_speed = 0;
		yr_speed = 0;
		zr_speed = -1;
		xr_amplitude = 180;
		yr_amplitude = 180;
		zr_amplitude = 180;

		xm_offset = 0;
		ym_offset = 0;
		zm_offset = 0;
		xm_speed = 0;
		ym_speed = 0;
		zm_speed = 0;
		xm_amplitude = 2;
		ym_amplitude = 2;
		zm_amplitude = 2;

		//don't modify below this line
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKey("1")){id = 1;col = col1;}
		else if(Input.GetKey("2")){id = 2;col = col2;}
		else if(Input.GetKey("3")){id = 3;col = col3;}
		else if(Input.GetKey("4")){id = 4;col = col4;}
		else if(Input.GetKey("5")){id = 5;col = col5;}

		tempTime += Time.deltaTime;
		if (tempTime > seconds_between_events) {
                     	tempTime = 0;
			if(Input.GetKey("space")){button = 1;}else{button = 0;}
             		sendevent1();
        	}
	}

	void sendevent1() {
		float x = x_amplitude*Mathf.Sin(Time.time * x_speed + x_offset);
		float y = y_amplitude*Mathf.Sin(Time.time * y_speed + y_offset);
		float z = z_amplitude*Mathf.Sin(Time.time * z_speed + z_offset);
		float xr = xr_amplitude*Mathf.Sin(Time.time * xr_speed + xr_offset);
		float yr = yr_amplitude*Mathf.Sin(Time.time * yr_speed + yr_offset);
		float zr = zr_amplitude*Mathf.Sin(Time.time * zr_speed + zr_offset);
		float xm = xm_amplitude*Mathf.Sin(Time.time * xm_speed + xm_offset);
		float ym = ym_amplitude*Mathf.Sin(Time.time * ym_speed + ym_offset);
		float zm = zm_amplitude*Mathf.Sin(Time.time * zm_speed + zm_offset);


		eventhistoryupdate("id:"+id+"x:"+x.ToString("F2")+"y:"+y.ToString("F2")+"z:"+z.ToString("F2")+"xr:"+(int)xr+"yr:"+(int)yr+"zr:"+(int)zr+"xm:"+(int)xm+"ym:"+(int)ym+"zm:"+(int)zm+"b:"+button);

		event1(id,col, x,y,z, xr,yr,zr, xm,ym,zm, button);
	}



	


   void eventhistoryupdate(string uusi) {
        for(int i = 0; i<6; i++) {
            eventhistory_list[i] = eventhistory_list[i+1];
        }
        eventhistory_list[6] = uusi;

        eventhistory_text.text = eventhistory_list[0]+ "\n" + eventhistory_list[1] +"\n"+ eventhistory_list[2] +"\n"+ eventhistory_list[3] +"\n"+ eventhistory_list[4] +"\n"+ eventhistory_list[5] +"\n"+ eventhistory_list[6];
    }


}
