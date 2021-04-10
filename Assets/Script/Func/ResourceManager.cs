using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
namespace EveryFunc {

    //资源管理器
    public class ResourceManager {
        private static Dictionary<string, string> configMap;
        //作用：初始的静态数据成员
        //时机：类被加载时执行一次
        static ResourceManager () {
            //加载ConfigMap.txt文件
            string fileContent = GetConfigFile ();

            //解析文件
            BuildMap (fileContent);
        }
        public static string GetConfigFile () {
            //ConfigMap.txt
            //加载到本地 url为路径
            string url = "file://" + Application.streamingAssetsPath + "/ConfigMap.txt";
            //用UnityWebRequest加载文件
            UnityWebRequest www = UnityWebRequest.Get (url);
            www.SendWebRequest ();
            return www.downloadHandler.text;
        }
        private static void BuildMap (string fileContent) {
            //解析文件 将文件名和文件路径分开保存，形成字典
            configMap = new Dictionary<string, string> ();
            foreach (string str in fileContent.Split ('\n')) {
                if (str != "") {
                    string fileName = str.Split ('=') [0];
                    string filePath = str.Split ('=') [1];
                    filePath=filePath.Remove(filePath.Length-1);//删除末尾的空值
                    configMap.Add (fileName, filePath);
                }
            }
        }
        public static T Load<T> (string prefabName) where T : UnityEngine.Object {
            //加载资源 从prefab名转化成路径名
            //prefabName -> prefabPath
            string prefabPath = configMap[prefabName];
            return Resources.Load<T> (prefabPath);
        }
    }
}