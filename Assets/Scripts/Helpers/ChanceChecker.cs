using UnityEngine;

namespace Helpers
{
    public class ChanceChecker
    {
        public bool IsProc(int chance) => Random.Range(0, 100) > 100 - Mathf.Clamp(chance, 0, 100);
    }
}
