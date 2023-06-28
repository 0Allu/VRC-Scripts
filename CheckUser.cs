using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class CheckUser : UdonSharpBehaviour
{
    public GameObject Door;
    public GameObject Secret;
    public GameObject NoLooky;

    public string[] allowedNames = { "Slim", "Rick", "Jennifer" };

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            string displayName = Networking.LocalPlayer.displayName;

            for (int i = 0; i < allowedNames.Length; i++)
            {
                if (displayName == allowedNames[i])
                {
                    Secret.SetActive(true);
                    NoLooky.SetActive(false);
                    Door.SetActive(false);
                    break;
                }
            }
        }
    }
}
