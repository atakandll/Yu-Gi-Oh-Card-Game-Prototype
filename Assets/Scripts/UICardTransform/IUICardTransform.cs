using UnityEngine;

namespace UICardTransform
{
    public interface IUICardTransform
    {
        UIMotionBaseCard Movement { get; }
        UIMotionBaseCard Rotation { get; }
        UIMotionBaseCard Scale { get; }
        void MoveTo(Vector3 position, float speed,float delay = 0);
        void MoveToWithZAxis(Vector3 position, float speed, float delay = 0);
        void RotateTo(Vector3 euler, float speed);
        void ScaleTo(Vector3 scale, float speed, float delay = 0);
    }
}