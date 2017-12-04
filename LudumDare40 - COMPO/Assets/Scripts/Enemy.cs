using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
	public float MovementTimer,AttackTimer;
	private float Reset_MovementTimer,ResetAttackTimer;

	public GameObject Gold;

	public Transform TargetLocation;

	public float DragonPower;

	public Vector3 Direction;
	public Vector2 NewLocation;

	public GameObject Head;
	public GameObject Body;
	public GameObject Muzzle;
	public CircleCollider2D MoveCircle;

	public float AttackSpeed;

	public bool CanSeePlayer;

	// Use this for initialization
	void Start ()
	{
		Reset_MovementTimer = MovementTimer;
		ResetAttackTimer = AttackTimer;
		Direction = new Vector3();
		SetDragonPower();
	}
	
	float SetDragonPower()
	{
		float GoldLevel = Manager_Reference.GetComponent<EntityManager>().Player_Ref.GetComponent<Player>().Gold;

		DragonPower = (GoldLevel % 5) + 1;

		return DragonPower;
	}

	// Update is called once per frame
	void Update ()
	{
		MovementTimer = MovementTimer <= 0 ? 0 : MovementTimer - Time.deltaTime;
		// rotate towards
		float GetAngle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;
		Quaternion Rotator = Quaternion.AngleAxis(GetAngle, Vector3.forward);

		if (MovementTimer == 0 && !CanSeePlayer)
		{

			// Should have just made a function for this.
			NewLocation.x = Random.Range(Manager_Reference.GetComponent<EntityManager>().Min_Point.transform.position.x, Manager_Reference.GetComponent<EntityManager>().Max_Point.transform.position.x);
			NewLocation.y = Random.Range(Manager_Reference.GetComponent<EntityManager>().Min_Point.transform.position.y, Manager_Reference.GetComponent<EntityManager>().Max_Point.transform.position.y);

			gameObject.transform.rotation = Quaternion.Slerp(Muzzle.transform.rotation, Rotator, Time.deltaTime * DragonPower);

			MovementTimer = Reset_MovementTimer;
		}

		UserAxis.SetX(NewLocation.x < transform.position.x ? NewLocation.x == transform.position.x ? 0 : -1 : 1);
		UserAxis.SetY(NewLocation.y < transform.position.y ? NewLocation.y == transform.position.x ? 0 : -1 : 1);

		Move(UserAxis);
		///

		TargetLocation = Manager_Reference.GetComponent<EntityManager>().Player_Ref.transform;

		Direction = TargetLocation.position - transform.position;
		RaycastHit RayHit;
		if (Physics.Raycast(Body.transform.position, Direction, out RayHit, 1000f, LayerMask.NameToLayer("Player")))
		{
			CanSeePlayer = true;
			NewLocation = Manager_Reference.GetComponent<EntityManager>().Player_Ref.transform.position;
			LaunchAttack(Head.transform.rotation, Head.transform.position, Head.transform.position, Attack, AttackSpeed + 10);

			// Checking line of site to the player before attacking.
		}
		else
		{
			CanSeePlayer = false;
		}
		
		// Rotate the muzzle towards the player.

		Muzzle.transform.rotation = Quaternion.Slerp(Muzzle.transform.rotation, Rotator, Time.deltaTime * DragonPower);

		AttackTimer = AttackTimer <= 0 ? 0 : AttackTimer - Time.deltaTime;
		if(AttackTimer == 0)
		{
			if(!CanSeePlayer)
			{
				LaunchAttack(Muzzle.transform.rotation, Direction, Muzzle.transform.position, Attack, DragonPower + 10);
			}
			AttackTimer = ResetAttackTimer;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.layer == LayerMask.NameToLayer("AllyProjectile"))
		{
			Health -= 1;
			if (Health <= 0)
			{
				SpawnGold();
				Destroy(gameObject);
			}
		}

	}

	void SpawnGold()
	{
		Instantiate(Gold, Muzzle.transform.position, Muzzle.transform.rotation);
	}
}
