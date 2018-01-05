using UnityEngine;
using System.Collections;


public class DBtest : MonoBehaviour {
    GameObject DB_Manager;
    DB_Client DB;

    const int CHARA_ID = 1;
    int Frame_id = 0;

    void Start () {
        DB_Manager = GameObject.Find("Database_Manager");
        DB = DB_Manager.GetComponent<DB_Client>();

        int player_id = 1;
        Debug.Log(DB.get_chara_num(player_id));
        Debug.Log(DB.afresh(player_id));
        Debug.Log(DB.get_chara_num(player_id));
        player_id += 1;
        Debug.Log(DB.afresh(player_id));
        Debug.Log(DB.get_chara_num(player_id));
    }

    // Update is called once per frame
    void Update () {
	}
}
