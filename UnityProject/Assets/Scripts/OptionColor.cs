using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (name.Contains("0"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[0];
        if (name.Contains("1"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[1];
        if (name.Contains("2"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[2];
        if (name.Contains("3"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[3];
        if (name.Contains("4"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[4];
        if (name.Contains("5"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[5];
        if (name.Contains("6"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[6];
        if (name.Contains("7"))
            GetComponent<Button>().colors = DataContainer.GetInstance().colorBlock[7];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
