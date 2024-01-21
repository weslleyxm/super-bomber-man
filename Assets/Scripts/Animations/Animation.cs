using UnityEngine;

namespace Remake.Animations  
{ 
    [CreateAssetMenu(fileName = "Animation", menuName = "Remake/Animation")] 
    public class Animation : ScriptableObject
    { 
        public string animationName; 
        public Sprite[] sprites;

        public Sprite defaultSprite;
    }
}