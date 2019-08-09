using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    private string[] imageArray = new string[] {"11", "22", "33", "44", "55", "66", "77", "88"};
    private int index;
    private Text currentBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentBar = GameObject.Find("ProgressText").GetComponent<Text>();
        index = -1;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow)) { // ->
            index++;
            index %= 8;
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + imageArray[index].ToString()) as Sprite;
            currentBar.text = (index + 1).ToString() + " / " + imageArray.Length.ToString();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) { // <-
            index--;
            if (index < 0) {
                index = imageArray.Length - 1;
            }
            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + imageArray[index].ToString()) as Sprite;
            currentBar.text = (index + 1).ToString() + " / " + imageArray.Length.ToString();
        }
    }
}
