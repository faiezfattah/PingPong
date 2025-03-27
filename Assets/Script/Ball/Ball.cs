using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {
    [SerializeField] public UnityEvent OnHit;
    [SerializeField] private Rigidbody2D _rb;
    private void Start() {
        Launch();
    }

    public void Launch() {
        var xVel = Random.Range(0, 1f) > 0.5 ? -1 : 1;
        var yVel = Random.Range(0, 1f) > 0.5 ? -1 : 1;
        _rb.linearVelocity = new Vector2(xVel, yVel) * GameSettings.Instance.BALL_SPEED;
    }
    public void Stop() {
        _rb.linearVelocity = Vector2.zero;
    }
    // private void OnCollisionEnter2D(Collision2D collision) {
    //     var normal = collision.contacts[0].normal;
    //     var bounceDir = Vector2.Reflect(_rb.linearVelocity, normal).normalized;

    //     _rb.linearVelocity = bounceDir * SceneSettings.Instance.BALL_SPEED;
    // }    
    private void OnCollisionEnter2D(Collision2D collision) {
        OnHit?.Invoke();
        // Debug.Log("ball hit!");
    }
}
