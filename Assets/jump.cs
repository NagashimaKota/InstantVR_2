using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class jump : MonoBehaviour {

    private float powerX = 0.0f;
    private float powerY = 0.0f;         //
    private float powerScale = 100.0f;  //パワーにかける倍率

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //右コントローラーと左コントローラーの差を取得
        powerX = InputTracking.GetLocalPosition(VRNode.RightHand).z - InputTracking.GetLocalPosition(VRNode.LeftHand).x;
        powerY = InputTracking.GetLocalPosition(VRNode.RightHand).y - InputTracking.GetLocalPosition(VRNode.LeftHand).y;


        //このオブジェクトのY軸に力を加える
        this.transform.GetComponent<Rigidbody>().AddForce(0, powerY * powerScale, 0);


        if (this.transform.position.y <= 1)
        {
            //地面を貫通させない処置
            this.transform.position = new Vector3(0, 1, 0);
        }

    }
}
