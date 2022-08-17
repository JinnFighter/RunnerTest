using UnityEngine;

namespace Helpers
{
    public interface IContent<T>
    {
        T Generate(Vector3 position);
    }
}
