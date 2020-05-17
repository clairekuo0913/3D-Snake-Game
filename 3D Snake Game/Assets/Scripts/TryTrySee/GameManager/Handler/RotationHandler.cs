using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotationHandler : MonoBehaviour
{
	//rotate state:  外部call Rotate() -> CheckRotatability() -> StartRotate -> Rotating -> EndRotate;
	
    public float RotateTime;
	static bool isRotating;
    Vector3 v3_rotateDirection;
    static string sState;
    GameObject inCubeWorldObject;

    public static void Forbidden(){
        sState = "forbidden";
    }
    public static void Allowed(){
        sState = "allowed";
    }

    void Start(){
    	// sState = "forbidden";
    	RotateTime = 1.0f;
    	isRotating = false;
    	inCubeWorldObject = GameObject.FindWithTag("inCubeWorldObject");
    	
    }

    public static bool IsRotating(){
        return isRotating;
    }

    bool CheckRotatability(){
    	// 1. Forbidden  (into the obstacle -> Forbidden)
    	if(sState == "forbidden"){
            Debug.Log("Check Rotatability == false, RotationHandler.State == false");
            return false;
        }
    	// 2. isRotating
    	if(IsRotating() == true){
            // Debug.Log("Check Rotatability == false, isRotating == true");
            return false;
        }
    	// 3. inCubeWorldObject notfound
    	if(inCubeWorldObject == null){
            Debug.Log("Check Rotatability == false, inCubeWorldObject == null");
            return false;
        }
    	// 4. CheckSnakeCollision

    	return true;
    }



    IEnumerator Rotating(Vector3 v3_rotateDirection){
        // ease function: Ease.OutExpo
        // rotate time: f_RotateTime
        yield return inCubeWorldObject.gameObject.transform.DOLocalRotate(new Vector3(v3_rotateDirection.x,v3_rotateDirection.y,v3_rotateDirection.z), RotateTime,RotateMode.WorldAxisAdd).SetEase(Ease.OutExpo).WaitForCompletion();
    }

    IEnumerator StartRotation(Vector3 v3_rotateDirection){
        isRotating = true;
        yield return Rotating(v3_rotateDirection);
        isRotating = false;
    }

    public void Rotate(string str_rotateDirection){

    	if(str_rotateDirection == "up"){
            v3_rotateDirection.Set(0.0f,0.0f,90.0f);
        }else if(str_rotateDirection == "down"){
            v3_rotateDirection.Set(0.0f,0.0f,-90.0f);
        }else if(str_rotateDirection == "right"){
            v3_rotateDirection.Set(0.0f,-90.0f,0.0f);
        }else if(str_rotateDirection == "left"){
            v3_rotateDirection.Set(0.0f,90.0f,0.0f);
        }else if(str_rotateDirection == "clockwise"){
            v3_rotateDirection.Set(90.0f,0.0f,0.0f);
        }else if(str_rotateDirection == "counterClockwise"){
            v3_rotateDirection.Set(-90.0f,0.0f,0.0f);
        }

        if(CheckRotatability() == false) return;
        StartCoroutine("StartRotation" , v3_rotateDirection);
    }
}
