using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDelay : MonoBehaviour
{
    public float Delay;
    public string ParamName;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool(ParamName, false);
        Invoke("EnableAnimation", Delay);
    }

    void EnableAnimation()
    {
        GetComponent<Animator>().SetBool(ParamName, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
