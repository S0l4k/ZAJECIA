using StateMachine;

using UnityEngine;


namespace Player
{
    public class PlayerSmashingState: State
    {
        private float _attackForce = 20f;
        private Rigidbody _rb;
        public PlayerSmashingState(StateMachine.StateMachine stateMachine) : base(stateMachine) { }
        public override void Enter()
        {
            base.Enter();
            _rb = stateMachine.GetComponent<Rigidbody>();
            _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, _attackForce, _rb.linearVelocity.z);
            _rb.AddForce(new Vector3(0,-_attackForce, 0 ), ForceMode.Impulse);
        }
        public override void Update()
        {
            Debug.Log("SLAMING");
            Debug.Log("SLAMING");
            if (Physics.Raycast(stateMachine.transform.position, Vector3.down, stateMachine.transform.localScale.y + 0.2f))
            {
                stateMachine.Begin(new PlayerGroundedState(stateMachine));
            }
        }
    }
}