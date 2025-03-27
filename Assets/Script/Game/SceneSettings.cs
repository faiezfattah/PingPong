using UnityEngine;

public class GameSettings : MonoBehaviour {
    public float PADDLE_SPEED = 1f;
    public float BALL_SPEED = 5f; 
    public bool IS_PLAYER2_AI = false;
    public int SCORE_TO_WIN = 11;

    public static GameSettings Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        // DontDestroyOnLoad(gameObject);
    }
}