using Mirror;
using RileyMcGowan;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.VFX;

namespace Zach
{
	public class PlayerBase : NetworkBehaviour
	{
		public Rigidbody rigidBody;
		public Vector3   rotateVelocity;
		public float     speed;
		public float     maxSpeed;

		public  float              forwardFloat;
		private ZachsPlayerActions zachsPlayerActions;
		public  VisualEffect       particle;

		public void Awake()
		{
			zachsPlayerActions = new ZachsPlayerActions();
			zachsPlayerActions.Enable();
			particle.Stop();

			// Interact with Health events
			GetComponent<Health>().deathEvent += OnDeathEvent;
		}

		void OnDestroy()
		{
			GetComponent<Health>().deathEvent                  -= OnDeathEvent;
			zachsPlayerActions.GeneralMovement.Move.started    -= Movement;
			zachsPlayerActions.GeneralMovement.Move.canceled   -= Movement;
			zachsPlayerActions.GeneralMovement.Rotate.started  -= RotateOnPerformed;
			zachsPlayerActions.GeneralMovement.Rotate.canceled -= RotateOnPerformed;
		}

		void OnDeathEvent(Health obj)
		{
			// Destroy(gameObject);
			// TODO: Turn off on client probably
			// gameObject.SetActive(false);
			if (isServer)
				RpcDisableControls();
		}

		[ClientRpc]
		public void RpcEnableControls()
		{
			//todo refactor to work with system wide new input system

			zachsPlayerActions.GeneralMovement.Move.started    += Movement;
			zachsPlayerActions.GeneralMovement.Move.canceled   += Movement;
			zachsPlayerActions.GeneralMovement.Rotate.started  += RotateOnPerformed;
			zachsPlayerActions.GeneralMovement.Rotate.canceled += RotateOnPerformed;
		}

		[ClientRpc]
		public void RpcDisableControls()
		{
			//todo refactor to work with system wide new input system

			zachsPlayerActions.GeneralMovement.Move.started    -= Movement;
			zachsPlayerActions.GeneralMovement.Move.canceled   -= Movement;
			zachsPlayerActions.GeneralMovement.Rotate.started  -= RotateOnPerformed;
			zachsPlayerActions.GeneralMovement.Rotate.canceled -= RotateOnPerformed;
		}

		public void FixedUpdate()
		{
			if (isLocalPlayer)
			{
				rigidBody.AddRelativeForce(Vector3.up * speed * forwardFloat);
				rigidBody.angularVelocity = rotateVelocity;
				// if (rigidBody.velocity.magnitude >= maxSpeed)
				// rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
			}
		}


		private void Movement(InputAction.CallbackContext obj)
		{
			//velocity = new Vector3(0, 0, speed * obj.ReadValue<float>());
			forwardFloat = obj.ReadValue<float>();
			if (obj.ReadValue<float>() > 0)
			{
				particle.Play();
			}
			else
			{
				particle.Stop();
			}
		}

		private void RotateOnPerformed(InputAction.CallbackContext obj)
		{
			rotateVelocity = new Vector3(0, 0, -15 * obj.ReadValue<float>());
		}
	}
}