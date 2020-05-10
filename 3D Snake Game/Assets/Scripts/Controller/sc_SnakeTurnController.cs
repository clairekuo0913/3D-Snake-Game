using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_SnakeTurnController : MonoBehaviour
{
    
    GameObject gmobj_Cube;

    // Start is called before the first frame update
    void Start()
    {
    	gmobj_Cube = GameObject.FindWithTag("Cube");
    }

    // Update is called once per frame
    void Update()
    {
    	if(gmobj_Cube.GetComponent<sc_CubeRotation>().bool_AboutToRotate == true){
    		this.transform.position = gmobj_Cube.transform.position;
    		/*if(this.GetComponent<Collider>){

    		}*/
    	}
        
    }

   
}
