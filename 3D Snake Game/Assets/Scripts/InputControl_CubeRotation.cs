using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl_CubeRotation : MonoBehaviour
{

	GameObject Cube;

    // Start is called before the first frame update
    void Start(){
    	Cube =  GameObject.Find("Cube");
    }

    void OnGUI(){

    	Event e = Event.current;
    	if(e.isMouse){
    		RaycastHit hit = new RaycastHit();
    		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    		if(Physics.Raycast(ray, out hit)){
    			
    			BoxCollider CubeSurface= hit.collider.gameObject.GetComponentInChildren<BoxCollider>();
    			
    			if(CubeSurface.gameObject.name == "pos_x"){
    				Debug.Log(CubeSurface.bounds.center + "/"+ Input.mousePosition);
    				if(Mathf.Abs(e.delta.x) > Mathf.Abs(e.delta.y)){
    					Cube.GetComponent<Snake>().Rotate(new Vector3(0.0f,-90.0f,0.0f));
    				}else{
    					Debug.Log("y>x");
    				}
    			}
    			
    		}
    		

    		//Debug.Log(e.type + "/"+e.delta);
    	}
    }
    // Update is called once per frame
    void Update(){
    	
        if(Input.GetMouseButtonDown(0)){
        	RaycastHit hit = new RaycastHit();
    		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    		if(Physics.Raycast(ray, out hit)){
    			//Debug.Log(hit.collider.gameObject.GetComponentInChildren(typeof(BoxCollider)));
    			//Debug.Log(Input.delta);
    		}
    	}
	}
}
