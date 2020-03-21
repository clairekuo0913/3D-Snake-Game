using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sc_Obstacle : MonoBehaviour
{
	public GameObject gmobj_Obstacle;
	GameObject gmobj_Cube;


	IEnumerator StartObstacleMovement(GameObject gmobj_thisObstacle, Vector3 v3_path, float f_moveDuration){
	    while(true){
			yield return gmobj_thisObstacle.transform.DOLocalMove(v3_path,f_moveDuration,false).WaitForCompletion();
			yield return gmobj_thisObstacle.transform.DOLocalMove(-1*v3_path,f_moveDuration,false).WaitForCompletion();
		}
	}


    public void Generate(Vector3 v3_position, Vector3 v3_scale,Vector3 v3_path, float f_moveDuration){
   		GameObject gmobj_thisObstacle = Instantiate(gmobj_Obstacle, v3_position,Quaternion.identity, gmobj_Cube.transform);
   		gmobj_thisObstacle.transform.localScale = v3_scale*0.1f;
   		if(v3_path!=Vector3.zero){
   			StartCoroutine(StartObstacleMovement(gmobj_thisObstacle,v3_path,f_moveDuration));
   		}
   	}

    // Start is called before the first frame update
    void Start()
    {
    	gmobj_Cube = GameObject.FindWithTag("Cube");
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.G)){
       	Generate(Vector3.zero, new Vector3(1,1,1), new Vector3(0.5f,0,0),1);
      }
    }
}
