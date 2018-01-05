using UnityEngine;
using System.Collections;

public class DB_Client : MonoBehaviour {
    public static int Player_num = 2;

    void Start()
    {
        SqliteDatabase sqlDB = new SqliteDatabase("player_log.db");
        #if UNITY_EDITOR
            sqlDB.ExecuteNonQuery("delete from chara");
        #endif
    }

    public int get_chara_num(int player_id)//キャラデータ数取得
    {
        SqliteDatabase sqlDB = new SqliteDatabase("player_log.db");
        string query = "select count(id) from chara where player = player_id";
        query = query.Replace("player_id", player_id.ToString());
        DataTable dataTable = sqlDB.ExecuteQuery(query);
        int num = (int)dataTable[0]["count(id)"];
        return num;
    }

    public int afresh(int player_id)//新規chara作成＆キャラID取得
    {
        SqliteDatabase sqlDB = new SqliteDatabase("player_log.db");
        int chara_id = get_chara_num(player_id) + 1;
        string query = "insert into chara(player, num) values(player_id, chara_id)";
        query = query.Replace("player_id", player_id.ToString());
        query = query.Replace("chara_id", chara_id.ToString());
        sqlDB.ExecuteNonQuery(query);

        return get_id(player_id, chara_id);
    }

    public int get_id(int player_id, int chara_id)//キャラID取得
    {
        SqliteDatabase sqlDB = new SqliteDatabase("player_log.db");
        string query = "select id from chara where player = player_id and num = chara_id";
        query = query.Replace("player_id",player_id.ToString());
        query = query.Replace("chara_id", chara_id.ToString());
        DataTable dataTable = sqlDB.ExecuteQuery(query);
        return (int)dataTable[0]["id"];
    }
}