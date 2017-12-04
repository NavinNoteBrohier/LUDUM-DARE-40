using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EntityManager : MonoBehaviour
{
	// Here so the Dragons can reference data about the player.
	public GameObject Player_Ref;

	// A list of alllll the active dragons so I can access them and tell them to do things.
	public List<GameObject> Active_Dragon_Ref;

	public float DragonTimer;
	private float DragonTimerReset;


	public Text GoldDisplay;
	public Text ChargeDisplay;
	public Text HealthDisplay;
	public GameObject GOLDDISPLAYENDSCREENCAVAS;
	public Text GoldDISPLAYSCREENUPDATE;

	public bool Restarting = false;
	public float RestartTimer = 5;

	[System.Serializable]
	public struct Dragons
	{	// Should be using Getters and Setters here Nav >:(
		public GameObject Dragon_Prefab;
		public float Speed;
		public float Health;
		public float Damage; // No time to fix this
	}

	int DragonStage;

	public List<Dragons> DragonList;

	public GameObject Max_Point;
	public GameObject Min_Point;

	// Use this for initialization
	void Start()
	{
		DragonTimerReset = DragonTimer;
		GOLDDISPLAYENDSCREENCAVAS.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		DragonTimer = DragonTimer <= 0 ? 0 : DragonTimer - Time.deltaTime;

		if(DragonTimer == 0)
		{
			// Dragon dragon dragon dragon dragon
			SpawnDragon(Min_Point.transform.position, Max_Point.transform.position, DragonList[DragonStage]);
			DragonTimer = DragonTimerReset;
		}

		ChargeDisplay.text = Player_Ref.GetComponent<Player>().ChargeCounter.ToString();
		GoldDisplay.text = Player_Ref.GetComponent<Player>().Gold.ToString();
		HealthDisplay.text = Player_Ref.GetComponent<Player>().Health.ToString();

		if(Restarting)
		{
			RestartGame();
		}

	}

	public void SetPowerState()
	{
		float GoldLevel = Player_Ref.GetComponent<Player>().Gold;

		DragonTimerReset = GoldLevel / 10 + 1;

		DragonStage = DragonStage >= DragonList.ToArray().Length-1 ? DragonList.ToArray().Length-1 : (int)(GoldLevel / 50);

	}

	void SpawnDragon(Vector2 Pos_Min, Vector2 Pos_Max, Dragons Dragon)
	{
		Vector3 ObjPos = new Vector3();
		ObjPos.x = Random.Range(Pos_Min.x, Pos_Max.x);
		ObjPos.y = Random.Range(Pos_Min.y, Pos_Max.y);

		GameObject Obj = Instantiate(Dragon.Dragon_Prefab,ObjPos,transform.rotation);
		Obj.transform.position = ObjPos;
		Active_Dragon_Ref.Add(Obj);
		Obj.GetComponent<Enemy>().Manager_Reference = gameObject;
	}

	public void RestartGame()
	{

		GOLDDISPLAYENDSCREENCAVAS.SetActive(true);
		GoldDISPLAYSCREENUPDATE.text = Player_Ref.GetComponent<Player>().Gold.ToString();

		RestartTimer -= Time.deltaTime;
		if(RestartTimer <= 0)
		{
			SceneManager.LoadScene("_Main",LoadSceneMode.Single);
		}
	}
}
