using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Zach
{
    public class PlayerBase : NetworkBehaviour
    {
        public Rigidbody rigidBody;
        public Vector3 rotateVelocity;
        public float speed;
        public float maxSpeed;

        public float forwardFloat;
        private ZachsPlayerActions zachsPlayerActions;

        
        // Start is called before the first frame update
        public override void OnStartLocalPlayer()
        {
            base.OnStartLocalPlayer();

            Debug.Log(isLocalPlayer);
        }

        public void EnableControls()
        {
            //todo refactor to work with system wide new input system
            zachsPlayerActions = new ZachsPlayerActions();
            zachsPlayerActions.Enable();

            zachsPlayerActions.GeneralMovement.Move.started += Movement;
            zachsPlayerActions.GeneralMovement.Move.canceled += Movement;
            zachsPlayerActions.GeneralMovement.Rotate.started += RotateOnPerformed;
            zachsPlayerActions.GeneralMovement.Rotate.canceled += RotateOnPerformed;
        }

        public void DisableControls()
        {
            //todo refactor to work with system wide new input system
            zachsPlayerActions = new ZachsPlayerActions();
            zachsPlayerActions.Enable();

            zachsPlayerActions.GeneralMovement.Move.started -= Movement;
            zachsPlayerActions.GeneralMovement.Move.canceled -= Movement;
            zachsPlayerActions.GeneralMovement.Rotate.started -= RotateOnPerformed;
            zachsPlayerActions.GeneralMovement.Rotate.canceled -= RotateOnPerformed;
        }

        public void FixedUpdate()
        {
            if (isLocalPlayer)
            {
                rigidBody.AddRelativeForce(Vector3.up * speed * forwardFloat);
                rigidBody.angularVelocity = rotateVelocity;
                if (rigidBody.velocity.magnitude >= maxSpeed)
                    rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
            }
        }
        

        private void Movement(InputAction.CallbackContext obj)
        {
            //velocity = new Vector3(0, 0, speed * obj.ReadValue<float>());
            forwardFloat = obj.ReadValue<float>();
        }

        private void RotateOnPerformed(InputAction.CallbackContext obj)
        {
            rotateVelocity = new Vector3(0, 0, -15 * obj.ReadValue<float>());
        }
    }
}