using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayList : UdonSharpBehaviour
{
    public AudioSource _as;
    public AudioClip[] ClipArray;
    public int num; // set to -1 in unity to start from first audioclip/song

    private AudioClip GetClip()
    {
        return ClipArray[num];
        //return ClipArray[Random.Range(0, ClipArray.Lenght)]; // This randomizes the list (if used remove int num)
    }

    void Update() 
    {
        if (!_as.isPlaying) 
        {
            num = num + 1;
            _as.clip = GetClip();
            _as.Play();
        }
    }
}
