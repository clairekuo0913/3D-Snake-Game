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
    GameObject cldr_posy = null,cldr_posx = null,cldr_posz = null,cldr_negx=null,cldr_negz=null;
    public static bool SnakeCollisionPara;

    public static void Forbidden(){
        sState = "forbidden";
    }
    public static void Allowed(){
        sState = "allowed";
    }

    void Awake(){
    	// sState = "forbidden";
    	RotateTime = 1.0f;
    	isRotating = false;
    	inCubeWorldObject = GameObject.FindWithTag("inCubeWorldObject");
    	
        GameObject oSnakeHeadCollider = GameObject.FindWithTag("SnakeHeadCollider");
        GameObject oSnakeHead = GameObject.FindWithTag("SnakeHead");
        foreach(Collider cldr in oSnakeHeadCollider.GetComponentsInChildren<Collider>()){
            if(cldr.gameObject.name == "pos_x"){
                cldr_posx = cldr.gameObject;
                // Debug.Log(cldr_posx);
            }else if(cldr.gameObject.name == "pos_y"){
                cldr_posy = cldr.gameObject;
                // Debug.Log(cldr_posy);
            }else if(cldr.gameObject.name == "pos_z"){
                cldr_posz = cldr.gameObject;
                // Debug.Log(cldr_posz);
            }else if(cldr.gameObject.name == "neg_x"){
                cldr_negx = cldr.gameObject;
                // Debug.Log(cldr_negx);
            }else if(cldr.gameObject.name == "neg_z"){
                cldr_negz = cldr.gameObject;
                // Debug.Log(cldr_negz);
            }
            // Debug.Log(cldr);
        }
    }

    public static bool IsRotating(){
        return isRotating;
    }

    bool WillTouchBody(){
        GameObject oSnakeHead = GameObject.FindWithTag("SnakeHead");
        if(oSnakeHead==null)return false;

        Vector3[] v3_snakeHeadPos = new Vector3[5];
        return false;
    }

    //預防轉彎的時候撞到自己的機制

    bool CheckIntersect(Collider other){
        GameObject oSnakeBodyParts = GameObject.FindWithTag("SnakeBodyParts");
        foreach(Collider cldr in oSnakeBodyParts.GetComponentsInChildren<Collider>()){
            if(other.bounds.Intersects(cldr.bounds)){
                Debug.Log(other+"Intersect!!!!!!!!!!");
                return true;
            }
        }
        return false;
    }


    bool CheckSnakeCollision(){
        GameObject oSnakeHeadCollider = GameObject.FindWithTag("SnakeHeadCollider");
        GameObject oSnakeHead = GameObject.FindWithTag("SnakeHead");
        
        oSnakeHeadCollider.transform.position = oSnakeHead.transform.position;
        
        foreach(Collider cldr in oSnakeHeadCollider.GetComponentsInChildren<Collider>()){
            cldr.enabled = false;
        }

        SnakeCollisionPara = false;

        if(v3_rotateDirection.x == 90.0){           // clockwise
            cldr_negz.GetComponent<Collider>().enabled = true;
            if(CheckIntersect(cldr_negz.GetComponent<Collider>())){
                cldr_negz.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
                return true;
            }else{
                cldr_negz.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
            }
        }else if(v3_rotateDirection.x == -90.0){    // counterclockwise
            cldr_posz.GetComponent<Collider>().enabled = true;
            if(CheckIntersect(cldr_posz.GetComponent<Collider>())){
                cldr_posz.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
                return true;
            }else{
                cldr_posz.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
            }
        }else if(v3_rotateDirection.z == 90.0){     // up
            cldr_posx.GetComponent<Collider>().enabled = true;
            if(CheckIntersect(cldr_posx.GetComponent<Collider>())){
                cldr_posx.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
                return true;
            }else{
                cldr_posx.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
            }
        }else if(v3_rotateDirection.z == -90.0){    // down
            cldr_negx.GetComponent<Collider>().enabled = true;
            if(CheckIntersect(cldr_negx.GetComponent<Collider>())){
                cldr_negx.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
                return true;
            }else{
                cldr_negx.GetComponent<Collider>().enabled = false;
                SnakeCollisionPara = false;
            }
        }
        return false;        
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
        if(CheckSnakeCollision()){
            Debug.Log("Check Rotatability == false, CheckSnakeCollision == true");
            StartCoroutine("StartBouncing", v3_rotateDirection);
            return false;
        }

    	return true;
    }

    IEnumerator Bouncing(Vector3 v3_rotateDirection){
        yield return inCubeWorldObject.gameObject.transform.DOLocalRotate(new Vector3(v3_rotateDirection.x/10.0f,v3_rotateDirection.y/10.0f,v3_rotateDirection.z/10.0f), 0.3f,RotateMode.WorldAxisAdd).SetEase(Ease.OutExpo).WaitForCompletion();
        yield return inCubeWorldObject.gameObject.transform.DOLocalRotate(new Vector3(-v3_rotateDirection.x/10.0f,-v3_rotateDirection.y/10.0f,-v3_rotateDirection.z/10.0f), 0.5f,RotateMode.WorldAxisAdd).SetEase(Ease.OutBounce).WaitForCompletion();
    }

    IEnumerator StartBouncing(Vector3 v3_rotateDirection){
        isRotating = true;
        yield return Bouncing(v3_rotateDirection);
        isRotating = false;
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

    void Update(){
        GameObject oSnakeHeadCollider = GameObject.FindWithTag("SnakeHeadCollider");
        GameObject oSnakeHead = GameObject.FindWithTag("SnakeHead");

        oSnakeHeadCollider.transform.position = oSnakeHead.transform.position;
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
