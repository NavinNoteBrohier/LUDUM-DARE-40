using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	#region // Exposed Entity variables
	public float Health = 0;
	private float m_Health;

	public float Speed_X, Speed_Y;
	private float m_Speed_X, m_Speed_Y;
	#endregion

	public struct Movement_Axis
	{
		float x, y;
		public void SetXY(float a_x, float a_y) { x = a_x; y = a_y; }
		public void SetX(float a_x) { x = a_x;}
		public void SetY(float a_y) { y = a_y;}
		public float GetX() { return y; }
		public float GetY() { return x; }

		public float Up, Down, Left, Right;
		public void SetUPLR(float a_Up, float a_Down, float a_Left, float a_Right)
		{
			Up		= a_Up;
			Down	= a_Down;
			Left	= a_Left;
			Right	= a_Right;
		}
		public void SetUp() { }
		public void SetDown() { }
		public void SetLeft() { }
		public void SetRight() { }
		public float GetUp() { return Up; }
		public float GetDown() { return Down; }
		public float GetLeft() { return Left; }
		public float GetRight() { return Right; }
	}

	public Movement_Axis UserAxis;

	#region References
	public Rigidbody RB_Reference;
	public SpriteRenderer SR_Reference;
	#endregion

	// Use this for initialization
	void Start()
	{
		m_Health = Health;
		UserAxis = new Movement_Axis();
		UserAxis.SetXY(0, 0);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Move(Movement_Axis Direction)
	{
		// Movement has been done in this way so that the Player and the enemies can use the same movement scripts and mechanics.

		Vector3 Position = transform.position;
		
		Position.x += (Speed_X + Time.deltaTime) * UserAxis.GetX();
		Position.y += (Speed_Y + Time.deltaTime) * UserAxis.GetY();
		Position.z = transform.position.z;

		transform.position = Position;

	}

	public void Attack(Vector2 Direction, GameObject Projectile)
	{

	}
}
