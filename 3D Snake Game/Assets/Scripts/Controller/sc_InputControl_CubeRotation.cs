using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_InputControl_CubeRotation : MonoBehaviour
{

    GameObject Cube;

    Vector2 first_press_pos;
    void MouseDragCube(Event e){
        
        Vector3 xAxis = new Vector3(-1.0f,0.0f,0.0f);   //xv=zv
        Vector3 yAxis = new Vector3(0.0f,1.0f,0.0f);    //xh=yh
        Vector3 zAxis = new Vector3(0.0f,0.0f,1.0f);    //yv=zh
        

        Vector2 scrn_xAxis,scrn_yAxis,scrn_zAxis;

        scrn_xAxis = Camera.main.WorldToScreenPoint(xAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        scrn_yAxis = Camera.main.WorldToScreenPoint(yAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        scrn_zAxis = Camera.main.WorldToScreenPoint(zAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);

        //raycast for the first press
        if(Input.GetMouseButtonDown(0)){
            first_press_pos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(first_press_pos);

        //if hit Cube, then detect surface and swipe direction
        if(Physics.Raycast(ray, out hit)){
            
            BoxCollider CubeSurface = hit.collider.gameObject.GetComponentInChildren<BoxCollider>();
            Vector2 dv,dh;
            if(e.delta.magnitude > 10.0f){
                if(CubeSurface.gameObject.name == "pos_x"){
                    dv = Vector2.Dot(e.delta,scrn_yAxis.normalized) * scrn_yAxis.normalized;
                    dh = Vector2.Dot(e.delta,scrn_zAxis.normalized) * scrn_zAxis.normalized;

                    if(dv.magnitude > dh.magnitude){
                        if(dv.normalized == scrn_yAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("down");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("up");
                        }
                    }else if(dv.magnitude < dh.magnitude){
                        if(dh.normalized == scrn_zAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("right");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("left");
                        }
                    }
                }else if(CubeSurface.gameObject.name == "pos_y"){
                    dv = Vector2.Dot(e.delta,scrn_xAxis.normalized) * scrn_xAxis.normalized;
                    dh = Vector2.Dot(e.delta,scrn_zAxis.normalized) * scrn_zAxis.normalized;

                    if(dv.magnitude > dh.magnitude){
                        if(dv.normalized == scrn_xAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("clockwise");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("counterClockwise");
                        }
                    }else if(dv.magnitude < dh.magnitude){
                        if(dh.normalized == scrn_zAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("up");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("down");
                        }
                    }

                }else if(CubeSurface.gameObject.name == "pos_z"){
                    dv = Vector2.Dot(e.delta,scrn_yAxis.normalized) * scrn_yAxis.normalized;
                    dh = Vector2.Dot(e.delta,scrn_xAxis.normalized) * scrn_xAxis.normalized;

                    if(dv.magnitude > dh.magnitude){
                        if(dv.normalized == scrn_yAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("clockwise");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("counterClockwise");
                        }
                    }else if(dv.magnitude < dh.magnitude){
                        if(dh.normalized == scrn_xAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("right");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("left");
                        }
                    }
                }
            }
        }
    }

    void TouchDragCube(){
        
        Vector3 xAxis = new Vector3(-1.0f,0.0f,0.0f);   //xv=zv
        Vector3 yAxis = new Vector3(0.0f,1.0f,0.0f);    //xh=yh
        Vector3 zAxis = new Vector3(0.0f,0.0f,1.0f);    //yv=zh
        

        Vector2 scrn_xAxis,scrn_yAxis,scrn_zAxis;

        scrn_xAxis = Camera.main.WorldToScreenPoint(xAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        scrn_yAxis = Camera.main.WorldToScreenPoint(yAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        scrn_zAxis = Camera.main.WorldToScreenPoint(zAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);

        //raycast for the first press
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began){
            first_press_pos = new Vector2(touch.position.x,touch.position.y);
        }
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(first_press_pos);

        // if hitting Cube, detect surface and swipe direction
        if(Physics.Raycast(ray, out hit)){
            
            BoxCollider CubeSurface = hit.collider.gameObject.GetComponentInChildren<BoxCollider>();
            Vector2 dv,dh;


            if(touch.deltaPosition.magnitude > 10.0f){
                if(CubeSurface.gameObject.name == "pos_x"){
                    dv = Vector2.Dot(touch.deltaPosition,scrn_yAxis.normalized) * scrn_yAxis.normalized;
                    dh = Vector2.Dot(touch.deltaPosition,scrn_zAxis.normalized) * scrn_zAxis.normalized;

                    if(dv.magnitude > dh.magnitude){
                        if(dv.normalized == scrn_yAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("down");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("up");
                        }
                    }else if(dv.magnitude < dh.magnitude){
                        if(dh.normalized == scrn_zAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("right");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("left");
                        }
                    }
                }else if(CubeSurface.gameObject.name == "pos_y"){
                    dv = Vector2.Dot(touch.deltaPosition,scrn_xAxis.normalized) * scrn_xAxis.normalized;
                    dh = Vector2.Dot(touch.deltaPosition,scrn_zAxis.normalized) * scrn_zAxis.normalized;

                    if(dv.magnitude > dh.magnitude){
                        if(dv.normalized == scrn_xAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("clockwise");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("counterClockwise");
                        }
                    }else if(dv.magnitude < dh.magnitude){
                        if(dh.normalized == scrn_zAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("up");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("down");
                        }
                    }

                }else if(CubeSurface.gameObject.name == "pos_z"){
                    dv = Vector2.Dot(touch.deltaPosition,scrn_yAxis.normalized) * scrn_yAxis.normalized;
                    dh = Vector2.Dot(touch.deltaPosition,scrn_xAxis.normalized) * scrn_xAxis.normalized;

                    if(dv.magnitude > dh.magnitude){
                        if(dv.normalized == scrn_yAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("clockwise");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("counterClockwise");
                        }
                    }else if(dv.magnitude < dh.magnitude){
                        if(dh.normalized == scrn_xAxis.normalized){
                            Cube.GetComponent<sc_CubeRotation>().Rotate("right");
                        }else{
                            Cube.GetComponent<sc_CubeRotation>().Rotate("left");
                        }
                    }
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start(){
        Cube =  GameObject.Find("Cube");
    }

    void OnGUI(){
        Event e = Event.current;
        if(e.isMouse){
            MouseDragCube(e);
        }
        if(Input.touchCount==1){
            TouchDragCube();
        }
    }

    

    // Update is called once per frame
    void Update(){
        
    }

    
}


