using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpereGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SperePrefab;
    float span = 5.0f;
    float delta = 0;
    float totalElapsedTime = 0;
    float limitTime = 60.0f;

    // Update is called once per frame
    void Update()
    {
        totalElapsedTime += Time.deltaTime;

        if (totalElapsedTime <= limitTime) 
        {
            this.delta += Time.deltaTime;
            if (this.delta > this.span ) 
            {
                this.delta = 0;

                GameObject sphere = Instantiate(SperePrefab) as GameObject;
                //dummy와 겹쳐서 생성되지 않도록 수류탄 생성 범위 제한
                SperePrefab.transform.position = new Vector3(
                 Random.Range(-0.1f, 0.1f),
                 2f,
                 Random.Range(-0.1f, 0.1f)
             );


                // 새로운 수류탄이 생성될 때 ParticleSystem의 Play() 함수 호출
                ParticleSystem particleSystem = sphere.GetComponent<ParticleSystem>();
                if (particleSystem != null)
                {
                    particleSystem.Play();
                }
            }
        }
    }
}
