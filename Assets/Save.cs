using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //用于文件的读写
using System.Runtime.Serialization.Formatters.Binary; //用于创建二进制格式化程序

[System.Serializable]
public class Save
{
    public List<int> activeMonsterPosition = new List<int>();
    public List<int> activeMonsterType = new List<int>();

    public int shootNum;
    public int score;


    private void SaveByBin()
    {
        //创建存储类对象
        Save save = new Save();
        //创建二进制格式化程序
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //创建文件流（create参数为存储路径，注意路径前的"/"以及标明文件名称和格式）
        FileStream fileStream = File.Create(Application.dataPath + "/StreamingFile" + "/byBin.txt");
        //用二进制格式化程序的序列化方法来序列化save对象 
        binaryFormatter.Serialize(fileStream, save);
        //关闭文件流
        fileStream.Close();
    }


    private void LoadByBin()
    {
        if (File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt")) //检测是否存在读档信息
        {
            //创建二进制格式化程序
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //创建文件流打开读档信息
            FileStream fileStream = File.Open(Application.dataPath + "/StreamingFile" + "/byBin.txt", FileMode.Open);
            //调用二进制格式化程序的反序列化方法，将文件流转化为Save对象
            Save save = (Save)binaryFormatter.Deserialize(fileStream); //返回值为object类型，需要强制转换为需要的类型
            //关闭文件流
            fileStream.Close();
            //将读取到的游戏属性设置为游戏当前属性（根据游戏需要自行编写）
        }
    }

}
