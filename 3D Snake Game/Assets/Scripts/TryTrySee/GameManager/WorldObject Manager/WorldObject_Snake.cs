using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject_Snake : MonoBehaviour
{
	public float f_SnakeSpeed, f_SnakeLength;
    static string sState, lastState;
    public static Vector3 v3_ObstaclePos;
    GameObject o_SnakeBodyParts;
    public GameObject o_SnakeBodyPart;
    GameObject o_SnakeHead;
    GameObject o_Snake;

    // int moveCalltimes = 0;
    // GameObject RotationHandler;
    int  i_maxOfInstant;

    public Queue<GameObject> oq_Snakes = new Queue<GameObject>();

    public static string CurrentState(){
        return sState;
    }

    public void Initialize(){
    	if(o_Snake!=null){
            // oq_Snakes.Clear();
            UpdateState("init");
    		// snake parameter init:
    		// 	- length
    		// f_SnakeLength = LevelInfo.f_SnakeLength;
    		//	- speed
    		// f_SnakeSpeed = LevelInfo.f_SnakeSpeed;
    		// 	- position
    		// o_SnakeHead.transform.position = LevelInfo.v3_SnakePos;
    		// snake init SFX: SFX_Manager.SnakeInit?
                /* TODO */
    		// snake init animation
    			/* TODO */
    	}else{
    		Debug.Log("error: Snake not found!\n");
    	}
    	// Snake Initialize Animation
	}

    IEnumerator SnakeGrow(){

        i_maxOfInstant = Mathf.RoundToInt(f_SnakeLength / f_SnakeSpeed); 
        
        // The min size of Snake is 1 unit
        if(f_SnakeLength < 1){
            Debug.Log("SnakeLenght < 1!\n");
            yield return null;
        }

        if(o_SnakeBodyParts == null ||o_SnakeBodyPart == null){
            Debug.Log("Something is missing: SnakeBodyPart or RotationHandler");
            yield break;
        }
        // Snake's Growth
        while(oq_Snakes.Count<i_maxOfInstant && sState == "grow"){
            if(!RotationHandler.IsRotating() && Time.timeScale!=0){
                oq_Snakes.Enqueue(Instantiate(o_SnakeBodyPart, new Vector3(o_SnakeHead.transform.position.x, o_SnakeHead.transform.position.y, o_SnakeHead.transform.position.z) ,Quaternion.identity,o_SnakeBodyParts.transform));
                o_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
            }
            yield return null;
        }
        if(oq_Snakes.Count >= i_maxOfInstant){
            UpdateState("move");
        }
        
    }

    IEnumerator SnakeMove(){
        // int currCall = moveCalltimes++;
        while( sState == "move"){
            if(o_SnakeBodyParts == null || o_SnakeBodyPart == null){
                Debug.Log("Something is missing: SnakeBodyPart or RotationHandler");
                yield break;
            }
            if(!RotationHandler.IsRotating() && Time.timeScale!=0){
                oq_Snakes.Enqueue(Instantiate(o_SnakeBodyPart, new Vector3(o_SnakeHead.transform.position.x, o_SnakeHead.transform.position.y, o_SnakeHead.transform.position.z) ,Quaternion.identity,o_SnakeBodyParts.transform));
                o_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
                Destroy(oq_Snakes.Dequeue());
            }
            yield return null;  
        }
        // currCall = 0;
    }

    IEnumerator SnakePause(){
        while(sState == "pause"){
            yield return null;
        }
    }

    IEnumerator SnakeDecrease(){
        RotationHandler.Forbidden();
        // float tmp = 0.0f;
        while(sState == "decrease" && oq_Snakes.Count != 0){
            RotationHandler.Forbidden();
            if(o_SnakeBodyParts == null || o_SnakeBodyPart == null){
                Debug.Log("Something is missing: SnakeBodyPart or RotationHandler");
                yield break;
            }

            if(!RotationHandler.IsRotating() && Time.timeScale!=0){
                // while(tmp<0.1f){
                //     tmp += f_SnakeSpeed;
                //     oq_Snakes.Enqueue(Instantiate(o_SnakeBodyPart, new Vector3(o_SnakeHead.transform.position.x, o_SnakeHead.transform.position.y, o_SnakeHead.transform.position.z) ,Quaternion.identity,o_SnakeBodyParts.transform));
                //     o_SnakeHead.transform.position += f_SnakeSpeed * Vector3.up;
                //     Destroy(oq_Snakes.Dequeue());
                //     yield return null;
                // }
                Destroy(oq_Snakes.Dequeue());
            }
            yield return null;  
        }
        o_SnakeHead.transform.position = v3_ObstaclePos;
        UpdateState("wait");
    }

    IEnumerator SnakeWait(){
        while(sState == "wait"){
            RotationHandler.Allowed();
            if(RotationHandler.IsRotating()){
                UpdateState("grow");
                yield break;
            }
            yield return null;
        }
    }

    public void UpdateState(string state){
        if(sState!="pause" && sState != "resume"){
            lastState = sState;
        }
        sState = state;
        Debug.Log("Snake State: "+sState);
        if(state == "grow"){
            StartCoroutine("SnakeGrow");
        }else if(state == "move"){
            StartCoroutine("SnakeMove");
        }else if(state == "pause"){
            StartCoroutine("SnakePause");
        }else if(state == "resume"){
            sState = lastState;
        }else if(state == "decrease"){
            StartCoroutine("SnakeDecrease");
        }else if(state == "wait"){
            StartCoroutine("SnakeWait");
        }
    }

    void Start(){
        // RotationHandler = GameObject.FindWithTag("RotationHandler");
        o_Snake = GameObject.FindWithTag("Snake");
        o_SnakeHead = GameObject.FindWithTag("SnakeHead");
        o_SnakeBodyParts = GameObject.FindWithTag("SnakeBodyParts");
    }


}
