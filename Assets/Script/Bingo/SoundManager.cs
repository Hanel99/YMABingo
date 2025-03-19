using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }



    public void PlaySound(SoundType type)
    {
        var sound = ResourceManager.Instance.GetAudio(type);
        if (sound != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = sound;

            if (type == SoundType.puuu)
                audioSource.pitch = 0.9f;

            audioSource.Play();
            Destroy(audioSource, sound.length); // 소리가 끝나면 AudioSource를 제거
        }
    }
}
