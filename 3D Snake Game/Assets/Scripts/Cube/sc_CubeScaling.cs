using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sc_CubeScaling : MonoBehaviour
{

    public float f_ScaleLengthMax;
    public float f_ScaleLengthMin;
    float f_ScalingTime;

    bool isProperScale(Vector3 v3_scale){
        if(v3_scale.x > f_ScaleLengthMax || v3_scale.y > f_ScaleLengthMax || v3_scale.z > f_ScaleLengthMax){
            return false;
        }else if(v3_scale.x < f_ScaleLengthMin || v3_scale.y < f_ScaleLengthMin || v3_scale.z < f_ScaleLengthMin){
            return false;
        }else{
            return true;
        }
    }

	public void Scale(Vector3 v3_direction,float f_scaleSize){
        v3_direction *= f_scaleSize;
        if(isProperScale(v3_direction+this.transform.lossyScale) && !this.GetComponent<sc_CubeRotation>().IsRotating()){
            this.gameObject.transform.DOScale(v3_direction+this.transform.lossyScale,f_ScalingTime);
        }else{
            //Debug.Log("i don't want to scale heh heh :))");
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {   

        f_ScalingTime = 1.0f;
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            Scale(new Vector3(1.0f,1.0f,1.0f), -1f);
        }else if(Input.GetKeyDown(KeyCode.W)){
            Scale(new Vector3(1.0f,1.0f,1.0f), 1f);
        }
    }
}
