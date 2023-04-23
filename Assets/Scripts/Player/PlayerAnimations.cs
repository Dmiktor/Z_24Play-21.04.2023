using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] GameObject blockPickUpParticle;
    [SerializeField] GameObject blockPickUpText;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnEnable()
    {
        BlockCollision.OnBlockPikeUp += AnimateBlockPickUp;
    }   

    private void OnDisable()
    {
        BlockCollision.OnBlockPikeUp -= AnimateBlockPickUp;
    } 

    private void AnimateBlockPickUp()
    {
        GameObject _blockPickUpParticle = Instantiate(blockPickUpParticle);
        _blockPickUpParticle.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        GameObject _blockPickUpText = Instantiate(blockPickUpText);
        _blockPickUpText.transform.position = new Vector3(transform.position.x + 1, transform.position.y+1, transform.position.z + 1);
        animator.SetTrigger("Jump");
    }
}
