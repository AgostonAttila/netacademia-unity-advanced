using UnityEngine;

namespace WonderGame.UI.Common {
    [CreateAssetMenu(menuName = "Settings/Localized Strings")]
    public class LocalizedStrings : ScriptableObject {
        public LocalizedString[] Strings;
    }
}