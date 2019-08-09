using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditAnimation : MonoBehaviour
{
    private Main current;
    private string[] imageArray = new string[] {"Pause", "Redo", "Undo"};
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        current = GameObject.Find("Game Manager").GetComponent<Main>();
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (current.OnEditModeActive) {
            if (current.OnUndoActive) {
                index = 2;
            }
            else if (current.OnRedoActive) {
                index = 1;
            }
            else {
                index = 0;
            }

            this.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + imageArray[index].ToString()) as Sprite;
        }
    }
}
