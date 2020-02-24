using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sc_CubeRotation : MonoBehaviour{


    public GameObject Cube;
    public float f_RotateTime;

    public bool bool_IsRotate = false;
    Vector3 v3_RotateDirection;

    void Start(){

        bool_IsRotate = false;
        v3_RotateDirection = new Vector3(0.0f,0.0f,0.0f);
    }

    
    IEnumerator StartCubeRoation(Vector3 v){
        
        bool_IsRotate = true;
        yield return CubeRotation(v);
        bool_IsRotate = false;
        //Vector3 vcube = this.gameObject.transform.eulerAngles;
        //vcube.x = Mathf.Floor(vcube.x);
        //vcube.y = Mathf.Floor(vcube.y);
        //vcube.z = Mathf.Floor(vcube.z);

        //this.gameObject.transform.eulerAngles.x = Mathf.Floor(this.gameObject.transform.eulerAngles.x);
        //this.gameObject.transform.eulerAngles.y = Mathf.Floor(this.gameObject.transform.eulerAngles.y);
        //this.gameObject.transform.eulerAngles.z = Mathf.Floor(this.gameObject.transform.eulerAngles.z);

        //this.gameObject.transform.eulerAngles = vcube;

    }

    IEnumerator CubeRotation(Vector3 v){
        Tween t = this.gameObject.transform.DOLocalRotate(new Vector3(v.x,v.y,v.z), f_RotateTime,RotateMode.WorldAxisAdd).SetEase(Ease.OutExpo);
        //this.gameObject.transform.Rotate(new Vector3(v.x,v.y,v.z),Space.Self);
        //yield return new WaitForSeconds(0.5f);
        yield return t.WaitForCompletion();
    }

    public void Rotate(string str_Direction){
        Vector3 v = new Vector3(0.0f,0.0f,0.0f);

        if(str_Direction == "up"){
            v.Set(0.0f,0.0f,90.0f);
        }else if(str_Direction == "down"){
            v.Set(0.0f,0.0f,-90.0f);
        }else if(str_Direction == "right"){
            v.Set(0.0f,-90.0f,0.0f);
        }else if(str_Direction == "left"){
            v.Set(0.0f,90.0f,0.0f);
        }else if(str_Direction == "clockwise"){
            v.Set(90.0f,0.0f,0.0f);
        }else if(str_Direction == "counterClockwise"){
            v.Set(-90.0f,0.0f,0.0f);
        }

        if(!bool_IsRotate){
            v3_RotateDirection = v;
            StartCoroutine("StartCubeRoation" , v3_RotateDirection);
        }
    }

    void Update(){
        v3_RotateDirection.Set(0.0f,0.0f,0.0f);
        
        if(!bool_IsRotate){
            Debug.Log(this.gameObject.transform.localEulerAngles.ToString("F8"));
            if(Input.GetKeyDown(KeyCode.W)){
                v3_RotateDirection.z = 90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.S)){
                v3_RotateDirection.z = -90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.D)){
                v3_RotateDirection.y = -90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.A)){
                v3_RotateDirection.y = 90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.E)){    
                v3_RotateDirection.x = 90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection);
            }else if(Input.GetKeyDown(KeyCode.Q)){
                v3_RotateDirection.x = -90.0f;
                StartCoroutine("StartCubeRoation" , v3_RotateDirection); 
            }

        }


        
    }


}
