using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	#region // Player variables
	public float Gold;
	public float Gold_Strength;

	public float ChargeTimer,CoolDownTimer;
	private float Reset_ChargeTimer, ResetCoolDownTimer;

	public GameObject MagicAttack;
	#endregion

	// Use this for initialization
	void Start ()
	{
		#region Init
		// Use these to reset timers
		Reset_ChargeTimer = ChargeTimer;
		ResetCoolDownTimer = CoolDownTimer;

		#endregion


	}

	bool KeyDown(KeyCode a_code)
	{ // Using this to shorten down if statements below. Possibly redundant.
		return Input.GetKeyDown(a_code);
	}

	// Update is called once per frame
	void Update ()
	{
		#region Movement
		/* Movement
					W
					1
			A	-1		1	D	
					-1
					S	
		*/

		if (KeyDown(KeyCode.W))UserAxis.SetX(1);

		else if (KeyDown(KeyCode.S)) UserAxis.SetX(-1);

		else if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) UserAxis.SetX(0); // Could be done better

		if (KeyDown(KeyCode.A)) UserAxis.SetY(-1);

		else if (KeyDown(KeyCode.D)) UserAxis.SetY(1);

		else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) UserAxis.SetY(0); // Could be done better

		Move(UserAxis);

		//UserAxis.SetXY(0, 0);

		#endregion

		#region Aiming

		#endregion
	}
}
