using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card FirstCard { get; set; }
    public Card SecondCard { get; set; }

    [SerializeField] private float maxTime;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject endText;
    [SerializeField] private Image timerBackground; // Ÿ�̸� ��� �̹���
    [SerializeField] private AudioClip speedAudioClip; // ����� ������� Ŭ��

    private AudioSource audioSource;
    [SerializeField] private AudioClip matchAudio;
    public int CardCount { get; set; }
    public bool isPlay;
    private float timer = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        isPlay = false;
        timer = maxTime;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        //�ð���� > Ÿ�̸� ���� ����
        timer -= Time.deltaTime;
        //Ÿ�̸Ӱ� > ui ǥ��
        timeText.text = $"{timer:F2}";

        // 10�� ������ ��
        if (timer <= 10f) 
        {
            //���� �Ӱ� ����[1f=red 0.5f=green/blue]
            timerBackground.color = new Color(1f, 0.5f, 0.5f);

            //��������� ��� ���� �ƴ� ���
            if (!audioSource.isPlaying)
            {
                //audioSource�� Ŭ�� = ����� ������� Ŭ��
                audioSource.clip = speedAudioClip;
                //����� ������� ���
                audioSource.Play();
            }
        }
        else
        {
            // Ÿ�̸� �̹��� ���� ������� ����
            timerBackground.color = Color.white;

            //������� ����
            audioSource.Stop();
        }

        if (timer <= 0)
        {
            timer = 0;
            GameEnd();
        }
    }

    private void GameEnd()
    {
        isPlay = true;
        Time.timeScale = 0f;
        endText.SetActive(true);
    }

    public void Matched()
    {
        // ���� ī����
        if (FirstCard.idx == SecondCard.idx)
        {
            audioSource.PlayOneShot(matchAudio);
            FirstCard.DestroyCard();
            SecondCard.DestroyCard();
            CardCount -= 2;
            if (CardCount == 0)
            {
                GameEnd();
            }
        }
        else // ���� �ʴٸ�
        {
            FirstCard.CloseCard();
            SecondCard.CloseCard();
        }

        FirstCard = null;
        SecondCard = null;
    }
}
