using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject a;
    public GameObject b;
    public GameObject c;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(("Go"),0.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            a.transform.DOMoveX(a.transform.position.x+1.0f,1.0f,false);
            Chain();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            a.transform.DOMoveX(a.transform.position.z+1.0f,1.0f,false);
            Chain();
        }
         
    }
    void Go()
    {

    }

    void Chain()
    {
        float abc = (b.transform.position.x - a.transform.position.x);
        float def = (b.transform.position.y - a.transform.position.y);
        if(Mathf.Abs(def) >= Mathf.Abs(abc))
        {

        }

    }
}
