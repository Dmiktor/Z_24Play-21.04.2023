using System;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public static Action OnPlayerHitTheWall;
    [SerializeField] private LayerMask collisionLayerMask;
   void OnCollisionEnter(Collision collision) {
        if (collisionLayerMask == (collisionLayerMask | (1 << collision.gameObject.layer))) {
            OnPlayerHitTheWall?.Invoke();
        }
    }
}
