﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectManager : MonoBehaviour
{
    public static void Initialize(){
    	// WorldObject init SFX: SFX_Manager.WorldObjectInit?
    	WorldObject_Cube.Initialize();
    	WorldObject_Endpoint.Initialize(); 
    	WorldObject_Obstacle.Initialize();   	
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