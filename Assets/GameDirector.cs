using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public GameObject dummyPrefab;
    GameObject timerText;
    GameObject dummyCountText;
    GameObject infoText;
    float time = 60.0f;
    int dummyCount = 0; // 더미가 사라진 숫자를 추적하는 변수
    //전체 더미들의 크기를 시간에 맞춰 줄이기 위해서 리스트에 저장
    public List<GameObject> dummies = new List<GameObject>();
    public RectTransform panel;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.dummyCountText = GameObject.Find("DummyCount");
        this.infoText = GameObject.Find("Info");
        panel = GameObject.Find("InGamePanel").GetComponent<RectTransform>();
        StartCoroutine(DecreaseDummySize());
    }

    // 더미가 생성될 때 호출해야 하는 메서드입니다.
    public void AddDummy(GameObject dummy)
    {
        dummies.Add(dummy);
    }

    // 더미가 파괴될 때 호출해야 하는 메서드입니다.
    public void DummyDestroyed(GameObject dummy)
    {
        dummies.Remove(dummy);
        dummyCount++;
    }

    IEnumerator DecreaseDummySize()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);

            // 전체 더미의 크기 10초마다 줄이기 
            foreach (GameObject dummy in dummies)
            {
                dummy.transform.localScale *= 0.9f;

                Collider collider = dummy.GetComponent<Collider>();
                if (collider is BoxCollider)
                {
                    BoxCollider boxCollider = (BoxCollider)collider;
                    boxCollider.size *= 0.9f;
                }
                else if (collider is SphereCollider)
                {
                    SphereCollider sphereCollider = (SphereCollider)collider;
                    sphereCollider.radius *= 0.9f;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (this.time <= 0.01f)
        {
            this.time = 0;
            this.infoText.GetComponent<Text>().text = "게임 종료";
        }
        else
        {
            this.time -= Time.deltaTime;
            this.infoText.GetComponent<Text>().text = "게임 상태";
        }

        this.timerText.GetComponent<Text>().text = "남은 시간: " + this.time.ToString("F1");
        this.dummyCountText.GetComponent<Text>().text = "처치 수: " + this.dummyCount.ToString();

        if (this.time == 0)
        {
            // 패널의 위치와 크기를 조정합니다.
            panel.anchorMin = Vector2.zero;
            panel.anchorMax = Vector2.one;
            panel.anchoredPosition3D = Vector3.zero;
            panel.sizeDelta = Vector2.zero;
        }
    }
}
