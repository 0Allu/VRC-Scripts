using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SimpleObjectToggle : UdonSharpBehaviour
{
    public GameObject YourObject; // VRC SDK doesn't need [SerializeField]
    
    public override void Interact()
    {
        YourObject.SetActive(!YourObject.activeSelf);
    }
}
