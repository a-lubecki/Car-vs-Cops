﻿using System;
using UnityEngine;

public class CarControlsManager : MonoBehaviour {



    [SerializeField] private GameObject goListener;

    private bool controlsEnabled = true;

    private ICarControlsManagerListener listener {
        get {
            return goListener?.GetComponent<ICarControlsManagerListener>();
        }
    }


    public void SetControlsEnabled(bool controlsEnabled) {
        this.controlsEnabled = controlsEnabled;
    }

    void Update() {

        if (!controlsEnabled) {
            return;
        }

        //handle long touch on the right or left side of the screen
        if (Input.GetMouseButton(0)) {

            if (Input.mousePosition.x < 0.5f * Screen.width) {
                listener?.onLeftPressed();
            } else {
                listener?.onRightPressed();
            }
        }

        //handle long press arrows for debugging
        #if UNITY_EDITOR

        if (Input.GetKey(KeyCode.LeftArrow)) {
            listener?.onLeftPressed();
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            listener?.onRightPressed();
        }

        #endif
    }

}


public interface ICarControlsManagerListener {

    void onLeftPressed();

    void onRightPressed();

}
