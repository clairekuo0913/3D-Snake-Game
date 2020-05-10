using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sc_Obstacle : MonoBehaviour
{
	public GameObject gmobj_Obstacle;
	GameObject gmobj_Cube;

    public void Generate(Vector3 v3_position, Vector3 v3_scale){
   		GameObject gmobj_thisObstacle = Instantiate(gmobj_Obstacle, v3_position,Quaternion.identity, gmobj_Cube.transform);
   		gmobj_thisObstacle.transform.localScale = v3_scale*0.1f;
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
       	Generate(Vector3.zero, new Vector3(1,1,1));
      }
    }
}
