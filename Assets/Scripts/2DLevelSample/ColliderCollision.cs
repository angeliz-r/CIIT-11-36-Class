using UnityEngine;

public class ColliderCollision : MonoBehaviour
{
    [SerializeField] private bool showDebug = true;

    private void OnCollisionEnter2D(Collision2D objectCollidedWith)
    {
        if (showDebug)
            Debug.Log("Collision entered!");
    }

    private void OnCollisionStay2D(Collision2D objectCollidedWith)
    {
        if (showDebug)
            Debug.Log("Collision stay!");
    }

    private void OnCollisionExit2D(Collision2D objectCollidedWith)
    {
        if (showDebug)
            Debug.Log("Collision exit!");
    }
}
