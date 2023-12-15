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
            // 1초 후에 Destroy 함수를 호출하여 게임 오브젝트를 파괴합니다.
            Invoke("DestroyObject", 0.8f);
        }
    }

    private void PlayDestroyEffects()
    {
        // 소리 재생
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // 이펙트 재생
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }

    private void DestroyObject()
    {
        // GameDirector에게 더미가 사라졌다고 알립니다.
        gameDirector.DummyDestroyed(gameObject);
        // 1초 뒤에 호출되어 게임 오브젝트를 파괴합니다.
        Destroy(gameObject);
    }

}
