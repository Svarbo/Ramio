using Enemies.TypeEnemies.Chameleons;
using Infrastructure.Payloads;

namespace Enemies.StatePayloads
{
    public class AttackStatePayload : IPayloadForState
    {
        public AttackStatePayload(IDamageable damageable, Chameleon chameleon)
        {
            Damageable = damageable;
            Chameleon = chameleon;

        }
        
        public IDamageable Damageable { get; }
        public Chameleon Chameleon { get; }
    }
}