using UnityEngine;

namespace Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithZ(this Vector3 v, float z)
        {
            return new Vector3(v.x, v.y, z);
        }

    }
}