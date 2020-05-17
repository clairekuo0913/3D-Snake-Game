using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_SnakeHead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
    	SnakeCollisionHandler.Allowed();
    	// Debug.Log(other.gameObject.tag);
    	if(other.gameObject.tag!="SnakeBodyPart" && other.gameObject.tag!= "InputSurface"){
			SnakeCollisionHandler.Handle(other.gameObject);
    	}
    	SnakeCollisionHandler.Forbidden();    	
    }

}
