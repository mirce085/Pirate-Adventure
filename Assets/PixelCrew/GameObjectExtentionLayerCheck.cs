using UnityEngine;


namespace PixelCrew
{
    public static class GameObjectExtentionsLayerCheck
    { 
        public static bool IsInLayer(this GameObject gameObject, LayerMask layer)
        {
            return layer == (layer | 1 << gameObject.layer);
        }
    }
}