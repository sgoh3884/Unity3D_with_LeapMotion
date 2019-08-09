using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchEvent : MonoBehaviour
{
    private Main current;

    // Start is called before the first frame update
    void Start()
    {
        current = GameObject.Find("Game Manager").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPinchActive () {
        if (this.gameObject.name.Equals("LeftHand") && !current.OnRedoActive) {
            current.OnUndoActive = true;
        }
        else if (this.gameObject.name.Equals("RightHand") && !current.OnUndoActive){
            current.OnRedoActive = true;
        }
    }

    public void OnPinchInactive () {
        if (this.gameObject.name.Equals("LeftHand")) {
            current.OnUndoActive = false;
        }
        else {
            current.OnRedoActive = false;
        }
    }
}
