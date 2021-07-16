using System.Collections.Generic;
using Asteroids.Core;
using Newtonsoft.Json;
using UnityEngine;

public class SaveModel : ISaveModel
{
    public void Set<T>(string key, T value)
    {
        PlayerPrefs.SetString(key,JsonConvert.SerializeObject(value));
    }

    public T Get<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return             JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(key));
        }
        else
        {
            return default;
        }
    }
    
    public List<T> GetList<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return JsonConvert.DeserializeObject<List<T>>(PlayerPrefs.GetString(key));
        }
        else
        {
            return new List<T>();
        }
    }
}