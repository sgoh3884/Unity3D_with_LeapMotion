using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // 공통
    public int stage;
    public bool OnEditModeActive;
    public bool OnUndoActive;
    public bool OnRedoActive;

    // Ray + Extend finger
    public bool OnColliderLeftActive;
    public bool OnColliderRightActive;
    public bool OnExtendedFingerActive;

    GameObject StageText, Forward, Right_IndexFinger;

    // Start is called before the first frame update
    void Start()
    {
        stage = 0;
        OnEditModeActive = false;
        OnUndoActive = false;
        OnRedoActive = false;
        OnColliderLeftActive = false;
        OnColliderRightActive = false;
        OnExtendedFingerActive = false;

        StageText = GameObject.Find("StageText");
    }

    // Update is called once per frame
    void Update()
    {
        // Edit 모드 실행 : Enter
        if (stage != 0 && Input.GetKeyDown(KeyCode.Return)) {
            OnEditModeActive = !OnEditModeActive;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad0)) {
            stage = 0;
            OnEditModeActive = false;
            StageText.GetComponent<Text>().text = "";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1)) {
            stage = 1;
            OnEditModeActive = false;
            StageText.GetComponent<Text>().text = "1. 직접 클릭";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2)) {
            stage = 2;
            OnEditModeActive = false;
            StageText.GetComponent<Text>().text = "2. 간접 클릭";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3)) {
            stage = 3;
            OnEditModeActive = false;
            StageText.GetComponent<Text>().text = "3. Pinch";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4)) {
            stage = 4;
            OnEditModeActive = false;
            StageText.GetComponent<Text>().text = "4. 제스처";
        }

        if (OnEditModeActive) {
            // 1번 모드 : 직접 클릭
            if (stage == 1) {
                GameObject.Find("Forward").GetComponent<MeshRenderer>().material.color = Color.red;
                GameObject.Find("Interface").transform.Find("ButtonUI").gameObject.SetActive(true); // 버튼 인터페이스
                GameObject.Find("AnimaitionImage").GetComponent<Image>().enabled = true; // TV 방향 이미지
            }
            // 2번 모드 : 간접 클릭
            else if (stage == 2) { 
                GameObject.Find("Forward").GetComponent<MeshRenderer>().material.color = Color.red;
                GameObject.Find("Forward").GetComponent<BoxCollider>().enabled = false; // 오른쪽 박스 콜리더 비활성화
                GameObject.Find("AnimaitionImage").GetComponent<Image>().enabled = true; // TV 방향 이미지
                
                GameObject.Find("LeftColliderBox").GetComponent<BoxCollider>().enabled = true; // 왼쪽 박스 콜리더 비활성화
                GameObject.Find("RightColliderBox").GetComponent<BoxCollider>().enabled = true; // 오른쪽 박스 콜리더 비활성화

                if (GameObject.Find("HandModels").transform.Find("RightHand").gameObject.activeSelf) {
                    GameObject.Find("R_Finger_Index_B").transform.Find("Ray").gameObject.SetActive(true);
                }
            }
            // 3번 모드 : Pinch 클릭
            else if (stage == 3) {
                GameObject.Find("Forward").GetComponent<MeshRenderer>().material.color = Color.red;
                GameObject.Find("AnimaitionImage").GetComponent<Image>().enabled = true; // TV 방향 이미지
            }
            // 4번 모드 : Gesture
            else if (stage == 4) {
                GameObject.Find("Forward").GetComponent<MeshRenderer>().material.color = Color.red;
                GameObject.Find("AnimaitionImage").GetComponent<Image>().enabled = true; // TV 방향 이미지
            }
        }
        else if (!OnEditModeActive) {
            // 1번 모드
            if (GameObject.Find("HandModels").transform.Find("RightHand").gameObject.activeSelf) {
                GameObject.Find("R_Finger_Index_B").transform.Find("Ray").gameObject.SetActive(false);
            }

            GameObject.Find("Forward").GetComponent<MeshRenderer>().material.color = Color.black;
             GameObject.Find("Forward").GetComponent<BoxCollider>().enabled = true;
            GameObject.Find("Interface").transform.Find("ButtonUI").gameObject.SetActive(false);
            GameObject.Find("AnimaitionImage").GetComponent<Image>().enabled = false;
            GameObject.Find("LeftColliderBox").GetComponent<BoxCollider>().enabled = false; // TV 방향 이미지
            GameObject.Find("RightColliderBox").GetComponent<BoxCollider>().enabled = false; // TV 방향 이미지
            
        }
    }
}
