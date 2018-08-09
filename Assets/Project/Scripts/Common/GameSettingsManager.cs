using Newtonsoft.Json;
using UnityEngine;

public class GameSettingsManager : MonoBehaviour {
    public GameSettings GameSettings {
        get { return JsonConvert.DeserializeObject<GameSettings>(PlayerPrefs.GetString("GameSettings", "{}")); }
        set { PlayerPrefs.SetString("GameSettings", JsonConvert.SerializeObject(value));}
    }
}