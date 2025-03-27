using UnityEngine;
using UnityEngine.Events;

public class TriggerReset : MonoBehaviour {
    [SerializeField] public UnityEvent OnTrigger;
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ball")) {
            OnTrigger?.Invoke();
        }
    }
}