using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackFiller : MonoBehaviour
{
    [SerializeField] private GameObject[] pickUpsPrefabs;
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float speed;

    private Vector3 targetPosition;

    private void Awake()    
    {
        GenerateObstacle();
        GeneratePickUps();
    }
    private void FixedUpdate()
    {
        if (transform.position.y < 0) { moveToPlace(); }

    }
    private void GeneratePickUps() {
        GameObject pickUps = Instantiate(pickUpsPrefabs[Random.Range(0, pickUpsPrefabs.Length)]);
        pickUps.transform.parent = transform;
        pickUps.transform.position = new Vector3(0f, 0f, 15f);
    }

    private void GenerateObstacle() {
        GameObject obstacle = Instantiate(obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)]);
        obstacle.transform.parent = transform;
        obstacle.transform.position = new Vector3(0f, 0f, 30f);
    }

    private void moveToPlace(){
        transform.Translate(Vector3.up * speed);
    }
}
