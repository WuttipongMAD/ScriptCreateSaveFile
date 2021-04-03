using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

public class CreateSaveFile : MonoBehaviour
{
    StringBuilder sb = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();


    string pathText = @"/Users/bankinginverter/Desktop/test.text";
    string pathCSV = @"/Users/bankinginverter/Desktop/test.csv";
    string[] oldData = new string[] { };
    List<string> data = new List<string>() {};

    int splite = 0;

    void Start()
    {
        if(File.Exists(pathText))
        {
            oldData = File.ReadAllLines(pathText);
            string[] swapData = oldData[0].Split(',');

            foreach (var item in swapData)
            {
                splite++;
                if(splite == swapData.Length)
                {
                    splite = 0;
                    data.TrimExcess();
                }
                else
                {
                    data.Add(item);
                    Debug.Log(item);
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AddData();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            SaveFile();
        }
    }

    private void AddData()
    {
        data.Add("iOS");
    }

    private void SaveFile()
    {
        foreach (var item in data)
        {
            sb.AppendFormat("{0},", item);
        }
        File.WriteAllText(pathText, sb.ToString());

        foreach (var item in data)
        {
            sb2.AppendFormat("{0},", item);
            splite++;
            if (splite == 5)
            {
                splite = 0;
                sb2.AppendLine();
            }
        }
        File.WriteAllText(pathCSV, sb2.ToString());
    }

}
