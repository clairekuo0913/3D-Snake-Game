using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    GameObject Cube;
    Vector2 first_press_pos;
    string sfirst_press_pos;
    static string sState;

    public static  void Forbidden(){
        sState = "forbidden";
    }
    public static void Allowed(){
        sState = "allowed";
    }

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

    string CheckPosition(string input){ //pos_x, pos_y, pos_z, icon, null, 
        Vector2 v2_position;
        if(input == "mouse"){
            if(Input.GetMouseButtonDown(0)){
                v2_position = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
                RaycastHit hit = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(v2_position);
                if(Physics.Raycast(ray, out hit)){
                    BoxCollider CubeSurface = hit.collider.gameObject.GetComponentInChildren<BoxCollider>();
                    if(CubeSurface!=null && CubeSurface.gameObject.tag=="InputSurface"){
                        return CubeSurface.gameObject.name;
                    }
                }else{
                    return "nothing";
                }
            }
        }else if(input == "touch"){
        }
        return "null";
    }

    string CheckPosture(string input){
        if(input == "mouse"){
            Event e = Event.current;
            if(e.delta.magnitude >= 10.0f){
                return "swipe";
            }   
        }
        return "nothing";
    }

    string CheckSwipeDirection(string input, string surface){
        Vector3 xAxis = new Vector3(-1.0f,0.0f,0.0f);   //xv=zv
        Vector3 yAxis = new Vector3(0.0f,1.0f,0.0f);    //xh=yh
        Vector3 zAxis = new Vector3(0.0f,0.0f,1.0f);    //yv=zh
        Vector2 scrn_xAxis,scrn_yAxis,scrn_zAxis;
        scrn_xAxis = Camera.main.WorldToScreenPoint(xAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        scrn_yAxis = Camera.main.WorldToScreenPoint(yAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        scrn_zAxis = Camera.main.WorldToScreenPoint(zAxis)-Camera.main.WorldToScreenPoint(Vector3.zero);
        Vector2 dv,dh;
        if(input == "mouse"){
            Event e = Event.current;
            if(surface == "pos_x"){
                dv = Vector2.Dot(e.delta,scrn_yAxis.normalized) * scrn_yAxis.normalized;
                dh = Vector2.Dot(e.delta,scrn_zAxis.normalized) * scrn_zAxis.normalized;
                if(dv.magnitude > dh.magnitude){
                    if(dv.normalized == scrn_yAxis.normalized){
                        return "down";
                    }else{
                        return "up";
                    }
                }else if(dv.magnitude < dh.magnitude){
                    if(dh.normalized == scrn_zAxis.normalized){
                        return "right";
                    }else{
                        return "left";
                    }
                }
            }else if(surface == "pos_y"){
                dv = Vector2.Dot(e.delta,scrn_xAxis.normalized) * scrn_xAxis.normalized;
                dh = Vector2.Dot(e.delta,scrn_zAxis.normalized) * scrn_zAxis.normalized;

                if(dv.magnitude > dh.magnitude){
                    if(dv.normalized == scrn_xAxis.normalized){
                        return "clockwise";
                    }else{
                        return "counterClockwise";
                    }
                }else if(dv.magnitude < dh.magnitude){
                    if(dh.normalized == scrn_zAxis.normalized){
                        return "up";
                    }else{
                        return "down";
                    }
                }
            }else if(surface == "pos_z"){
                dv = Vector2.Dot(e.delta,scrn_yAxis.normalized) * scrn_yAxis.normalized;
                dh = Vector2.Dot(e.delta,scrn_xAxis.normalized) * scrn_xAxis.normalized;

                if(dv.magnitude > dh.magnitude){
                    if(dv.normalized == scrn_yAxis.normalized){
                        return "clockwise";
                    }else{
                        return "counterClockwise";
                    }
                }else if(dv.magnitude < dh.magnitude){
                    if(dh.normalized == scrn_xAxis.normalized){
                        return "right";
                    }else{
                        return "left";
                    }
                }
            }
        
        }
        return "null";
    }

    void OnGUI(){
        Event e = Event.current;

        if(sState == "allowed"){
            if(e.isMouse){
                string inputMethod = "mouse";
                if(CheckPosition(inputMethod) != "null"){
                    sfirst_press_pos = CheckPosition(inputMethod);
                }
                //Debug.Log("Mouse on "+CheckPosition(inputMethod)+" and posture is "+CheckPosture(inputMethod)+".\n");
                if(CheckPosture(inputMethod) == "swipe" && sfirst_press_pos!="nothing"){
                    // Debug.Log("Rotate Direction: "+ CheckSwipeDirection(inputMethod,sfirst_press_pos)+".\n");
                    GameObject RotationHandler = GameObject.FindWithTag("RotationHandler");
                    if(RotationHandler!=null){
                        RotationHandler.GetComponent<RotationHandler>().Rotate(CheckSwipeDirection(inputMethod,sfirst_press_pos));
                    }else{
                        Debug.Log("error: RotationHandler not found!\n");
                    }
                }
                
            }
            if(Input.touchCount==1){
                // Debug.Log("Touch !!\n");
                /* TODO */
                //TouchDragCube();
            } 
        }else{
            if(e.isMouse){
                Debug.Log("Not allowed to Drag mouse!\n");
            }
            if(Input.touchCount==1){
                Debug.Log("Not allowed to touch!\n");
            }
        }
        
    }
    void Start(){
        Cube = GameObject.FindWithTag("Cube");
    }

}
