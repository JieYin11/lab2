using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip backgroundMusic; // 背景音乐
    private AudioSource audioSource; // AudioSource组件

    void Start()
    {
        // 添加AudioSource组件
        audioSource = gameObject.AddComponent<AudioSource>();
        // 设置背景音乐
        audioSource.clip = backgroundMusic;
        // 设置为循环播放
        audioSource.loop = true;
        // 播放背景音乐
        audioSource.Play();
    }
}

