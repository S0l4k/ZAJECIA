using StateMachine;

using UnityEngine;


namespace Player
{
    public class PlayerGroundedState: State
    {
        private float _attackForce = 20f;
        private Vector3 _input;
        private Rigidbody _rb;
        private float _currentMovementSpeed = 15f;
        public PlayerGroundedState(StateMachine.StateMachine stateMachine) : base(stateMachine) 
        {
            
        }
        public override void Enter()
        {
            _rb = stateMachine.GetComponent<Rigidbody>();
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, _attackForce, _rb.linearVelocity.z);
        }
        public override void Update()
        {
           
           _input= new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            _rb.linearVelocity += _input * (_currentMovementSpeed * Time.deltaTime);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.SetState(new PLayerJumpState(stateMachine));
            }
        }
    }
}