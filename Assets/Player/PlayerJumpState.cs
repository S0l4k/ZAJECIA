using StateMachine;
using UnityEngine;

namespace Player
{
    public class PLayerJumpState: State
    {
        private float _jumpForce = 10f;
        private Rigidbody _rb;
        public PLayerJumpState(StateMachine.StateMachine stateMachine) : base(stateMachine) { }

        public override void Enter() 
        {
            _rb= stateMachine.GetComponent<Rigidbody>();
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, _jumpForce, _rb.linearVelocity.z);
        }

        public override void Update() 
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                stateMachine.SetState(new PlayerSmashingState(stateMachine));
            }
            if (_rb.angularVelocity.y > 0)
                return;
           
            if(Physics.Raycast(stateMachine.transform.position, Vector3.down,  stateMachine.transform.localScale.y + 0.2f))
            {
                stateMachine.Begin(new PlayerGroundedState(stateMachine));
            }
        }
    }
}
