using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class FixedHeight : UdonSharpBehaviour
{
    public float SetHeight = 1.8f;
    void Update() // Loops every frame to keep up with changing avatars
    {
        Networking.LocalPlayer.SetAvatarEyeHeightByMeters(SetHeight);
        Networking.LocalPlayer.SetAvatarEyeHeightMinimumByMeters(SetHeight);
        Networking.LocalPlayer.SetAvatarEyeHeightMaximumByMeters(SetHeight);
    }
}
