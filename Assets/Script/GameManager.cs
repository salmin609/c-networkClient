using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Instance already exist");
            Destroy(this);
        }
    }
    public void SpawnPlayer(int id, string userName, Vector3 position, Quaternion rotation)
    {
        Debug.Log("Instantiate player");
        GameObject player;

        if(id == Client.instance.myId)
        {
            player = Instantiate(localPlayerPrefab, position, rotation);
        }
        else
        {
            player = Instantiate(playerPrefab, position, rotation);
        }
        player.GetComponent<PlayerManager>().id = id;
        player.GetComponent<PlayerManager>().userName = userName;
        players.Add(id, player.GetComponent<PlayerManager>());        
    }
}
