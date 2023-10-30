using Infrastructure.Payloads;
using UnityEngine;

namespace Enemies.StatePayloads
{
    public class RunStatePayload : IPayloadForState
    {

        public RunStatePayload(Rigidbody2D rigidbody2D, Vector2 targetDirection, float speed)
        {
            Rigidbody2D = rigidbody2D;
            TargetDirection = targetDirection;
            Speed = speed;
        }
        
        public Rigidbody2D Rigidbody2D { get; }
        public Vector2 TargetDirection { get; }
        public float Speed { get; }
    }
}