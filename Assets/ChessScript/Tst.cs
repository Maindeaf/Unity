using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tst : MonoBehaviour {
	public Vector3 pos;
	void Start ()
	{
	}
	void Update () 
	{
		if (Input.GetMouseButtonDown(0)) 
		{
			pos = Input.mousePosition;
			pos.z = -10;
			Debug.Log(Camera.main.ScreenToWorldPoint(pos));
		}
	}
}
