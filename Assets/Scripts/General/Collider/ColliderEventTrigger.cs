using UnityEngine;
using UnityEngine.Events;

public class ColliderEventTrigger : MonoBehaviour
{
    public UnityEvent<GameObject, Collision> OnEventCollisionEnter { get; private set; } = new();
    public UnityEvent<GameObject, Collision> OnEventCollisionStay { get; private set; } = new();
    public UnityEvent<GameObject, Collision> OnEventCollisionExit { get; private set; } = new();
    public UnityEvent<GameObject, Collider> OnEventTriggerEnter { get; private set; } = new();
    public UnityEvent<GameObject, Collider> OnEventTriggerStay { get; private set; } = new();
    public UnityEvent<GameObject, Collider> OnEventTriggerExit { get; private set; } = new();

    private void OnCollisionEnter(Collision collision)
    {
        OnEventCollisionEnter.Invoke(gameObject, collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        OnEventCollisionStay.Invoke(gameObject, collision);
    }
    private void OnCollisionExit(Collision collision)
    {
        OnEventCollisionExit.Invoke(gameObject, collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnEventTriggerEnter.Invoke(gameObject, other);
    }
    private void OnTriggerStay(Collider other)
    {
        OnEventTriggerStay.Invoke(gameObject, other);
    }
    private void OnTriggerExit(Collider other)
    {
        OnEventTriggerExit.Invoke(gameObject, other);
    }
}