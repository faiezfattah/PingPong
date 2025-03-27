using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI p1;
    [SerializeField] private TextMeshProUGUI p2;
    public void UpdatePlayer2(int value) {
        p1.text = value.ToString();
    }
    
    public void UpdatePlayer1(int value) {
        p2.text = value.ToString();
    }
}
