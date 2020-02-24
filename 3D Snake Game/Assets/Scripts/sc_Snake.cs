using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Snake : MonoBehaviour
{
    public int MaxOfBodyParts;
    int NumOfBodyParts = 1;
    public float SnakeSpeed;
    public Vector3 SnakeStartPosition;
    public GameObject SnakeHead;
    public GameObject SnakeBodyPart;
    GameObject Cube;

    float SnakeLength;
    void GrowBodyParts(){
        if(NumOfBodyParts <= MaxOfBodyParts){

        }
    }

    void MoveBodyParts(){

    }
    //float deltaMove = 0;
    float timecounter = 0;
    Vector3 firstPos;
    bool finish_turn = false;
    void MoveSnakeHead(){
        if(!Cube.GetComponent<sc_CubeRotation>().bool_IsRotate){
            if(finish_turn){
                Instantiate(SnakeBodyPart,new Vector3(SnakeHead.transform.position.x,SnakeHead.transform.position.y,SnakeHead.transform.position.z),Quaternion.identity,Cube.transform);
                firstPos = SnakeHead.transform.position;
            }
            SnakeHead.transform.position += SnakeSpeed*Vector3.up;
            
            if(Vector3.Distance(SnakeHead.transform.position,firstPos)>=SnakeLength-0.01){
                Instantiate(SnakeBodyPart,new Vector3(SnakeHead.transform.position.x,SnakeHead.transform.position.y,SnakeHead.transform.position.z),Quaternion.identity,Cube.transform);
                firstPos = SnakeHead.transform.position;
            } 
        }else{
            finish_turn = true;
            //firstPos = SnakeHead.transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cube =  GameObject.Find("Cube");
        SnakeLength = SnakeHead.transform.lossyScale.x;
        firstPos = SnakeHead.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnakeHead();
        timecounter+=Time.deltaTime;
    }

    
}
