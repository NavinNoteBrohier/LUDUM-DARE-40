using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
	public float MovementTimer,AttackTimer;
	private float Reset_MovementTimer,ResetAttackTimer;

	public GameObject Gold;

	public Transform TargetLocation;

	Ray PlayerRay;
	public Vector3 Direction;
	public Vector2 NewLocation;

	public GameObject Head;
	public GameObject Body;
	public CircleCollider2D MoveCircle;

	public float AttackSpeed;

	public bool CanSeePlayer;

	// Use this for initialization
	void Start ()
	{
		Reset_MovementTimer = MovementTimer;
		Direction = new Vector3();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MovementTimer = MovementTimer <= 0 ? 0 : MovementTimer - Time.deltaTime;

		if(MovementTimer == 0 && !CanSeePlayer)
		{

			// Should have just made a function for this.
			NewLocation.x = Random.Range(Manager_Reference.GetComponent<EntityManager>().Min_Point.transform.position.x, Manager_Reference.GetComponent<EntityManager>().Max_Point.transform.position.x);
			NewLocation.y = Random.Range(Manager_Reference.GetComponent<EntityManager>().Min_Point.transform.position.y, Manager_Reference.GetComponent<EntityManager>().Max_Point.transform.position.y);


			MovementTimer = Reset_MovementTimer;
		}

		UserAxis.SetX(NewLocation.x < transform.position.x ? NewLocation.x == transform.position.x ? 0 : -1 : 1);
		UserAxis.SetY(NewLocation.y < transform.position.y ? NewLocation.y == transform.position.x ? 0 : -1 : 1);

		Move(UserAxis);
		///

		TargetLocation = Manager_Reference.GetComponent<EntityManager>().Player_Ref.transform;

		Direction = TargetLocation.position - transform.position;
		RaycastHit RayHit;
		if (Physics.Raycast(Body.transform.position, Direction, out RayHit, 1000f))
		{
			if (RayHit.collider.tag == "Player")
			{
				CanSeePlayer = true;
				NewLocation = Manager_Reference.GetComponent<EntityManager>().Player_Ref.transform.position;
				LaunchAttack(Head.transform.rotation, Head.transform.position, Head.transform.position, Attack, AttackSpeed);

			
			}
			else CanSeePlayer = false;
		}
		Debug.DrawRay(Body.transform.position, Direction, Color.red,1000,true);
		AttackTimer = AttackTimer <= 0 ? 0 : AttackTimer - Time.deltaTime;
		if(AttackTimer == 0)
		{
			AttackTimer = ResetAttackTimer;
		}
	}
}
