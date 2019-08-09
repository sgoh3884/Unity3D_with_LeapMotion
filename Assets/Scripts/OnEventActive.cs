using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEventActive : MonoBehaviour
{
    private const float DEADLINE = 0.1f;

    private Main current;
    private Vector3 LeftHandPositionStandard;
    private Vector3 LeftHandPositionMoved;
    private bool OnGestureEditting;
    
    // Start is called before the first frame update
    void Start()
    {
        current = GameObject.Find("Game Manager").GetComponent<Main>();
        OnGestureEditting = false;
    }

    // Update is called once per frame
    void Update() {
        if (OnGestureEditting) {
            LeftHandPositionMoved = GameObject.Find("LeftHand").transform.Find("HandContainer").transform.position;

            if (LeftHandPositionStandard.x > LeftHandPositionMoved.x + DEADLINE) {
                current.OnUndoActive = true;
            }
            else if (LeftHandPositionStandard.x < LeftHandPositionMoved.x - DEADLINE) {
                current.OnRedoActive = true;
            }
            else {
                current.OnUndoActive = false;
                current.OnRedoActive = false;
            }
        }
    }

    // 1. Direct Click
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

    // 2. Indirect Click : Ray + Collider (Right Hand)

    public void OnExtendedFingerActive () {
        current.OnExtendedFingerActive = true;
    }

    public void OnExtendedFingerInactive () {
        current.OnExtendedFingerActive = false;
    }


    // 3. Pinch
    public void OnPinchActive () {
        if (current.stage == 3 && current.OnEditModeActive) { 
            if (this.gameObject.name.Equals("LeftHand") && !current.OnRedoActive) {
                current.OnUndoActive = true;
            }
            else if (this.gameObject.name.Equals("RightHand") && !current.OnUndoActive){
                current.OnRedoActive = true;
            }
        }
    }

    public void OnPinchInactive () {
        if (current.stage == 3 && current.OnEditModeActive) { 
            if (this.gameObject.name.Equals("LeftHand")) {
                current.OnUndoActive = false;
            }
            else if (this.gameObject.name.Equals("RightHand")){
                current.OnRedoActive = false;
            }
        }
    }


    // 4. Gesture (Left Hand)
    public void OnRockActive () {
        if (current.stage == 4 && current.OnEditModeActive) { 
            LeftHandPositionStandard = GameObject.Find("LeftHand").transform.Find("HandContainer").transform.position;
            OnGestureEditting = true;
        }
    }

    public void OnRockInactive () {
        if (current.stage == 4 && current.OnEditModeActive) { 
            OnGestureEditting = false;
            current.OnUndoActive = false;
            current.OnRedoActive = false;
        }
    }
}
