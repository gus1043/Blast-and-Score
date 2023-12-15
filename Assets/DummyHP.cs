using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHP : MonoBehaviour
{
    public int dummyhp = 2;
    public GameDirector gameDirector;
    private bool isDestroyed = false;

    void Start()
    {
        gameDirector = GameObject.FindObjectOfType<GameDirector>();
        gameDirector.AddDummy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (isDestroyed) return;
        dummyhp--;

        if (dummyhp <= 0)
        {
            isDestroyed = true;
            PlayDestroyEffects();
            // 1�� �Ŀ� Destroy �Լ��� ȣ���Ͽ� ���� ������Ʈ�� �ı��մϴ�.
            Invoke("DestroyObject", 0.8f);
        }
    }

    private void PlayDestroyEffects()
    {
        // �Ҹ� ���
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // ����Ʈ ���
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

    private void DestroyObject()
    {
        // GameDirector���� ���̰� ������ٰ� �˸��ϴ�.
        gameDirector.DummyDestroyed(gameObject);
        // 1�� �ڿ� ȣ��Ǿ� ���� ������Ʈ�� �ı��մϴ�.
        Destroy(gameObject);
    }

}
