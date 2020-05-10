using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{


	static string sLevelState; // start -> wait -> play -> dead or win
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelState("start");
    }

    void LevelInitialize(){
        if(PlayerStats.CurrentLevel==0){
            LevelInfo.Level_test();
        }
        // Snake
        WorldObject_Snake.Initialize();
        // wait for Snake Complete
            /* TODO? */
        // Object Initialize
        WorldObjectManager.Initialize();
        // UI Initialize
      		/* TODO */
      	// Input Forbidden  
        InputManager.Forbidden();

        // Switch To Next State
        UpdateLevelState("wait");

    }

    void LevelWait(){
    	InputManager.Allowed();
    	if(false){// if GetRotate Response:
    		UpdateLevelState("play");
    	}
    }

	void LevelPlay(){
		while(/*WIN?*/false){
			
		}
	}

    void UpdateLevelState(string levelState){
    	if(levelState == "start"){
    		sLevelState = "start";
            LevelInitialize();
    	}else if(levelState == "wait"){
    		sLevelState = "wait";
    		LevelWait();
        }else if(levelState == "play"){
        	/* TODO */
        }else if(levelState == "die"){
        	/* TODO */
        }else if(levelState == "win"){
        	/* TODO */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //sLevelState = "wait";
    }
}
