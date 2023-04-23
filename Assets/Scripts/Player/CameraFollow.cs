using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform playerTransform; // reference to the player's transform
    void LateUpdate() {
        this.transform.position = new Vector3(3f, 8f, playerTransform.position.z -10);
    }
}