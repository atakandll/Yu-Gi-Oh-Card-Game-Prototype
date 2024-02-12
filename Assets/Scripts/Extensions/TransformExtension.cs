using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        public static int CloserEdge(this Transform transform, Camera camera, int width, int height)
        {
            //edge points according to the screen/camera
            var worldPointTop = camera.ScreenToWorldPoint(new Vector3(width / 2, height));
            var worldPointBot = camera.ScreenToWorldPoint(new Vector3(width / 2, 0));

            //distance from the pivot to the screen edge
            var deltaTop = Vector2.Distance(worldPointTop, transform.position);
            var deltaBottom = Vector2.Distance(worldPointBot, transform.position);

            return deltaBottom <= deltaTop ? 1 : -1;
        }
    }
}