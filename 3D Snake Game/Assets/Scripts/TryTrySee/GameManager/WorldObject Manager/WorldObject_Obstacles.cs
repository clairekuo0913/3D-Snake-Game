using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_Obstacles : MonoBehaviour
{
    

    GameObject o_Obstacles;
    // List<GameObject> ol_Obstacles = new List<GameObject>();
    public GameObject o_Obstacle;

	public void Initialize(){
        o_Obstacles = GameObject.FindWithTag("Obstacles");
        foreach(Transform child in o_Obstacles.transform){
            // ol_Obstacles.Add(child.gameObject);
            // Debug.Log(child.gameObject);
            child.gameObject.GetComponent<WorldObject_Obstacle>().Initialize();
        }
	}


    
    
}