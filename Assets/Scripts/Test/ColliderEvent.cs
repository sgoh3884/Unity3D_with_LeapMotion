using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
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

    // void OnCollisionStay(Collision other) {
    //     if (this.gameObject.name.Equals("LeftColliderBox") && current.OnExtendedFingerActive && !current.OnRedoActive) {
    //         current.OnUndoActive = true;
    //         GameObject.Find("Ray").GetComponent<MeshRenderer>().material.color = Color.green;
    //     }
    //     else if (this.gameObject.name.Equals("RightColliderBox") && current.OnExtendedFingerActive && !current.OnUndoActive) {
    //         current.OnRedoActive = true;
    //         GameObject.Find("Ray").GetComponent<MeshRenderer>().material.color = Color.green;
    //     }
    // }

    // void OnCollisionExit(Collision other) {
        
    //     if (this.gameObject.name.Equals("LeftColliderBox") || !current.OnExtendedFingerActive) {
    //         current.OnUndoActive = false;
    //         GameObject.Find("Ray").GetComponent<MeshRenderer>().material.color = Color.black;
    //     }
    //     else if (this.gameObject.name.Equals("RightColliderBox") || current.OnExtendedFingerActive) {
    //         current.OnRedoActive = false;
            
    //         GameObject.Find("Ray").GetComponent<MeshRenderer>().material.color = Color.black;
    //     }
    // }

    void OnTriggerStay(Collider other) {
        GameObject.Find("Ray").GetComponent<MeshRenderer>().material.color = Color.green;
        if (this.gameObject.name.Equals("LeftColliderBox") && current.OnExtendedFingerActive && !current.OnRedoActive) {
            current.OnUndoActive = true;
        }
        else if (this.gameObject.name.Equals("RightColliderBox") && current.OnExtendedFingerActive && !current.OnUndoActive) {
            current.OnRedoActive = true;
        }
    }

    void OnTriggerExit(Collider other) {
        GameObject.Find("Ray").GetComponent<MeshRenderer>().material.color = Color.black;
        if (this.gameObject.name.Equals("LeftColliderBox") || !current.OnExtendedFingerActive) {
            current.OnUndoActive = false;
        }
        else if (this.gameObject.name.Equals("RightColliderBox") || current.OnExtendedFingerActive) {
            current.OnRedoActive = false;
        }
    }
}
