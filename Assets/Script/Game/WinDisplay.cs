using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinDisplay : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Button button;
    public void DisplayWin (string player) {
        Show();
        text.text = $"{player} Win!";
    }
    private void Start() {
        Hide();
    }
    public void Hide() {
        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }
    
    private void Show() {
        text.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }
}
