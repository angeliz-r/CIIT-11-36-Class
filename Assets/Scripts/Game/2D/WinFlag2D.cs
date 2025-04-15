using UnityEngine;

public class WinFlag2D : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameManager2D.Instance.GameWin();
    }
}
