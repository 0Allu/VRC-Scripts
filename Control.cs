using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.Rendering.PostProcessing;

public class Control : UdonSharpBehaviour
{
    public bool isAllowed = false;
    public PostProcessVolume PP;
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            isAllowed = true;
            Networking.LocalPlayer.SetJumpImpulse(3);
        }
    }

    void Update()
    {
        if (!isAllowed)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.M)) // M Faster Running
        {
            Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() + 1f);
        }

        if (Input.GetKeyDown(KeyCode.N)) // N Slower Running
        {
            Networking.LocalPlayer.SetRunSpeed(Networking.LocalPlayer.GetRunSpeed() - 1f);
        }

        if (Input.GetKeyDown(KeyCode.P)) // P Toggle postprocessing
        {
            if (PP != null)
            {
                PP.enabled = !PP.enabled;
            }
        }

        if (Input.GetKeyDown(KeyCode.F)) // F Toggle Fog
        {
            RenderSettings.fog = !RenderSettings.fog;
        }
    }
}
