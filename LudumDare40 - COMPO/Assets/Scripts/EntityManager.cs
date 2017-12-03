using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
	// Here so the Dragons can reference data about the player.
	public GameObject Player_Ref;

	// A list of alllll the active dragons so I can access them and tell them to do things.
	public GameObject[] Active_Dragon_Ref;

	public float DragonTimer;
	private float DragonTimerReset;


	[System.Serializable]
	struct Dragons
	{
		GameObject Dragon_Prefab;
		float Speed;
		float Health;
		float Damage;
	}


	public GameObject Max_Point;
	public GameObject Min_Point;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}


	void SpawnDragon(Vector2 Pos_Min, Vector2 Pos_Max, GameObject Dragon)
	{
		Vector2 ObjPos = new Vector2();
		ObjPos.x = Random.Range(Pos_Min.x, Pos_Max.x);
		ObjPos.y = Random.Range(Pos_Min.y, Pos_Max.y);

		GameObject Obj = Instantiate(Dragon);
		Obj.transform.position = ObjPos;


	}
}
