using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_Endpoint : MonoBehaviour
{
    public static void Initialize(){
    	GameObject oEndpoint = GameObject.FindWithTag("Endpoint");
    	if(oEndpoint!=null){
    		// Endpoint position
    		// oEndpoint.transform.position = LevelInfo.v3_EndpointPos;
    		// Endpoint init animation
    			/* TODO */
    		//Debug.Log("Endpoint Initialize Animation\n");

    	}else{
    		Debug.Log("Endpoint Not Found!\n");
    	}
    	// Cube Initialize Animation
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0,3,0));
    }
}
