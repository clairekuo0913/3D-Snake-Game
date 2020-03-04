using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_CubeGeneration : MonoBehaviour
{
    
	GameObject[, ,] gmobjarr_Cubes = new GameObject[100,100,100];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<10;i++){
        	for(int j=0;j<10;j++){
        		for(int k=0;k<10;k++){
        			gmobjarr_Cubes[i,j,k] = Instantiate(this.gameObject,new Vector3(this.transform.position.x+i,this.transform.position.y+j,this.transform.position.z+k),Quaternion.identity);
        		}
        	}
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
