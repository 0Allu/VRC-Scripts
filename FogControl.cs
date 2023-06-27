using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.Rendering;
using System.Collections;
using System.Threading.Tasks;
namespace FogControl
{
    public class FogControl : UdonSharpBehaviour
    {
        public GameObject Collider;
        public float smooth = 2;
        private float NewFogEndDistance = 22f;
        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            if (player.isLocal)
            {
                Collider.transform.localScale = new Vector3(15f, 15f, 15f);
                RenderSettings.fogEndDistance = Mathf.MoveTowards(RenderSettings.fogEndDistance, NewFogEndDistance, Time.deltaTime * smooth);
            }
        }
    }
}
