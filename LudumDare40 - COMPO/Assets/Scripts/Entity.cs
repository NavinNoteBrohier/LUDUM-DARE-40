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

	public GameObject Attack;
	#endregion

	#region Private Variables

	RaycastHit MouseRayHit;

	#endregion

	public struct Movement_Axis
	{
		float x, y;
		public void SetXY(float a_x, float a_y) { x = a_x; y = a_y; }
		public void SetX(float a_x) { x = a_x;}
		public void SetY(float a_y) { y = a_y;}
		public float GetX() { return y; }
		public float GetY() { return x; }
	}

	public Movement_Axis UserAxis;

	#region References
	public Rigidbody RB_Reference;
	public SpriteRenderer SR_Reference;
	public Camera Cam_reference;
	#endregion

	// Use this for initialization
	void Initialise()
	{
		m_Health = Health;
		UserAxis = new Movement_Axis();
		UserAxis.SetXY(0, 0);
		m_Speed_X = Speed_X;
		m_Speed_Y = Speed_Y;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Move(Movement_Axis Direction)
	{
		// Movement has been done in this way so that the Player and the enemies can use the same movement scripts and mechanics.
		// Can be fed manual input or a programmed sequence
		Vector3 Position = transform.position;
		
		Position.x += (Speed_X + Time.deltaTime) * UserAxis.GetX();
		Position.y += (Speed_Y + Time.deltaTime) * UserAxis.GetY();
		Position.z = transform.position.z;

		transform.position = Position;

	}

	public bool LaunchAttack(Quaternion Direction, Vector3 Origin, GameObject Attack, float Speed)
	{
		GameObject obj = Instantiate(Attack, Origin, Direction);
		obj.GetComponent<Projectile>().SetSpeed();

		return false;
	}

	public Vector3 RaycastOut(Ray RayToHit)
	{
		if(Physics.Raycast(RayToHit,out MouseRayHit,1000)) // Ideally for raycasting to camera, but left open in case I use a different raycast in the future for something else.
		{
			return MouseRayHit.point;
		}

		return Vector3.zero;
	}
}
