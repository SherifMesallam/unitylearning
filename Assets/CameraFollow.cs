using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;  // Reference to the player's transform
    public Vector3 offset;             // Offset from the player

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector3 newPos = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, offset.z);
            transform.position = newPos;
        }
    }
}
