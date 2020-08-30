using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("IsPlaying", false);
        Invoke("EnableAnimation", 3);
    }

    void EnableAnimation()
    {
        GetComponent<Animator>().SetBool("IsPlaying", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
