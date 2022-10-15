using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int GameStage;
    public int MaxEnemies;
    public List<List<GameObject>> RoomList;
    private GameObject enemies;
    [SerializeField] private List<GameObject> Room1;
    [SerializeField] private List<GameObject> Room2;
    [SerializeField] private List<GameObject> Room3;
    [SerializeField] private List<GameObject> Room4;
    [SerializeField] private float _spawntimer;
    private void Start()
    {
        enemies = GameObject.Find("Enemies");
        RoomList = new List<List<GameObject>>();
        RoomList.Add(Room1);
        RoomList.Add(Room2);
        RoomList.Add(Room3);
        RoomList.Add(Room4);
    }
    void Update()
    {
        Spawner();
    }
    public void Spawner()
    {
        if (enemies.transform.childCount < MaxEnemies)
            switch (GameStage)
        {
            case 1:
                if (_spawntimer <= 0)
                {
                    int rndSpawn = Random.Range(0, 3);
                    // first stage default room is 0
                    Instantiate(Enemy,RoomList[0][rndSpawn].transform.position,Quaternion.identity, enemies.transform);
                    _spawntimer = 3f;
                }
                else
                    _spawntimer -= Time.deltaTime;
                break;
            case 2:
                if (_spawntimer <= 0)
                {
                    int rndSpawn = Random.Range(0, 3);
                    int rndRoom = Random.Range(0, 2);
                    Instantiate(Enemy, RoomList[rndRoom][rndSpawn].transform.position, Quaternion.identity,enemies.transform);
                    _spawntimer = 3f;
                }
                else
                    _spawntimer -= Time.deltaTime;
                break;
            case 3:
                if (_spawntimer <= 0)
                {
                    int rndSpawn = Random.Range(0, 3);
                    int rndRoom = Random.Range(0, 3);
                    Instantiate(Enemy, RoomList[rndRoom][rndSpawn].transform.position, Quaternion.identity,enemies.transform);
                    _spawntimer = 3f;
                }
                else
                    _spawntimer -= Time.deltaTime;
                break;
            case 4:
                if (_spawntimer <= 0)
                {
                    int rndSpawn = Random.Range(0, 3);
                    int rndRoom = Random.Range(0, 4);
                    Instantiate(Enemy, RoomList[rndRoom][rndSpawn].transform.position, Quaternion.identity,enemies.transform);
                    _spawntimer = 3f;
                }
                else
                    _spawntimer -= Time.deltaTime;
                break;
            default:
                if (_spawntimer <= 0)
                {
                    int rndSpawn = Random.Range(0, 3);
                    Instantiate(Enemy, RoomList[0][rndSpawn].transform.position, Quaternion.identity,enemies.transform);
                    _spawntimer = 3f;
                }
                else
                    _spawntimer -= Time.deltaTime;
                break;
        }
    }
}
