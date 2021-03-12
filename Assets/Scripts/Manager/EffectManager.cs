using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringToParticleSystem : SerializableDictionary<string, ParticleSystem> { }

public class EffectManager : Singleton<EffectManager>
{
    
    public StringToParticleSystem dictEffectPrefabs = new StringToParticleSystem();

    private Dictionary<string, List<ParticleSystem>> dictEffects = new Dictionary<string, List<ParticleSystem>>();

    private void Awake()
    {
        foreach(var obj in dictEffectPrefabs)
        {
            ParticleSystem temp = Instantiate(obj.Value, Vector3.zero, Quaternion.identity);
            temp.Stop();
            var list = new List<ParticleSystem>();
            list.Add(temp);
            dictEffects.Add(obj.Key, list);
        }
    }

    public ParticleSystem GetEffectToString(string _strName)
    {
        ParticleSystem result = null;

        List<ParticleSystem> list;

        dictEffects.TryGetValue(_strName, out list);

        foreach (var effect in list)
        {
            if (effect.isPlaying == false)
            {
                result = effect;
                break;
            }
        }

        if (result == null)
        {
            result = CreateEffect(_strName);
        }

        return result;
    }

    List<ParticleSystem> GetParticleSystems(string _strName)
    {
        List <ParticleSystem> result = null;
        dictEffects.TryGetValue(_strName, out result);

        return result;
    }

    ParticleSystem CreateEffect(string _strName)
    {
        ParticleSystem result = null;

        ParticleSystem temp = null;
        dictEffectPrefabs.TryGetValue(_strName, out temp);

        if(temp != null)
        {
            result = Instantiate(temp, Vector3.zero, Quaternion.identity);

            var list = GetParticleSystems(_strName);
            list.Add(result);
        }

        return result;
    }


}
