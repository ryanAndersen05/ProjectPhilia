using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour {
    #region main variables
    public AudioClip[] audioClipList;



    private AudioSource aSource;
    #endregion main variables

    /// <summary>
    /// Plays an audio clip from the beginning
    /// </summary>
    public void PlayClip()
    {
        StopClip();
        aSource.Play();
    }

    /// <summary>
    /// Stops the currenct audio clip
    /// </summary>
    public void StopClip()
    {
        if (aSource.isPlaying) aSource.Stop();
    }

    /// <summary>
    /// Pauses the currenct audio clip
    /// </summary>
    public void PauseClip()
    {
        aSource.Pause();
    }

    /// <summary>
    /// Unpauses a clip if the audio source is currently paused
    /// </summary>
    public void UnpauseClip()
    {
        aSource.UnPause();
    }

    public void SetAudioClip(int clipIndex)
    {
        if (clipIndex < 0 || clipIndex >= audioClipList.Length)
        {
            Debug.LogWarning("The audio clip index that was passed was out of range");
            return;
        }
        StopClip();
        aSource.clip = audioClipList[clipIndex];
    }
}
