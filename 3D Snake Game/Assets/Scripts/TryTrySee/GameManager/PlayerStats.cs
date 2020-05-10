using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int currentLevel;

    public static int CurrentLevel{
    	get{
    		return currentLevel;
    	}
    	set{
    		currentLevel = value;
    	}
    }
}
