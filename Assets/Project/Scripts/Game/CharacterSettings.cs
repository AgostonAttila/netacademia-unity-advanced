using UnityEngine;

// menübe importálás attribútummal
namespace WonderGame.Game {
    [CreateAssetMenu(fileName = "CharacterSettings", menuName = "Settings/Character Move Settings")]
    public class CharacterSettings : ScriptableObject {
        public float Speed = 10f;            // karakter haladási sebessége
        public float TurnSmoothing = 20f;    // kanyarodás sebessége    
    }
}