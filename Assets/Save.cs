using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; //�����ļ��Ķ�д
using System.Runtime.Serialization.Formatters.Binary; //���ڴ��������Ƹ�ʽ������

[System.Serializable]
public class Save
{
    public List<int> activeMonsterPosition = new List<int>();
    public List<int> activeMonsterType = new List<int>();

    public int shootNum;
    public int score;


    private void SaveByBin()
    {
        //�����洢�����
        Save save = new Save();
        //���������Ƹ�ʽ������
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //�����ļ�����create����Ϊ�洢·����ע��·��ǰ��"/"�Լ������ļ����ƺ͸�ʽ��
        FileStream fileStream = File.Create(Application.dataPath + "/StreamingFile" + "/byBin.txt");
        //�ö����Ƹ�ʽ����������л����������л�save���� 
        binaryFormatter.Serialize(fileStream, save);
        //�ر��ļ���
        fileStream.Close();
    }


    private void LoadByBin()
    {
        if (File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt")) //����Ƿ���ڶ�����Ϣ
        {
            //���������Ƹ�ʽ������
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //�����ļ����򿪶�����Ϣ
            FileStream fileStream = File.Open(Application.dataPath + "/StreamingFile" + "/byBin.txt", FileMode.Open);
            //���ö����Ƹ�ʽ������ķ����л����������ļ���ת��ΪSave����
            Save save = (Save)binaryFormatter.Deserialize(fileStream); //����ֵΪobject���ͣ���Ҫǿ��ת��Ϊ��Ҫ������
            //�ر��ļ���
            fileStream.Close();
            //����ȡ������Ϸ��������Ϊ��Ϸ��ǰ���ԣ�������Ϸ��Ҫ���б�д��
        }
    }

}
