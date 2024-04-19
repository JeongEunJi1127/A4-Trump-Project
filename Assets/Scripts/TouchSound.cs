using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartSound : MonoBehaviour //2024.04.19 �����
{
    public AudioClip soundClip; // ����� ���� Ŭ�� 
    private AudioSource soundSource; // ����� �ҽ�

    void Start()
    {
        soundSource = GetComponent < AudioSource >(); // �ش� ���� ������Ʈ�� AudioSource ������Ʈ ��������
        Button button = GetComponent<Button>(); // �ش� ���� ������Ʈ�� Button ������Ʈ ��������
        button.onClick.AddListener(PlaySound); // ��ư Ŭ�� �̺�Ʈ�� PlaySound �޼ҵ带 �߰�
    }

    public void PlaySound()
    {
        SoundManager soundManager = FindObjectOfType<SoundManager>(); // Scene���� SoundManager ������Ʈ�� ã�Ƽ� ������
        if (soundManager != null) // SoundManager�� �����ϸ�
        {
            soundManager.PlaySound(soundClip); // SoundManager�� PlaySound �޼ҵ带 ����Ͽ� ���带 ���
        }
    }
}
