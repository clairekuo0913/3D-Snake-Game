using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    GameObject oSnake;
	static string sLevelState; // start -> wait -> play -> dead or win
    string sReason;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLevelState("start");
    }

    void LevelStart(){
        Debug.Log("Level State: Start!\n");
        // if(PlayerStats.CurrentLevel==0){
            // LevelInfo.Level_test();
        // }
        // Snake
        oSnake = GameObject.FindWithTag("Snake");
        if(oSnake!=null){
            oSnake.GetComponent<WorldObject_Snake>().Initialize();
        }
        // Object Initialize
        WorldObjectManager.Initialize();
        // UI Initialize
      		/* TODO */
      	// Input Forbidden  
        InputManager.Forbidden();
        RotationHandler.Forbidden();
        // Switch To Next State
        UpdateLevelState("wait");

    }

    IEnumerator LevelWait(){
        Debug.Log("Level State: Wait!\n");
    	InputManager.Allowed();
        RotationHandler.Allowed();
    	while(sLevelState == "wait"){
            if(RotationHandler.IsRotating()){
                UpdateLevelState("play");
                yield break;
            }   
            yield return null;
    	}
        
    }

	IEnumerator LevelPlay(){
        InputManager.Allowed();
        WorldObjectManager.UpdateState("play");
        RotationHandler.Allowed();
        SnakeCollisionHandler.Allowed();
        Debug.Log("Level State: Play!\n");
		while(sLevelState == "play"){
            GameObject oCollision = SnakeCollisionHandler.CollisionObject();
            if(oCollision!=null){
                if(oCollision.tag == "Cube"){
                    sReason = "die_cube";
                    UpdateLevelState("die");
                    yield break;
                }else if(oCollision.tag == "SnakeBodyPart"){
                    sReason = "die_snake";
                    UpdateLevelState("die");
                    yield break;
                }else if(oCollision.tag == "Endpoint"){
                    UpdateLevelState("win");
                    yield break;
                }
                // }else if(oCollision.tag == "Obstacle"){
                //     oSnake.GetComponent<WorldObject_Snake>().UpdateState("decrease");
                //     oCollision.GetComponent<WorldObject_Obstacle>().UpdateState("into");

                //     GameObject currCollision = SnakeCollisionHandler.CollisionObject();

                //     while(oCollision == currCollision /*|| oCollision.GetComponent<WorldObject_Obstacle>().CurrentState()!="wait"*/){
                //         currCollision = SnakeCollisionHandler.CollisionObject();
                //         yield return null;
                //     }
                //     // Debug.Log("Leave the Obstacle!\n");
                // }
            }
            yield return null;            
		}
	}

    void LevelDie(){
        Debug.Log("Level State: "+sReason+"!\n");
        if(sReason == "die_snake"){
            // Animator、Sound 
            Debug.Log("die snake\n");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            // UpdateLevelState("start");
        }else if(sReason == "die_cube"){
            // Animator、Sound
            Debug.Log("die cube\n");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                /* TODO */
        }
    }

    void LevelWin(){
        if(PlayerStats.CurrentLevel == 0){
            PlayerStats.CurrentLevel=1;
            SceneManager.LoadScene("Level t2");
        }else if(PlayerStats.CurrentLevel == 1){
            PlayerStats.CurrentLevel=0;
            SceneManager.LoadScene("Level t1");
        }
        //Scene Change, Animator, Sound bla 
    }

    void UpdateLevelState(string levelState){
    	sLevelState = levelState;
        if(levelState == "start"){
            LevelStart();
    	}else if(levelState == "wait"){
    		StartCoroutine("LevelWait");
        }else if(levelState == "play"){
            StartCoroutine("LevelPlay");
        }else if(levelState == "die"){
        	LevelDie();
        }else if(levelState == "win"){
            LevelWin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //sLevelState = "wait";
    }
}
