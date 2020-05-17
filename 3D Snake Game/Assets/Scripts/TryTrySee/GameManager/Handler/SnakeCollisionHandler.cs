using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollisionHandler : MonoBehaviour
{
	static string sState;
	GameObject oSnakeHead;
	public static GameObject oCollisionObject;
	public static  void Forbidden(){
        sState = "forbidden";
    }

    public static void Allowed(){
        sState = "allowed";
    }

    public static GameObject CollisionObject(){
    	return oCollisionObject;
    }

    public static void Handle(GameObject collisionObject){
    	if(sState == "allowed"){
    		oCollisionObject = collisionObject;
    	}else if(sState== "forbidden"){
    		oCollisionObject = null;
    	}
    }

    void Start(){
    	// oSnakeHead = GameObject.FindWithTag("SnakeHead");
    }

    void Update(){
    }


}
