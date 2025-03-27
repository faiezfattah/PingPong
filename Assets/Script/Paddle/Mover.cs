using System;
using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour {
    [SerializeField] private UnityEvent OnBallHit;
    private float _dir;
    private void FixedUpdate() {
        if (_dir != 0) {
            transform.Translate(0, -_dir * Time.fixedDeltaTime * GameSettings.Instance.PADDLE_SPEED, 0);
        }
    }

    public void Move(float dir) {
        _dir = dir;
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            OnBallHit?.Invoke();
        }
    }
}