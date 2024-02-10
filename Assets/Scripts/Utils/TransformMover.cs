using UnityEngine;

namespace Utils
{
    
    public class TransformMover : MonoBehaviour
    {
        public void MoveUp()
        {
            transform.localPosition = new Vector3(0,1,0);
        }

        public void MoveDown()
        {
            transform.localPosition = new Vector3(0,-1,0);
        }
    }
}