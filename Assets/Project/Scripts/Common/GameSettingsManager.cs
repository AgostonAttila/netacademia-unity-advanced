using Newtonsoft.Json;
using UnityEngine;
using WonderGame.Settings;

namespace WonderGame.Common {
    public class GameSettingsManager : MonoBehaviour {
        public GameSettings GameSettings {
            get { return JsonConvert.DeserializeObject<GameSettings>(PlayerPrefs.GetString("GameSettings", "{}")); }
            set { PlayerPrefs.SetString("GameSettings", JsonConvert.SerializeObject(value));}
        }
    }
}