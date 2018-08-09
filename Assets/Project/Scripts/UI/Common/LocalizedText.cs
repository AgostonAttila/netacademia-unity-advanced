using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Text objektum mellé komponens, ami átírja a szöveget megfelelő nyelvűre (a betöltött LocalizedString listából)
public class LocalizedText : MonoBehaviour {
    [SerializeField] private string _localizationStringKey;

    private LocalizationController _localizationController;
    private Text _text;

    private void Awake() {
        _localizationController = FindObjectOfType<LocalizationController>();
        _text = GetComponent<Text>();
    }

    private void Start() {
        // megkeressük azt a bejegyzést, amelynek a kulcs értéke az általunk beállított
        _text.text = _localizationController.LocalizedStrings
            .FirstOrDefault(ls => ls.Key == _localizationStringKey)?
            .Value;
    }
}