using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float Speed;
	public Quaternion Direction;
	public float Size;
	public float Damage;

	public float LifeTime= 10;

	public Rigidbody2D RB_Reference;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (LifeTime <= 0) Destroy(this.gameObject);
		LifeTime = LifeTime <= 0 ? 0 : LifeTime -= Time.deltaTime;
	}

	public void SetSpeed(float a_Speed)
	{
		Speed = a_Speed;
		RB_Reference.AddForce(gameObject.transform.right * a_Speed, ForceMode2D.Impulse);
	}

	public void SetSpeed(float a_Speed, Vector2 a_Direction)
	{
		Speed = a_Speed;
		RB_Reference.AddForce(gameObject.transform.right * a_Speed, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Destroy(gameObject);
	}
}
