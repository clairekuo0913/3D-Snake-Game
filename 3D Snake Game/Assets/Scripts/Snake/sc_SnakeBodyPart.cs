/*--------------------------------------*/
/* Purpose
/* 判斷是否撞到自己
/*
/*--------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_SnakeBodyPart : MonoBehaviour
{
    
	GameObject gmobj_SnakeHead;
    GameObject gmobj_Cube;
    
    bool IsTouchingBody(){
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
        for(int i=0;i<5;i++){
            Debug.DrawLine(v3_snakeHeadPos[i],Vector3.zero);
            if(this.GetComponent<Collider>().bounds.Contains(v3_snakeHeadPos[i])){
                return true;
            }

        }
        return false;   
    }

    // Start is called before the first frame update
    void Start()
    {
        gmobj_SnakeHead = GameObject.FindWithTag("Snake");
        gmobj_Cube = GameObject.FindWithTag("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        // 碰到自己的時候死掉！
        if(!gmobj_Cube.GetComponent<sc_CubeRotation>().IsRotating()){
            if(IsTouchingBody()){
                Debug.Log("You touch yourself hahahaha");
                Scene currScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(currScene.buildIndex);
            }
        }


        
    }
}
