using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyGenerator : MonoBehaviour
{
    public GameObject DummyPrefab;
    float span = 5.0f;
    float delta = 0;
    float totalElapsedTime = 0; // �� ��� �ð�
    float limitTime = 60.0f; // ���� ���� �� �ð�
    GameDirector gameDirector;

    void Start()
    {
        gameDirector = GameObject.FindObjectOfType<GameDirector>();
    }

    void Update()
    {
        totalElapsedTime += Time.deltaTime;

        if (totalElapsedTime <= limitTime) // �� ��� �ð��� ���� �ð����� �۰ų� ��������
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span)
            {
                this.delta = 0;

                Vector3 position;
                bool isTooClose;

                do
                {
                    // ���ο� ���� ��ġ ����
                    float x;
                    float z;

                    // x ��ǥ ����
                    if (Random.value < 0.5f)
                    {
                        x = Random.Range(-1.4f, -1.0f);
                    }
                    else
                    {
                        x = Random.Range(1.0f, 3.4f);
                    }

                    // z ��ǥ ����
                    if (Random.value < 0.5f)
                    {
                        z = Random.Range(-3.4f, -1.0f);
                    }
                    else
                    {
                        z = Random.Range(1.0f, 3.0f);
                    }

                    position = new Vector3(x, -0.96f, z);

                    // �̹� ������ ���̵���� �Ÿ� Ȯ��
                    isTooClose = false;
                    foreach (GameObject dummyPrefab in gameDirector.dummies)
                    {
                        if (Vector3.Distance(dummyPrefab.transform.position, position) < 1.0f)
                        {
                            isTooClose = true;
                            break;
                        }
                    }
                } while (isTooClose); // ���� �Ÿ��� �ʹ� ������ ���ο� ��ġ�� �ٽ� �����մϴ�.

                // ���� ����
                GameObject dummy = Instantiate(DummyPrefab) as GameObject;
                dummy.transform.position = position;
            }
        }
    }
}
