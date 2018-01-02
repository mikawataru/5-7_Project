using UnityEngine;
using System.Collections;

public class DB_Client : MonoBehaviour {
    private SqliteDatabase sqlDB = new SqliteDatabase("player_log.db");
    private int Data_id;
    private int Player_num, Chara_num;

    DB_Client(int player_num, int chara_num){
        Player_num = player_num;
        Chara_num = chara_num;
    }

    public void afresh(){
        string query = "insert chara(player, num) values({Player_num}, {Chara_num})";
        sqlDB.ExecuteNonQuery(query);
        query = "select id from chara where player = {Player_num} and num = {Chara_num}";
        DataTable dataTable = sqlDB.ExecuteQuery(query);
        Data_id = (int)dataTable[0]["id"];
        Debug.Log(Data_id);
    }

    public void begin(){
        string query = "select id from chara where player = {Player_num} and num = {Phara_num}";
        DataTable dataTable = sqlDB.ExecuteQuery(query);
        Data_id = (int)dataTable[0]["id"];
        Debug.Log(Data_id);
    }
}