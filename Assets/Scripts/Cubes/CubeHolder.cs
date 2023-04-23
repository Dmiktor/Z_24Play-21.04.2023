using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float jumpHeight;

    private void OnEnable(){
        BlockCollision.OnBlockPikeUp += AddNewBlock;
    }

    private void OnDisable(){
        BlockCollision.OnBlockPikeUp -= AddNewBlock;
    }

    private void AddNewBlock(){
        playerTransform.Translate(Vector3.up * jumpHeight);
        (Instantiate(cubePrefab, new Vector3(playerTransform.position.x, 0, playerTransform.position.z), Quaternion.identity) as GameObject).transform.parent = this.transform;
    }
}
