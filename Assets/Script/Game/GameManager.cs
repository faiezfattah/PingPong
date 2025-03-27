using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private Ball ball;
    [SerializeField] private ScoreBoard score;
    [SerializeField] private WinDisplay winDisplay;
   
    private int p1Score = 0;
    private int p2Score = 0;

    public void HandlePlayer1Trigger() {
        p2Score += 1;
        score.UpdatePlayer1(p2Score);
        HandleReset();
    }
   
    public void HandlePlayer2Trigger() {
        p1Score += 1;
        score.UpdatePlayer2(p1Score);
        HandleReset();
    }

    private void HandleReset() {
        Debug.Log($"score: {p1Score} v {p2Score}");

        if (p1Score == GameSettings.Instance.SCORE_TO_WIN) {
            EndGame("Player 1");
            return;
        } 
        else if (p2Score == GameSettings.Instance.SCORE_TO_WIN) {
            string winMessage = GameSettings.Instance.IS_PLAYER2_AI 
                ? "Computer" 
                : "Player 2";
            EndGame(winMessage);
            return;
        }

        ball.gameObject.transform.position = Vector3.zero;
        ball.Launch();
    }

    private void EndGame(string winMsg) {
        ball.gameObject.transform.position = Vector3.zero;
        ball.Stop();
        winDisplay.DisplayWin(winMsg);
    }
    public void ResetGame() {
        p1Score = 0;
        p2Score = 0;
        score.UpdatePlayer2(p2Score);
        score.UpdatePlayer1(p1Score);

        ball.gameObject.transform.position = Vector3.zero;
        ball.Launch();
    }
}