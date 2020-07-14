using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class scriptVirtual : MonoBehaviour, IVirtualButtonEventHandler {
    VirtualButtonBehaviour[] virtualButtonBehaviour;
    string vbName;
    public string pageToOpen = "http://192.168.43.89/";

    // Start is called before the first frame update
    void Start () {
        virtualButtonBehaviour = GetComponentsInChildren<VirtualButtonBehaviour> ();
        for (int i = 0; i < virtualButtonBehaviour.Length; i++)
            virtualButtonBehaviour[i].RegisterEventHandler (this);
    }

    public void OnButtonPressed (VirtualButtonBehaviour vb) {
        vbName = vb.VirtualButtonName;
        if (vbName == "VirtualButton1")
            Btn1 ();
    }

    public void OnButtonReleased (VirtualButtonBehaviour vb) { }

    void Btn1 () {
        InAppBrowser.DisplayOptions options = new InAppBrowser.DisplayOptions ();
        options.browserBackgroundColor = "blue";
        options.hidesTopBar = true;
        InAppBrowser.OpenURL (pageToOpen, options);
    }

    void OnGUI () {
        // Make a text field that modifies stringToEdit.
        pageToOpen = GUI.TextField (new Rect (20, 40, 200, 20), pageToOpen, 120);
    }
}