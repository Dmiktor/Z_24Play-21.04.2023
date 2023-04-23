using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Rigidbody[] rigidBodys;
    [SerializeField] private Collider[] colliders;
    private void Awake() {
        animator = GetComponent<Animator>();
        foreach (Collider colliders in colliders) {
            colliders.enabled = false;
        }
        foreach (Rigidbody rigidbody in rigidBodys) {
            rigidbody.isKinematic = true;
        }
    }

    private void OnEnable(){
        PlayerCollisions.OnPlayerHitTheWall += TurnRagdoll;
        PlayerInput.OnPlayerDropsToPlay += TurnRagdoll;
    }

    private void OnDisable(){
        PlayerCollisions.OnPlayerHitTheWall -= TurnRagdoll;
        PlayerInput.OnPlayerDropsToPlay -= TurnRagdoll;
    }
    public void TurnRagdoll()
    {
        animator.enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        foreach (Collider colliders in colliders) {
            colliders.enabled = true;
        }
        foreach (Rigidbody rigidBody in rigidBodys) {
            rigidBody.isKinematic = false;
            rigidBody.AddForce(transform.forward * -500f);
        }
        this.enabled = false;
    }
}
