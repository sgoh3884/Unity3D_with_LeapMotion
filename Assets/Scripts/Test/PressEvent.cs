using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEvent : MonoBehaviour
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


    public void OnUndoPressAcvite() {
        current.OnUndoActive = true;
    }

    public void OnRedoPressAcvite() {
        current.OnRedoActive = true;
    }

    public void OnUndoPressInacvite() {
        current.OnUndoActive = false;
    }

    public void OnRedoPressInacvite() {
        current.OnRedoActive = false;
    }
}
