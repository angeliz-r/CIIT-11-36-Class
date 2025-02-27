using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    [SerializeField] private bool showDebug = true;

    private void OnTriggerEnter2D(Collider2D objectCollidedWith)
    {
        if (showDebug)
            Debug.Log("Trigger entered!");
    }

    private void OnTriggerStay2D(Collider2D objectCollidedWith)
    {
        if (showDebug)
            Debug.Log("Trigger stay!");
    }

    private void OnTriggerExit2D(Collider2D objectCollidedWith)
    {
        if (showDebug)
            Debug.Log("Trigger exit!");
    }
}
