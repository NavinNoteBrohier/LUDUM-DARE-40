using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{

	public float GoldValue;

	public float GoldMin, GoldMax;

	// Use this for initialization
	void Start ()
	{
		GoldValue = (int)(Random.Range(GoldMin, GoldMax));
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
	//		Destroy(gameObject);
		}
	}
}
