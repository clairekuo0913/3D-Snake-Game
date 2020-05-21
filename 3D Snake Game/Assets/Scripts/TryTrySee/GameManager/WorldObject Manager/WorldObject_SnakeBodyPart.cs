using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_SnakeBodyPart : MonoBehaviour
{

	GameObject gmobj_SnakeHead;
    // GameObject gmobj_Cube;

    void OnTriggerEnter(Collider other){
       
        if(other.tag == "SnakeHeadCollider"){
             Debug.Log(other);
            RotationHandler.SnakeCollisionPara = true;
        }
    }

    bool IsTouchingBody(){

    	if(gmobj_SnakeHead==null)return false;

        Vector3[] v3_snakeHeadPos = new Vector3[5];
        for(int i=0;i<5;i++){
            v3_snakeHeadPos[i] = gmobj_SnakeHead.transform.position;
            v3_snakeHeadPos[i].y += gmobj_SnakeHead.transform.lossyScale.y/2;
        }
        
        v3_snakeHeadPos[1].x += gmobj_SnakeHead.transform.lossyScale.x/2;
        v3_snakeHeadPos[1].z += gmobj_SnakeHead.transform.lossyScale.z/2;
        
        v3_snakeHeadPos[2].x += gmobj_SnakeHead.transform.lossyScale.x/2;
        v3_snakeHeadPos[2].z -= gmobj_SnakeHead.transform.lossyScale.z/2;
        
        v3_snakeHeadPos[3].x -= gmobj_SnakeHead.transform.lossyScale.x/2;
        v3_snakeHeadPos[3].z += gmobj_SnakeHead.transform.lossyScale.z/2;
        
        v3_snakeHeadPos[4].x -= gmobj_SnakeHead.transform.lossyScale.x/2;
        v3_snakeHeadPos[4].z -= gmobj_SnakeHead.transform.lossyScale.z/2;
       

        Bounds bnd_snakeHeadBounds = gmobj_SnakeHead.GetComponent<Collider>().bounds;
        for(int i=0;i<4;i++){
            // Debug.DrawLine(v3_snakeHeadPos[i],v3_snakeHeadPos[i+1]);
            if(this.GetComponent<Collider>().bounds.Contains(v3_snakeHeadPos[i])){
                return true;
            }

        }
        return false;   
    }
    // Start is called before the first frame update
    void Start()
    {
        gmobj_SnakeHead = GameObject.FindWithTag("SnakeHead");
        // gmobj_Cube = GameObject.FindWithTag("Cube");
    }


    // Update is called once per frame
    void Update()
    {
        if(!RotationHandler.IsRotating()){
        	if(IsTouchingBody()){
                SnakeCollisionHandler.Allowed();
                SnakeCollisionHandler.Handle(this.gameObject);
                SnakeCollisionHandler.Forbidden();
            }
        }
    }
}
