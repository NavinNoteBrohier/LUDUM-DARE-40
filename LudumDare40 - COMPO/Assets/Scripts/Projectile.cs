using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Entity
{
	public float Speed;
	public Vector2 Direction;
	public float Size;
	public float Damage;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		RB_Reference.velocity = transform.forward * Speed;

	}

	public void SetSpeed(float a_Speed)
	{
		Speed = a_Speed;
	}
}
