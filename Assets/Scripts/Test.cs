using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum E_WEAPON_TYPE
{
    WEAPON_TYPE_NONE = 0,
    WEAPON_TYPE_SWARD,
    WEAPON_TYPE_BOW,
    WEAPON_TYPE_GUN,

}

public class Test : ObjectBase
{
    string name = "SWARD";

    E_WEAPON_TYPE eType = E_WEAPON_TYPE.WEAPON_TYPE_NONE;

    void SetType(int value)
    {
        eType = (E_WEAPON_TYPE)value;

        eType = OS.BitConvert.IntToEnum32<E_WEAPON_TYPE>(value);

    }

    int enumTestInt = 2;

    void foo(E_WEAPON_TYPE type)
    {

        if(OS.BitConvert.Enum32ToInt<E_WEAPON_TYPE>(type) == enumTestInt)
        {

        }

    }

    //itemManger, enemyManger...
    Dictionary<E_WEAPON_TYPE, int> dicTest = new Dictionary<E_WEAPON_TYPE, int>();

    void foo2()
    {
        var a = dicTest[E_WEAPON_TYPE.WEAPON_TYPE_NONE];

        dicTest.Add(E_WEAPON_TYPE.WEAPON_TYPE_BOW, 2);

        //위 두 행위는 박싱과 언박싱이 일어남



    }

    //enum key 딕셔너리 사용법
    OS.EnumDictionary<E_WEAPON_TYPE, int> dicTest2 =  new OS.EnumDictionary<E_WEAPON_TYPE, int>();

    void foo3()
    {
        var a = dicTest2[E_WEAPON_TYPE.WEAPON_TYPE_NONE];

        dicTest2.Add(E_WEAPON_TYPE.WEAPON_TYPE_BOW, 2);
    }


    void courutineTest1()
    {
        StartCoroutine(courutineTest2());
    }


    WaitForSeconds scd = new WaitForSeconds(4);

    IEnumerator courutineTest2()
    {
        int a = 10;

        yield return OS.YieldInstructionCache.WaitForSeconds(4);

        a = 100;

    }

    struct Info
    {
        public int idx;
        public int atk;
        public E_WEAPON_TYPE type;
        public string name;
    }

    void Start()
    {
        TableManager.Instance.Read("info_test");

        var dicInfoTest = TableManager.Instance.GetTable("info_test");

        List<Info> listInfo = new List<Info>();

        for(int i = 0; i < dicInfoTest.Count; ++i)
        {
            var info = dicInfoTest[i];

            int idx = info["idx"].GetHashCode();
            E_WEAPON_TYPE type = OS.BitConvert.IntToEnum32<E_WEAPON_TYPE>(info["type"].GetHashCode());
            int atk = info["atk"].GetHashCode();
            string name = info["name"].ToString();

            Info a;
            a.idx = idx;
            a.type = type;
            a.atk = atk;
            a.name = name;


            listInfo.Add(a);
        }


        int b = 10;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
