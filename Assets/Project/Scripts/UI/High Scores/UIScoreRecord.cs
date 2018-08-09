using UnityEngine;
using UnityEngine.UI;

public class UIScoreRecord : MonoBehaviour {
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _scoreText;
    
    // kiírjuk a pontszámot és a játékos nevét
    public ScoreRecord ScoreRecord {
        set {
            _nameText.text = value?.Name;
            _scoreText.text = value?.Score.ToString();
        }
    }
}
