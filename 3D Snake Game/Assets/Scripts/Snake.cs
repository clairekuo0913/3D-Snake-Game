using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject Head;
    public GameObject Parent;
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("GO",1.0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Parent.transform.Rotate(90.0f,0.0f,0.0f,Space.Self);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Parent.transform.Rotate(-90.0f,0.0f,0.0f,Space.Self);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Parent.transform.Rotate(0.0f,0.0f,-90.0f,Space.Self);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Parent.transform.Rotate(0.0f,0.0f,90.0f,Space.Self);
        }        
    }

    public void GO()
    {
        Head = Instantiate(Head,new Vector3(Head.transform.position.x,Head.transform.position.y+1,Head.transform.position.z),Quaternion.identity,Parent.transform);
    }
}
