using UnityEngine;

public class BoxController : MonoBehaviour
{
    public bool isOnTarget = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Target"))
        {
            isOnTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Target"))
        {
            isOnTarget = false;
        }
    }
}
