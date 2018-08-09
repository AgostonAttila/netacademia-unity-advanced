using System.Collections.Generic;
using UnityEngine;

public class LocalizationController : MonoBehaviour {
    private LocalizedString[] _localizedStrings;

    public IEnumerable<LocalizedString> LocalizedStrings {
        get {
            if (_localizedStrings == null) {
                var gameSettingsManager = FindObjectOfType<GameSettingsManager>();
                var settings = gameSettingsManager.GameSettings;

                // a Language beállítástól függően más fájlt olvasunk be (0 = angol, 1 = magyar)
                switch (settings.Language) {
                    case 0:
                        _localizedStrings = Resources.Load<LocalizedStrings>("English").Strings;
                        break;
                    case 1:
                        _localizedStrings = Resources.Load<LocalizedStrings>("Hungarian").Strings;
                        break;
                }
            }

            return _localizedStrings;
        }
    }
}