using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterController
	: MonoBehaviour
{
	public float walkSpeed = 3f;
	public float runSpeed = 6f;

	public float jumpHeight = 1f;
	public float gravity = -11f;

	public float speedSmoothTime = 0.2f;
	public float rotSmoothTime = 0.1f;

	[SerializeField]
	private PlayerID _playerID;

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

	void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	void Update()
	{
		movInput = new Vector3(InputManager.GetAxis("Horizontal", _playerID), 0, InputManager.GetAxis("Vertical", _playerID)).normalized;
		lookInput = new Vector3(InputManager.GetAxis("LookHorizontal", _playerID), 0, InputManager.GetAxis("LookVertical", _playerID)).normalized;

		yVelocity += gravity * Time.deltaTime;

		if ((InputManager.GetButtonDown("Jump", _playerID)))
			Jump();

		Movement();
		if (lookInput != Vector3.zero)
			Rotate();

	}

	private void Jump()
	{
		if (characterController.isGrounded)
			yVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
	}

	private void Movement()
	{
		isRunning = Input.GetKey(KeyCode.LeftShift);

		float targetSpeed = ((isRunning == true) ? runSpeed : walkSpeed) * movInput.magnitude;
		xzVelocity = Mathf.SmoothDamp(xzVelocity, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

		currentVelocity = movInput * xzVelocity + Vector3.up * yVelocity;
		characterController.Move(currentVelocity * Time.deltaTime);

		xzVelocity = new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;

		if (characterController.isGrounded)
			yVelocity = -0.00001f;
	}

	private void Rotate()
	{
		////Calculamos rotacion según el dirInput y le sumamos rotación según la cámara
		float targetRot = Mathf.Atan2(lookInput.x, lookInput.z);
		Debug.Log(Mathf.Rad2Deg * targetRot);
		//Obtenemos la cantidad de rotación suavizada (https://docs.unity3d.com/ScriptReference/Mathf.SmoothDampAngle.html)
		float smoothedRot = Mathf.SmoothDampAngle(transform.eulerAngles.y, Mathf.Rad2Deg * targetRot, ref rotSmoothVelocity, rotSmoothTime);
		//Aplicamos la rotación suavizada a nuestra rotación local. Sería lo mismo escribir:
		// transform.localEulerAngles = new Vector3(0, smoothedRot, 0);
		// o también:
		//transform.localRotation = Quaternion.Euler(0, smoothedRot, 0);
		transform.localEulerAngles = Vector3.up * smoothedRot;
	}
}
