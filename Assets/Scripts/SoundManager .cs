using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour //2024.04.19 �����
{
    private static SoundManager instance; // SoundManager �ν��Ͻ�
    private AudioSource soundSource; // ���带 ����� AudioSource

    void Awake()
    {
        if (instance == null) // �ν��Ͻ��� ������
        {
            instance = this; // ���� �ν��Ͻ��� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ�� �Ǿ �ı����� ����
            soundSource = gameObject.AddComponent<AudioSource>(); // AudioSource�� �߰��Ͽ� ���带 ����� �غ�
        }
        else // �ν��Ͻ��� �̹� �����ϸ�?
        {
            Destroy(gameObject); // ���� ������ �ν��Ͻ� �ı�
        }
    }

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip); // �־��� AudioClip�� ���
    }
}
