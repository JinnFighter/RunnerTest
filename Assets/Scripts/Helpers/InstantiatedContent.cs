using UnityEngine;

namespace Helpers
{
    public class InstantiatedContent<T> : IContent<T> where T : MonoBehaviour
    {
        private readonly T _prefab;

        public InstantiatedContent(T prefab)
        {
            _prefab = prefab;
        }

        public T Generate(Vector3 position)
        {
            return Object.Instantiate(_prefab, position, Quaternion.identity);
        }
    }
}
