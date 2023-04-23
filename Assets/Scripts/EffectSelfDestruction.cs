using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSelfDestruction : MonoBehaviour
{

    private void Start(){
    Invoke("SelfDestruction", 4.0f);
    }
    private void SelfDestruction()
    {
        Destroy(gameObject);
    }
}
