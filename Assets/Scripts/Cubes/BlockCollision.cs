using System;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public static Action OnBlockPikeUp;
    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private LayerMask collisionLayerMask;
      private void OnCollisionEnter(Collision collision)
    {
        CheckForPickup(collision);
        CheckForCollision(collision);
        CheckForOutOfBounds();
    }

    private void CheckForPickup(Collision collision)
    {
        if (pickupLayerMask == (pickupLayerMask | (1 << collision.gameObject.layer)))
        {
            Destroy(collision.gameObject);
            OnBlockPikeUp?.Invoke();
        }
    }

    private void CheckForCollision(Collision collision)
    {
        if (collisionLayerMask == (collisionLayerMask | (1 << collision.gameObject.layer)))
        {
            float trueWallY = collision.transform.position.y + 0.5f;
            if (transform.position.z > collision.transform.position.z - 0.4f)
            {
                return;
            }
            if (transform.position.y < trueWallY + 0.2f && transform.position.y > trueWallY - 0.2f)
            {
                transform.parent = null;
            }
        }
    }

    private void CheckForOutOfBounds()
    {
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }
}