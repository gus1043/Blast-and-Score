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
    int dummyCount = 0; // ���̰� ����� ���ڸ� �����ϴ� ����
    //��ü ���̵��� ũ�⸦ �ð��� ���� ���̱� ���ؼ� ����Ʈ�� ����
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

    // ���̰� ������ �� ȣ���ؾ� �ϴ� �޼����Դϴ�.
    public void AddDummy(GameObject dummy)
    {
        dummies.Add(dummy);
    }

    // ���̰� �ı��� �� ȣ���ؾ� �ϴ� �޼����Դϴ�.
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

            // ��ü ������ ũ�� 10�ʸ��� ���̱� 
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
            this.infoText.GetComponent<Text>().text = "���� ����";
        }
        else
        {
            this.time -= Time.deltaTime;
            this.infoText.GetComponent<Text>().text = "���� ����";
        }

        this.timerText.GetComponent<Text>().text = "���� �ð�: " + this.time.ToString("F1");
        this.dummyCountText.GetComponent<Text>().text = "óġ ��: " + this.dummyCount.ToString();

        if (this.time == 0)
        {
            // �г��� ��ġ�� ũ�⸦ �����մϴ�.
            panel.anchorMin = Vector2.zero;
            panel.anchorMax = Vector2.one;
            panel.anchoredPosition3D = Vector3.zero;
            panel.sizeDelta = Vector2.zero;
        }
    }
}
