using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sc_FadeTextUp1 : MonoBehaviour
{
	public TextMeshProUGUI TMPugui_Text;
    
    private IEnumerator FadeInText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }
    
    private IEnumerator FadeOutText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }

    private IEnumerator Fade (TextMeshProUGUI textToUse) {
		yield return StartCoroutine(FadeInText(1f, textToUse));
		yield return new WaitForSeconds(2f);
		yield return StartCoroutine(FadeOutText(1f, textToUse));
   	//End of transition, do some extra stuff!!	
	}

    // Start is called before the first frame update
    void Start()
    {
    	//TMPugui_Text = GetComponent<TextMeshProUGUI>();
    	StartCoroutine(Fade(TMPugui_Text));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
