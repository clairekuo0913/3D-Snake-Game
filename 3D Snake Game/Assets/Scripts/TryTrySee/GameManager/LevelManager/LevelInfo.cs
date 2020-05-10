using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelInfo {
	private static Vector3 v3_cubePos,v3_snakePos,v3_endpointPos;
	private static Vector3 v3_cubeScale;
	private static int obstacleCount;
	private static float f_snakeSpeed, f_snakeLength;
	private static Vector3[] v3_obstaclesPos;
	private static string levelText;
	public static void Level_test(){
		// Snake Parameter
		f_snakeSpeed = 0.3f;
		f_snakeLength = 7f;

		// InCube World objects Position
		v3_cubePos.Set(0,0,0);
		v3_cubeScale.Set(7,7,7);
		v3_snakePos.Set(2,-1,1);
		v3_endpointPos.Set(1,2,-1);
		
		// obstacle setting
		obstacleCount = 1;
		v3_obstaclesPos = new Vector3[obstacleCount];
		v3_obstaclesPos[0].Set(0,0,0);

		// Text
		levelText = "This is the testing level >///<";
	}

	public static Vector3 v3_CubePos{
		get{return v3_cubePos;}
	}
	public static Vector3 v3_SnakePos{
		get{return v3_snakePos;}
	}
	public static Vector3 v3_EndpointPos{
		get{return v3_endpointPos;}
	}
	public static Vector3 v3_CubeScale{
		get{return v3_cubeScale;}
	}
	public static int ObstacleCount{
		get{return obstacleCount;}
	}
	public static Vector3[] v3_ObstaclesPos{
		get{return v3_obstaclesPos;}
	}
	public static float f_SnakeSpeed{
		get{return f_snakeSpeed;}
	}
	public static float f_SnakeLength{
		get{return f_snakeLength;}
	}

	public static string LevelText{
		get{return levelText;}
	}
	

}
