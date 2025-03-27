using UnityEngine;
using Unity.VisualScripting;

public class ComputerBrain : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Mover player2Mover;
   
    [Header("AI Movement Settings")]
    [SerializeField] private float randomizer = 0.5f;

    private Rigidbody2D ballRigidbody;
    private float targetYPosition;


    private void Start() {
        ballRigidbody = ballTransform.GetComponent<Rigidbody2D>();
       
        if (ballRigidbody == null) {
            Debug.LogError("Ball must have a Rigidbody2D component!");
        }
    }

    private void FixedUpdate() {
        if (!GameSettings.Instance.IS_PLAYER2_AI) return;
        MovePaddle();
    }


    // note: called by Ball OnHit event
    public void PredictBall() {
        Vector2 ballVelocity = ballRigidbody.linearVelocity;
        Vector2 currentBallPosition = ballTransform.position;

        float intersectionY = CalculateTrajectoryIntersection(currentBallPosition, ballVelocity);
    
        targetYPosition = intersectionY + Random.Range(-randomizer, randomizer);

        // debug
        Debug.DrawLine(currentBallPosition, new Vector2(player2Mover.transform.position.x, intersectionY), Color.red);
    }

    private float CalculateTrajectoryIntersection(Vector2 startPosition, Vector2 velocity) {
        float timeToReachPaddle = (player2Mover.transform.position.x - startPosition.x) / velocity.x;
        float intersectionY = startPosition.y + (velocity.y * timeToReachPaddle);

        return intersectionY;
    }

    private void MovePaddle() {
        float direction = Mathf.Clamp(player2Mover.transform.position.y - targetYPosition, -1f, 1f);
        player2Mover.Move(direction);
    }
}