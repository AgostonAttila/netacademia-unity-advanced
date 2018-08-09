using UnityEngine;

public class GraphicsController : MonoBehaviour {
    private void Start() {
        var gameSettingsManager = FindObjectOfType<GameSettingsManager>();
        var gameSettings = gameSettingsManager.GameSettings;
        
        QualitySettings.SetQualityLevel(2 * gameSettings.GraphicsQuality, true);
        if (gameSettings.IsAdvancedGraphicsEnabled) {
            QualitySettings.antiAliasing = gameSettings.AntiAliasingLevel;
        }
    }
}