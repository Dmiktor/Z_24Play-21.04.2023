using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardMovingSpeed = 15f;

    private float _forwardMovingSpeed;

    private void Awake()
    {
        _forwardMovingSpeed = forwardMovingSpeed / 100f;
    }
    public void Move(float targetX)
    {
        Debug.Log(targetX);
        transform.Translate(Vector3.forward * _forwardMovingSpeed);
        transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
    }
}