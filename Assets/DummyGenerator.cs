using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGenerator : MonoBehaviour
{
    public GameObject DummyPrefab;
    float span = 5.0f;
    float delta = 0;
    float totalElapsedTime = 0; // 총 경과 시간
    float limitTime = 60.0f; // 더미 생성 총 시간
    GameDirector gameDirector;

    void Start()
    {
        gameDirector = GameObject.FindObjectOfType<GameDirector>();
    }

    void Update()
    {
        totalElapsedTime += Time.deltaTime;

        if (totalElapsedTime <= limitTime) // 총 경과 시간이 제한 시간보다 작거나 같을때만
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;

                Vector3 position;
                bool isTooClose;

                do
                {
                    // 새로운 더미 위치 생성
                    float x;
                    float z;

                    // x 좌표 생성
                    if (Random.value < 0.5f)
                    {
                        x = Random.Range(-1.4f, -1.0f);
                    }
                    else
                    {
                        x = Random.Range(1.0f, 3.4f);
                    }

                    // z 좌표 생성
                    if (Random.value < 0.5f)
                    {
                        z = Random.Range(-3.4f, -1.0f);
                    }
                    else
                    {
                        z = Random.Range(1.0f, 3.0f);
                    }

                    position = new Vector3(x, -0.96f, z);

                    // 이미 생성된 더미들과의 거리 확인
                    isTooClose = false;
                    foreach (GameObject dummyPrefab in gameDirector.dummies)
                    {
                        if (Vector3.Distance(dummyPrefab.transform.position, position) < 1.0f)
                        {
                            isTooClose = true;
                            break;
                        }
                    }
                } while (isTooClose); // 만약 거리가 너무 가까우면 새로운 위치를 다시 생성합니다.

                // 더미 생성
                GameObject dummy = Instantiate(DummyPrefab) as GameObject;
                dummy.transform.position = position;
            }
        }
    }
}
