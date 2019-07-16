using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles Block 

public class BlockInfo : MonoBehaviour {

	public string opcode;
	public int param;
    public string paramp;
	public TextMesh textObj;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void setOpcode(string op){
		opcode = op;
	}

	public void setParam(int p){
		param = p;
		textObj.text = p.ToString();
	}

    public void setParams(string p)
    {
        paramp = p;
        textObj.text = p.ToString();
    }

    public static void Set_Size(GameObject gameObject, float width, float height)
    {
        if (gameObject != null)
        {
            var rectTransform = gameObject.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(width, height);
            }
        }
    }

	public string getParam(){
		return param.ToString();
	}

	public string getOpcode(){
		return opcode;
	}


}
