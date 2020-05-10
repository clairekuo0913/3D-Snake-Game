using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_Snake : MonoBehaviour
{
	public static float f_SnakeSpeed, f_SnakeLength;
    public static void Initialize(){
    	GameObject oSnake = GameObject.FindWithTag("Snake");
    	if(oSnake!=null){
    		// snake parameter init:
    		// 	- length
    		f_SnakeLength = LevelInfo.f_SnakeLength;
    		//	- speed
    		f_SnakeSpeed = LevelInfo.f_SnakeSpeed;
    		// 	- position
    		oSnake.transform.position = LevelInfo.v3_SnakePos;
    		// snake init SFX: SFX_Manager.SnakeInit?
    			/* TODO */
    		// snake init animation
    			/* TODO */
    		

    	}else{
    		Debug.Log("Snake Not Found!\n");
    	}
    	// Cube Initialize Animation
    	
	}
    
}
