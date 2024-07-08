using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Footsteps : UdonSharpBehaviour
{
    public AudioSource footstepAudioSource; // The audio source for footstep sounds
    public AudioClip[] footstepClips; // Array of footstep sound clips
    public float minFootstepDelay = 0.2f; // Minimum delay between footsteps
    public float maxFootstepDelay = 1.0f; // Maximum delay between footsteps
    private float footstepTimer = 0.0f;

    void Start()
    {
        UpdateFootstepDelay();
    }

    void Update()
    {
        // Update the footstep timer based on deltaTime
        footstepTimer -= Time.deltaTime;

        // If the timer has reached zero, play a footstep sound and reset the timer
        if (footstepTimer <= 0.0f && Networking.LocalPlayer.GetVelocity().magnitude > 0.1f) // Slight threshold to avoid triggering at very low speeds
        {
            PlayFootstepSound();
            UpdateFootstepDelay();
        }
    }

    void UpdateFootstepDelay()
    {
        // Calculate the velocity magnitude of the player
        float velocityMagnitude = Networking.LocalPlayer.GetVelocity().magnitude;

        // Map the velocity magnitude to the footstep delay
        // Assuming the velocity magnitude ranges from 0 to 2
        float footstepDelay = Mathf.Lerp(maxFootstepDelay, minFootstepDelay, velocityMagnitude / 2.0f);

        // Set the timer to the new footstep delay
        footstepTimer = footstepDelay;
    }

    void PlayFootstepSound()
    {
        if (footstepClips.Length > 0 && Networking.LocalPlayer.IsPlayerGrounded() == true)
        {
            // Select a random footstep clip from the array
            int index = Random.Range(0, footstepClips.Length);
            AudioClip clip = footstepClips[index];

            // Play the selected footstep clip
            footstepAudioSource.PlayOneShot(clip);
        }
    }
}
