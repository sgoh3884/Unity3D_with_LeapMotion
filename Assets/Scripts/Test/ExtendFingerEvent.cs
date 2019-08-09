using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendFingerEvent : MonoBehaviour
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

    public void OnExtendedFingerActive () {
        current.OnExtendedFingerActive = true;
    }

    public void OnExtendedFingerInactive () {
        current.OnExtendedFingerActive = false;
    }
}
