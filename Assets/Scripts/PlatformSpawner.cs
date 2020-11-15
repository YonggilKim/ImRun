using System.Collections;
using UnityEngine;

// 발판을 생성하고 주기적으로 재배치하는 스크립트
public class PlatformSpawner : MonoBehaviour {

    public static PlatformSpawner instance; // 싱글톤을 할당할 전역 변수
    public GameObject parent;
    public GameObject platformPrefab; // 생성할 발판의 원본 프리팹
    public GameObject rightEnd;
    public GameObject leftEnd;
    public int count = 3; // 생성할 발판의 개수
    private float xPos = 20f; // 배치할 위치의 x 값

    private GameObject[] platforms; // 미리 생성한 발판들
    private int currentIndex = 0; // 사용할 현재 순번의 발판

    private Vector2 poolPosition = new Vector2(0, 25); // 초반에 생성된 발판들을 화면 밖에 숨겨둘 위치

    void Awake()
    {
        // 싱글톤 변수 instance가 비어있는가?
        if (instance == null)
        {
            // instance가 비어있다면(null) 그곳에 자기 자신을 할당
            instance = this;
        }
        else
        {
            // instance에 이미 다른 GameManager 오브젝트가 할당되어 있는 경우

            // 씬에 두개 이상의 GameManager 오브젝트가 존재한다는 의미.
            // 싱글톤 오브젝트는 하나만 존재해야 하므로 자신의 게임 오브젝트를 파괴
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    void Start() {
        //변수들을 초기화하고 사용할 발판들을 미리 생성
        platforms = new GameObject[count];
        // 카운트만큼 발판 생성
        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            platforms[i].transform.parent = parent.transform;
        }

        //StartCoroutine(StartRaycast());
    }
    //IEnumerator StartRaycast()
    //{
    //    while (true)
    //    {
    //        if (PlayerController.instance.isLeftty == false)
    //        {
    //            RaycastHit2D hit = Physics2D.Raycast(rightEnd.transform.position, -transform.up, 10f);
    //            if (hit)
    //            {
    //                if (hit.transform.gameObject.name == "Deadzone")
    //                {
    //                    // 오른쪽에 프래폼 생성
    //                    makePlatform();
    //                }
    //                //Debug.Log(hit.transform.gameObject.name);
    //            }

    //        }
    //        else 
    //        {
    //            RaycastHit2D hit = Physics2D.Raycast(leftEnd.transform.position, -transform.up, 10f);
    //            if (hit)
    //            {
    //                if (hit.transform.gameObject.name == "Deadzone")
    //                {
    //                    // 왼쪽에 프래폼 생성
    //                    makePlatform(true);
    //                }
    //                //Debug.Log(hit.transform.gameObject.name);
    //            }
    //        }
    //        yield return new WaitForSeconds(0.2f);
    //    }


    //}
    public void makePlatform(bool isleft = false)
    {
        ////lastSpawnTime = Time.time;
        ////timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        //float yPos = -3.68f;

        ////사용할 현재 순번의 발판 게임 오브젝트를 비활성화 하고 즉시 다시 활성화 
        //// 이떄 발판의 platform 컴포먼트의 OnEnable 메서드가 실행됨
        //platforms[currentIndex].SetActive(false);
        //platforms[currentIndex].SetActive(true);

        ////케릭터가 오른쪽으로 향하는 경우
        //if(isleft ==false)
        //     platforms[currentIndex].transform.position = new Vector2(12.8f, yPos);
        //else
        //    platforms[currentIndex].transform.position = new Vector2(-12.8f, yPos);

        ////케릭터가 왼쪽으로 향하는 경우
        //currentIndex++;
        //if (currentIndex >= count)
        //{
        //    currentIndex = 0;
        //}
    }
    void Update() {
        
        // 순서를 돌아가며 주기적으로 발판을 배치
        //if (GameManager.instance.isGameover)
        //    return;

        ////마지막 배치 시점에서 timebetSpawan 이상 시간이 흘렀다면
        //if (Time.time >= lastSpawnTime + timeBetSpawn)
        //{
        //    lastSpawnTime = Time.time;
        //    timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        //    float yPos = Random.Range(yMin, yMax);

        //    //사용할 현재 순번의 발판 게임 오브젝트를 비활성화 하고 즉시 다시 활성화 
        //    // 이떄 발판의 platform 컴포먼트의 OnEnable 메서드가 실행됨
        //    platforms[currentIndex].SetActive(false);
        //    platforms[currentIndex].SetActive(true);

        //    platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

        //    currentIndex++;
        //    if (currentIndex >= count)
        //    {
        //        currentIndex = 0;
        //    }
        //}
    }
}