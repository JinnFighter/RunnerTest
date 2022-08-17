using UnityEngine;

namespace Descriptions
{
    [CreateAssetMenu(fileName = "PlayerDescription", menuName = "Descriptions/PlayerDescription")]
    public class PlayerDescription : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 3f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 0.3f;
    }
}
