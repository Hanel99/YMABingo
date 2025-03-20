using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public List<Sprite> ImageResources = new List<Sprite>();
    public List<AudioClip> AudioResources = new List<AudioClip>();


    public AudioClip GetAudio(SoundType type)
    {
        int index = (int)type;
        if (index >= 0 && index < AudioResources.Count)
        {
            return AudioResources[index];
        }
        return null;
    }

    public Sprite GetRandomSprite()
    {
        int index = Random.Range(0, ImageResources.Count);
        return ImageResources[index];
    }


}
