using System;
using System.Collections;
using System.Collections.Generic;
using EveryFunc;
using UnityEngine;
public class GameObjectPool : MonoSingleton<GameObjectPool> {
    //对象池
    //字典：对象映射
    private Dictionary<string, List<GameObject>> cache = new Dictionary<string, List<GameObject>> ();
    public GameObject CreateObject (string key, GameObject prefab, Vector3 pos, Quaternion rot) {
        //创建对象：没有该对象就新建，有该对象就调用
        GameObject target = null;
        target = FindUsableObject (key);
        if (target == null) {
            target = AddObject (key, prefab);
        }
        UseObject (ref target, pos, rot);
        //对象属性初始化
        foreach (var i in target.GetComponents<IResetable> ()) {
            i.OnReset ();
        }
        return target;
    }
    //
    public GameObject FindUsableObject (string key) {
        //查找是否有能用的对象
        if (cache.ContainsKey (key)) {
            return cache[key].Find (g => !g.activeInHierarchy);
        }
        return null;
    }
    public GameObject AddObject (string key, GameObject prefab) {
        //添加对象
        GameObject gameObject = Instantiate (prefab);
        if (!cache.ContainsKey (key)) cache.Add (key, new List<GameObject> ());
        cache[key].Add (gameObject);
        return gameObject;
    }
    public void UseObject (ref GameObject ob, Vector3 pos, Quaternion rot) {
        //对象基础数值初始化
        ob.transform.position = pos;
        ob.transform.rotation = rot;
        ob.SetActive (true);
    }
    public void CollectObject (GameObject go, float delay = 0) {
        //回收对象
        StartCoroutine (CollectObjectDelay (go, delay));
    }
    private IEnumerator CollectObjectDelay (GameObject gameObject, float delay) {
        //delay秒后回收该对象
        yield return new WaitForSeconds (delay);
//        Debug.Log ("delay:" + delay);
        gameObject.SetActive (false);
    }
    public void ClearKey (string key) {
        //清空特定对象
        foreach (GameObject gameObject in cache[key]) {
            Destroy (gameObject);
        }
        cache.Remove (key);
    }
    public void ClearAll () {
        //清空全部对象
        List<string> stringList = new List<string> (cache.Keys);
        foreach (string key in stringList) {
            ClearKey (key);
        }
    }
}