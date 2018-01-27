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
	public Vector3 currentVelocity;
	private float yVelocity;
	private float xzVelocity;
	private CharacterController _characterController;
	private GGJCharacterWeapon _weapon;
	private GGJCharacterEntity _ownerEntity;

	void Start()
	{
		_ownerEntity = GetComponent<GGJCharacterEntity>();
		_characterController = GetComponent<CharacterController>();
		_weapon = GetComponent<GGJCharacterWeapon>();
		_weapon.SetOwner(_ownerEntity);
	}

	void Update()
	{
		if (_ownerEntity.isDead)
			return;
		if (_ownerEntity.isStunned)
			return;
		movInput = new Vector3(InputManager.GetAxis("Horizontal", _ownerEntity.playerID), 0, InputManager.GetAxis("Vertical", _ownerEntity.playerID)).normalized;
		lookInput = new Vector3(InputManager.GetAxis("LookHorizontal", _ownerEntity.playerID), 0, InputManager.GetAxis("LookVertical", _ownerEntity.playerID)).normalized;
		yVelocity += _ownerEntity.gravity * Time.deltaTime;

		if ((InputManager.GetButtonDown("Jump", _ownerEntity.playerID)))
			Jump();

		Movement();
		if (lookInput != Vector3.zero)
			Rotate();

		if (InputManager.GetAxis("RightTrigger", _ownerEntity.playerID) > 0)
			_ownerEntity.Attack();

		UpdateAnimator();

	}

	private void Jump()
	{
		if (_characterController.isGrounded)
			yVelocity = Mathf.Sqrt(-2 * _ownerEntity.gravity * _ownerEntity.jumpHeight);
	}

	private void Movement()
	{
		isRunning = Input.GetKey(KeyCode.LeftShift);

		float targetSpeed = ((isRunning == true) ? _ownerEntity.runSpeed : _ownerEntity.walkSpeed) * movInput.magnitude;
		xzVelocity = Mathf.SmoothDamp(xzVelocity, targetSpeed, ref speedSmoothVelocity, _ownerEntity.speedSmoothTime);
		currentVelocity = movInput * xzVelocity + Vector3.up * yVelocity;
		_characterController.Move(currentVelocity * Time.deltaTime);

		xzVelocity = new Vector2(_characterController.velocity.x, _characterController.velocity.z).magnitude;

		if (_characterController.isGrounded)
			yVelocity = -0.00001f;
	}

	private void Rotate()
	{
		float targetRot = Mathf.Atan2(lookInput.x, lookInput.z);
		float smoothedRot = Mathf.SmoothDampAngle(transform.eulerAngles.y, Mathf.Rad2Deg * targetRot, ref rotSmoothVelocity, _ownerEntity.rotSmoothTime);
		transform.localEulerAngles = Vector3.up * smoothedRot;
	}

	private void UpdateAnimator()
	{
		_ownerEntity.animator.SetFloat("movSpeed", xzVelocity);
	}
}
