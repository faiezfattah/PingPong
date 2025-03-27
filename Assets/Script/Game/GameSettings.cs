using UnityEngine;

public class GameSettings : MonoBehaviour {
    public float PADDLE_SPEED = 10f;
    public float BALL_SPEED = 5f; 
    public int SCORE_TO_WIN = 11;
    public bool IS_PLAYER2_AI = false;
    [Range(0, 3), Tooltip("lower is harder")]
    public float AI_DIFFICULTY = 2f;

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