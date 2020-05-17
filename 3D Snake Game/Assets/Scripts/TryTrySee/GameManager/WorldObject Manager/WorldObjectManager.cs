using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectManager : MonoBehaviour
{
    static GameObject o_Snake,o_Obstacles;

    public static void Initialize(){
        o_Snake = GameObject.FindWithTag("Snake");
        o_Obstacles = GameObject.FindWithTag("Obstacles");
    	// WorldObject init SFX: SFX_Manager.WorldObjectInit?
    	WorldObject_Cube.Initialize();
    	WorldObject_Endpoint.Initialize(); 
        if(o_Obstacles!=null){
            o_Obstacles.GetComponent<WorldObject_Obstacles>().Initialize();
        }
    	
    }

    public static void UpdateState(string state){
        if(state == "play"){
            if(o_Snake!=null){
                o_Snake.GetComponent<WorldObject_Snake>().UpdateState("grow");
            }else{
                Debug.Log("gameobject Snake is not found!\n");
            }
            // WorldObject_Obstacle.UpdateAllState("wait");
            // WorldObject_Cube.UpdateState("wait");
            // WorldObject_Endpoint.UpdateState("wait");
        }
    }



}
