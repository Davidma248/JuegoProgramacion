using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class SOUND 
{

    public string name;
    public AudioClip clip;

    [Range (0f, 1f)]
    public float volumen;
    [Range (.1f, 3f)]
    public float pitch;
}