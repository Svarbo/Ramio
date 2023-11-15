using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UserInfo", menuName = "ScriptableObject/UserInfo", order = 0)]
    public class UserInfo : ScriptableObject
    {
        [field: SerializeField] public bool IsMobile { get; set; } = false;
    }
}