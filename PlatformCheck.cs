using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlatformCheck : UdonSharpBehaviour
{
    public GameObject VR; // EXAMPLE TOGGLE
    void Start() 
    {
        if (Networking.LocalPlayer.IsUserInVR() == true) { // -- Checks if the local player is in VR --
            VR.SetActive = true; // EXAMPLE TOGGLE
        }
        else { // -- returns false is user is in desktop mode --
            VR.SetActive = false; // EXAMPLE TOGGLE
        }
    }
}
