using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Snake : MonoBehaviour{

    public GameObject Head;
    public GameObject Parent;
    public float f_RotateTime = 1.0f;


    bool bool_IsRotate = false;
    Vector3 v3_RotateDirection;

    // Start is called before the first frame update
    void Start(){

        InvokeRepeating("GO",1.0f,1.0f);
        bool_IsRotate = false;
        v3_RotateDirection = new Vector3(0.0f,0.0f,0.0f);
    }

    
    IEnumerator StartCubeRoation(Vector3 v){
        bool_IsRotate = true;
        //print("Start Rotation");
        yield return CubeRotation(v);
        //print("Done Rotation");
        bool_IsRotate = false;
    }

    IEnumerator CubeRotation(Vector3 v){
        Tween t = Parent.transform.DORotate(new Vector3(v.x,v.y,v.z), f_RotateTime,RotateMode.WorldAxisAdd).SetEase(Ease.OutExpo); 
        yield return t.WaitForCompletion();
    }



    void Update(){
        v3_RotateDirection.Set(0.0f,0.0f,0.0f);
        //Tween mytween = Parent.transform.DORotate(new Vector3(90.0f,0.0f,0.0f), f_RotateTime,RotateMode.LocalAxisAdd);
        if(!bool_IsRotate){

            if(Input.GetKeyDown(KeyCode.W)){
                v3_RotateDirection.x = -90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.S)){
                v3_RotateDirection.x = 90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.D)){
                v3_RotateDirection.y = -90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.A)){
                v3_RotateDirection.y = 90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.E)){    
                v3_RotateDirection.z = 90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.Q)){
                v3_RotateDirection.z = -90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection); 
            }

        }


        
    }

    public void GO(){

        Head = Instantiate(Head,new Vector3(Head.transform.position.x,Head.transform.position.y+1,Head.transform.position.z),Quaternion.identity,Parent.transform);
    }
}
