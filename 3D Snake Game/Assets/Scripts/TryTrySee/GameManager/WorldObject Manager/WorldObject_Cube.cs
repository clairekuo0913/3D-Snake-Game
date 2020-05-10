using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_Cube : MonoBehaviour
{
    public static void Initialize(){
    	GameObject oCube = GameObject.FindWithTag("Cube");
    	if(oCube!=null){
    		// cube init scale
    		oCube.transform.localScale = LevelInfo.v3_CubeScale;
    		// cube init animation
    			/* TODO */
    		//Debug.Log("Cube Initialize Animation\n");

    	}else{
    		Debug.Log("Cube Not Found!\n");
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
        
    }
}
