using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class TimeData
{
    public float HighScore = 1000000000000000000;
    public float NowScore = 0;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public TimeData nowTime = new TimeData();
    string path;
    string filename = "save";

    void Awake()
    {
        #region 싱글톤
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/";
        print(path);
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowTime);
        print(path);
        File.WriteAllText(path+filename,data);
    }
    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);
        nowTime = JsonUtility.FromJson<TimeData>(data);
    }
}
