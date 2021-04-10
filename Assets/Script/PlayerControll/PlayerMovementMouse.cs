using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class PlayerMovementMouse : MonoBehaviour {
    private void Update () {
        if (Input.GetMouseButton (1)) {
            //调用移动
            GetComponent<IMovePosition> ().SetPosition (EveryFunction.GetMouseWorldPositionWithZ (Input.mousePosition));
        }
    }

}