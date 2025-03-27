using StateMachine;
using UnityEngine;

namespace Player
{
    public class PLayerJumpState: State
    {
        private float _jumpForce = 20f;
        private Rigidbody _rb;
        public PLayerJumpState(StateMachine.StateMachine stateMachine) : base(stateMachine) { }

        public override void Enter() 
        {
            _rb= stateMachine.GetComponent<Rigidbody>();
            _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z);
        }

        public override void Update() 
        {
            if(Physics.Raycast(stateMachine.transform.position, Vector3.down,  stateMachine.transform.localScale.y + 0.2f))
            {
                stateMachine.Begin(new PlayerGroundedState(stateMachine));
            }
        }
    }
}
