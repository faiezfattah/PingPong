using System;
using UnityEngine;
using UnityEngine.Events;

public class Mover : MonoBehaviour 
{
    [SerializeField] private UnityEvent OnBallHit;
    
    private Rigidbody2D rb;
    private float _dir;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()  {
        if (_dir != 0)  {
            rb.linearVelocity = Vector2.up * (-_dir * GameSettings.Instance.PADDLE_SPEED);
        }
        else {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void Move(float dir) {
        _dir =  Mathf.Clamp(dir, -1f, 1f);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            OnBallHit?.Invoke();
        }
    }
}