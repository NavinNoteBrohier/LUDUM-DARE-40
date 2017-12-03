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
	public float RotateTowardsSpeed = 1;

	#endregion

	#region Private variables

	Vector3 PointerDirection;


	#endregion


	#region // Player references
	public GameObject TopSprite;
	public GameObject BottomSprite;
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

		///

		if (KeyDown(KeyCode.A)) UserAxis.SetY(-1);

		else if (KeyDown(KeyCode.D)) UserAxis.SetY(1);

		else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) UserAxis.SetY(0); // Could be done better

		Move(UserAxis);

		#endregion

		#region Aiming and combat
		// Get location of the cursor on the screen
		PointerDirection = RaycastOut(Cam_reference.ScreenPointToRay(Input.mousePosition));
		// Rotate the body of the wizard towards the cursor.
		Vector3 NewLookDirection = PointerDirection - TopSprite.transform.position;
		float GetAngle = Mathf.Atan2(NewLookDirection.y, NewLookDirection.x) * Mathf.Rad2Deg;
		Quaternion Rotator = Quaternion.AngleAxis(GetAngle, Vector3.forward);
		TopSprite.transform.rotation = Quaternion.Slerp(TopSprite.transform.rotation, Rotator, Time.deltaTime * RotateTowardsSpeed);
		//

		if(Input.GetMouseButtonDown(0))
		{


			if(Input.GetMouseButtonUp(0))
			{

			}
		}

		#endregion
	}
}
