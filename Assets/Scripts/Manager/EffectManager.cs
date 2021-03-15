using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StringToParticleSystem : SerializableDictionary<string, ParticleSystem> { }

public enum E_CAMERA_ANIM_EFFECT_TYPE
{
    NONE,
    BOOL,
    TRIGGER
}

public class EffectManager : Singleton<EffectManager>
{
    
    public StringToParticleSystem dictEffectPrefabs = new StringToParticleSystem();

    private Dictionary<string, List<ParticleSystem>> dictEffects = new Dictionary<string, List<ParticleSystem>>();

    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        foreach (var obj in dictEffectPrefabs)
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

    public void CameraAnimEffect(string _strName, E_CAMERA_ANIM_EFFECT_TYPE _type, bool _active = true)
    {
        var _animCam = camera.GetComponent<Animator>();

        if (_animCam == null)
            return;

        switch (_type)
        {
            case E_CAMERA_ANIM_EFFECT_TYPE.BOOL:
                {
                    _animCam.SetBool(_strName, _active);
                }
                break;
            case E_CAMERA_ANIM_EFFECT_TYPE.TRIGGER:
                {
                    _animCam.SetTrigger(_strName);
                }
                break;
            default:
                break;
        }

    }
}
