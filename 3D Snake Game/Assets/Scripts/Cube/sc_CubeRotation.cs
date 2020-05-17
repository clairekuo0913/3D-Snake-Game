using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sc_CubeRotation : MonoBehaviour{


    public float f_RotateTime;
    GameObject gmobj_Snake;
    GameObject gmobj_SnakeBodyParts;
    GameObject gmobj_EndPoint;
    bool bool_IsRotate;
    public bool bool_DontRotate;
    public bool bool_AboutToRotate;


    void Start(){
        bool_IsRotate = false;
        gmobj_Snake =  GameObject.FindWithTag("Snake"); 
        gmobj_SnakeBodyParts = GameObject.FindWithTag("SnakeBodyParts");
        gmobj_EndPoint = GameObject.FindWithTag("EndPoint");
    }

    IEnumerator StartCubeRoation(Vector3 v3_rotateDirection){
        
        bool_IsRotate = true;
        gmobj_Snake.transform.parent = this.gameObject.transform;
        gmobj_SnakeBodyParts.transform.parent = this.gameObject.transform;
        gmobj_EndPoint.transform.parent = this.gameObject.transform;
        
        yield return CubeRotation(v3_rotateDirection);
        
        gmobj_Snake.transform.parent = null;
        gmobj_SnakeBodyParts.transform.parent=null;
        gmobj_EndPoint.transform.parent = null;
        bool_IsRotate = false;
    }

    IEnumerator CubeRotation(Vector3 v3_rotateDirection){
        // ease function: Ease.OutExpo
        // rotate time: f_RotateTime
        yield return this.gameObject.transform.DOLocalRotate(new Vector3(v3_rotateDirection.x,v3_rotateDirection.y,v3_rotateDirection.z), f_RotateTime,RotateMode.WorldAxisAdd).SetEase(Ease.OutExpo).WaitForCompletion();
    }

    public bool IsRotating(){
        return bool_IsRotate;
    }

    public void Rotate(string str_rotateDirection){
        Vector3 v3_rotateDirection = new Vector3(0.0f,0.0f,0.0f);
        bool_AboutToRotate = true;
        if(bool_DontRotate == true){
            bool_AboutToRotate = false;
            return;
        } 

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
        
        if(!bool_IsRotate){
            StartCoroutine("StartCubeRoation" , v3_rotateDirection);
        }
        bool_AboutToRotate = false;
    }

   

    void Update(){
        
    }


}
