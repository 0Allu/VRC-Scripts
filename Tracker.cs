using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace Tracker
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)] // No variables are serialized over network.

    public class Tracker : UdonSharpBehaviour
    {   
        [Tooltip("Toggle use of attachments to tracked positions.")] // Local player head tracking
        [SerializeField] private bool useAttachments = true;
        [Tooltip("Game object attached to head position.")]
        [SerializeField] private GameObject headAttachment;

        private VRCPlayerApi playerLocal; // Reference to local player.
        [HideInInspector] public VRCPlayerApi.TrackingData headData; // Head tracking data.

        public void Start()
        {   
            playerLocal = Networking.LocalPlayer; // Tie to local player
        }

        public override void PostLateUpdate()
        {   
            VRCPlayerApi.TrackingData headData = playerLocal.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
            if (useAttachments) UpdateAttachments(); // Run every frame
        }

        private void UpdateAttachments()
        {   // Set attatchment position
            if (headAttachment != null) headAttachment.transform.SetPositionAndRotation(headData.position, headData.rotation);
        }
    }
}
