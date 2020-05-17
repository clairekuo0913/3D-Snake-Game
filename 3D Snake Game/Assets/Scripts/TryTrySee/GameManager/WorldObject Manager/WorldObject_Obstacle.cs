using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WorldObject_Obstacle : MonoBehaviour
{

    string sState;
    GameObject oSnakeHead,oSnake;
	public void Initialize(){
        Debug.Log(this.gameObject.name + "Initialize\n");
        UpdateState("wait");
	}

    public string CurrentState(){
        return sState;
    }

    IEnumerator Shaking(){
        yield return this.gameObject.transform.DOShakeScale(3.0f,1.0f,5,20.0f).WaitForCompletion();
    }
    // IEnumerator Coloring(){
        // yield return this.gameObject.GetComponent<Material>().DOFade(0.0f,3.0f).WaitForCompletion();
    // }

    IEnumerator Into(){
        RotationHandler.Forbidden();
        Debug.Log(this.gameObject.name + ": state(Into)\n");
        WorldObject_Snake.v3_ObstaclePos = this.transform.position;
        StartCoroutine("Shaking");
        // StartCoroutine("Coloring");
        while(sState == "into"){
            RotationHandler.Forbidden();
            if(WorldObject_Snake.CurrentState()=="wait"){
                UpdateState("stay");
                yield break;
            }
            yield return null;
        }
    }

    IEnumerator Stay(){
        Debug.Log(this.gameObject.name + ": state(Stay)\n");
        while(sState == "stay"){
            if(RotationHandler.IsRotating()){
                UpdateState("leave");
                yield break;
            }
            yield return null;
        }
    }
    
    IEnumerator Leave(){
        Debug.Log(this.gameObject.name + ": state(leave)\n");
        while(RotationHandler.IsRotating()){
            yield return null;
        }
        while(oSnakeHead.GetComponent<Collider>().bounds.Intersects(this.gameObject.GetComponent<Collider>().bounds) || RotationHandler.IsRotating()){
            yield return null;
        }
        UpdateState("wait");
    }

    IEnumerator Wait(){
        Debug.Log(this.gameObject.name + ": state(wait)\n");
        while(sState == "wait"){
            if(oSnakeHead.GetComponent<Collider>().bounds.Intersects(this.gameObject.GetComponent<Collider>().bounds) && !RotationHandler.IsRotating()){
                UpdateState("into");
                oSnake.GetComponent<WorldObject_Snake>().UpdateState("decrease");
                yield break;
            }
            yield return null;
        }
    }


    public void UpdateState(string state){
        sState=state;
        if(state == "wait"){
            StartCoroutine("Wait");
        }else if(state == "into"){
            StartCoroutine("Into");
        }else if(state == "stay"){
            StartCoroutine("Stay");
        }else if(state == "leave"){
            StartCoroutine("Leave");
        }
    }

    void Start(){
        oSnakeHead = GameObject.FindWithTag("SnakeHead");
        oSnake = GameObject.FindWithTag("Snake");
        UpdateState("wait");
    }
}
