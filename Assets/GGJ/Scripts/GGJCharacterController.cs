using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterController
	: MonoBehaviour
{
	private float speedSmoothVelocity;
	private float rotSmoothVelocity;
	private float currentHorizontalSpeed;
	private Vector3 movInput;
	private Vector3 lookInput;


	private bool isRunning = false;
	private Vector3 currentVelocity;
	private float yVelocity;
	private float xzVelocity;
	private CharacterController characterController;
	private GGJCharacterWeapon _weapon;
	private GGJCharacterEntity ownerEntity;

	void Start()
	{
		ownerEntity = GetComponent<GGJCharacterEntity>();
		characterController = GetComponent<CharacterController>();
		_weapon = GetComponent<GGJCharacterWeapon>();
	}

	void Update()
	{
		movInput = new Vector3(InputManager.GetAxis("Horizontal", ownerEntity.playerID), 0, InputManager.GetAxis("Vertical", ownerEntity.playerID)).normalized;
		lookInput = new Vector3(InputManager.GetAxis("LookHorizontal", ownerEntity.playerID), 0, InputManager.GetAxis("LookVertical", ownerEntity.playerID)).normalized;

		yVelocity += ownerEntity.gravity * Time.deltaTime;

		if ((InputManager.GetButtonDown("Jump", ownerEntity.playerID)))
			Jump();

		Movement();
		if (lookInput != Vector3.zero)
			Rotate();

		if (InputManager.GetAxis("RightTrigger", ownerEntity.playerID) > 0)
			_weapon.Attack();

	}

	private void Jump()
	{
		if (characterController.isGrounded)
			yVelocity = Mathf.Sqrt(-2 * ownerEntity.gravity * ownerEntity.jumpHeight);
	}

	private void Movement()
	{
		isRunning = Input.GetKey(KeyCode.LeftShift);

		float targetSpeed = ((isRunning == true) ? ownerEntity.runSpeed : ownerEntity.walkSpeed) * movInput.magnitude;
		xzVelocity = Mathf.SmoothDamp(xzVelocity, targetSpeed, ref speedSmoothVelocity, ownerEntity.speedSmoothTime);

		currentVelocity = movInput * xzVelocity + Vector3.up * yVelocity;
		characterController.Move(currentVelocity * Time.deltaTime);

		xzVelocity = new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

		if (characterController.isGrounded)
			yVelocity = -0.00001f;
	}

	private void Rotate()
	{
		float targetRot = Mathf.Atan2(lookInput.x, lookInput.z);
		Debug.Log(Mathf.Rad2Deg * targetRot);
		float smoothedRot = Mathf.SmoothDampAngle(transform.eulerAngles.y, Mathf.Rad2Deg * targetRot, ref rotSmoothVelocity, ownerEntity.rotSmoothTime);
		transform.localEulerAngles = Vector3.up * smoothedRot;
	}
}
