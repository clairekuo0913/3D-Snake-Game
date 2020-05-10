using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_Obstacle : MonoBehaviour
{
	public static void Initialize(){
    	GameObject oObstacles = GameObject.FindWithTag("Obstacles");
    	if(oObstacles!=null){
    		// Obstacles init:
    		// Instantiate LevelInfo.obstacleCount object, Initialize their position
    			/* TODO */
    		
    		// obstacle init animation
    			/* TODO */
    	}else{
    		Debug.Log("Obstacles Not Found!\n");
    	}
	}
    
}
