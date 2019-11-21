using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static bool start;
     public Canvas verj;
     CanvasGroup vj;
     public Canvas skizb;
     CanvasGroup sk;
     public Transform SharParent;
     AudioSource qceluDzen;
     AudioSource xndal;
     AudioSource fonMuz;
     GUIStyle myStayl;
     GUIStyle good;
     public static int player;
     static public GameObject key;
     static public GameObject key2;
     public static bool ki1;
     public static bool ki2;
     int a;
     int b;
     static public bool kiUdar;
     static public bool sharjumChka;
     public bool fadingSkAlpha = false;
     public bool fadingVjAlpha = false;
     public bool fadingVjAlphaNewGame = false;
     float t;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.Find("Key").gameObject;
        key2=GameObject.Find("Key2").gameObject;
        myStayl = new GUIStyle();
        good = new GUIStyle();
        AudioSource[] zvuki = GetComponents<AudioSource>();
        qceluDzen = GetAudioSourceArrayByName(zvuki, "sharVluzu");
        xndal = GetAudioSourceArrayByName(zvuki, "xndal");
        fonMuz = GetAudioSourceArrayByName(zvuki, "melodia");
        vj=verj.GetComponent<CanvasGroup>();
         sk = skizb.GetComponent<CanvasGroup>();

        player=Random.Range(1, 3);
        if (player == 1) 
        {
            key.GetComponent<Key>().enabled = true;
            key2.GetComponent<Key2>().enabled = false;
            ki1 = true;
            ki2 = false;
        }
        if (player == 2) 
        {
            key.GetComponent<Key>().enabled = false;
            key2.GetComponent<Key2>().enabled = true;
            ki2 = true;
            ki1 = false;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (!fonMuz.isPlaying)
            {
                fonMuz.Play();
            }

        }
        else
            fonMuz.Stop();
        if (fadingVjAlpha) 
        {


            vj.alpha = vj.alpha- 0.03f;
            skizb.gameObject.SetActive(true);
            if (vj.alpha <= 0)
            {

                fadingVjAlpha = false;
                vj.alpha = 0;
                verj.gameObject.SetActive(false);
                MenuInits();

            }

        }
        if (fadingVjAlphaNewGame)
        {


            vj.alpha -= 0.03f;
            if (vj.alpha <= 0)
            {


                vj.alpha = 0;
                verj.gameObject.SetActive(false);
                skizb.gameObject.SetActive(false);
                fadingVjAlphaNewGame = false; 
                //MenuInits();

            }

        }


        if (fadingSkAlpha) 
        {
            sk.alpha -= 0.03f;
            if (sk.alpha <= 0) 
            {
                fadingSkAlpha = false;
                sk.alpha = 0;
                skizb.gameObject.SetActive(false);
                StartInits();
            }
        }


        if (kiUdar)
        {

            if (SharjumKa())
            {

            }
            else
            {

                sharjumChka = true;
                
            }
        }
            if (sharjumChka )
                if( Key.ki1XphecN > Shar.ki1qcacSharN)
            {
                key.transform.position = new Vector3(8, 2, 6);
                key.transform.eulerAngles = new Vector3(0, 0, 90);
                key.GetComponent<Key>().enabled = false;
                key2.GetComponent<Key2>().enabled = true;
                ki2 = true;
                ki1 = false;
                player = 2;
                Key.ki1XphecN = Shar.ki1qcacSharN;
                kiUdar = false;
                sharjumChka = false;
                xndal.Play();

            }
            if (sharjumChka )
                if(Key2.ki2XphecN > Shar.ki2qcacSharN)
            {
                key2.transform.position = new Vector3(20, 2, 6);
                key2.transform.eulerAngles = new Vector3(0, 0, 90);
                key2.GetComponent<Key2>().enabled = false;
                key.GetComponent<Key>().enabled = true;
                ki1 = true;
                ki2 = false;
                player = 1;
                Key2.ki2XphecN = Shar.ki2qcacSharN;
                kiUdar = false;
                sharjumChka = false;
                xndal.Play();
            }
        

        
  
        if (Shar.xphec) 
            {
                qceluDzen.Play();
                Shar.xphec = false;
            }

        if (Shar.ki1qcacSharN+Shar.ki2qcacSharN == 7)
        {
            Shar.GuiGood = false;
            vj.alpha = 1;
            sk.alpha = 0;
            verj.gameObject.SetActive(true);
            start = false;
            Shar.ki1qcacSharN = 0;
            Shar.ki2qcacSharN = 0;

        }
        if(Input.GetKeyDown(KeyCode.A))
        {

            vj.alpha = 1;
            sk.alpha = 0;
            verj.gameObject.SetActive(true);
            start = false;
        }


    }
    bool SharjumKa()
    {
        for (int i = 0; i < SharParent.childCount; i++)
        {
            float v = SharParent.GetChild(i).GetComponent<Rigidbody>().velocity.magnitude;
            if (v > 0.1f)
            {
                return true;
            }
        }
        return false;


    }
    public void StartXax()
    {
        start = true;
        fadingSkAlpha = true;
        fadingVjAlpha = false;
        verj.gameObject.SetActive(false);
       
    }
    void StartInits()
    {
            start = true;
            sk.alpha=0;
            vj.alpha = 0;
            
    }
    public void StartMenu() 
    {

        start = false;
        fadingVjAlpha = true;
        fadingSkAlpha = false;
            sk.alpha=1;
    }
    void MenuInits()
    {

            vj.alpha = 0;
            sk.alpha = 1;

    }
    public void NewGame() 
    {

        start = true;
        fadingSkAlpha = false;
        fadingVjAlpha = false;
        fadingVjAlphaNewGame = true;
    }

    public void OnGUI() 
    {
        if (start)
        {
            if (player == 1)
            {
                myStayl.normal.textColor = Color.green;
                GUI.Label(new Rect(Screen.width / 2, 2, 100, 20), "PLAYER 1  ", myStayl);
                GUI.Label(new Rect(Screen.width * 2 / 3, 2, 100, 20), "PLAYER 2  ");
            }
            if (player == 2)
            {
                myStayl.normal.textColor = Color.green;
                GUI.Label(new Rect(Screen.width / 2, 2, 100, 20), "PLAYER 1  ");
                GUI.Label(new Rect(Screen.width * 2 / 3, 2, 100, 20), "PLAYER 2  ", myStayl);
            }
        }
        if (Shar.GuiGood) 
        {
            t+=Time.deltaTime;
            good.normal.textColor=Color.red;
            good.fontSize = 50;
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2,0,0 ), " GOOD!!!", good);
            if (t > 3)
            {
                Shar.GuiGood = false;
                t = 0;
            }
        }

    }
    AudioSource GetAudioSourceArrayByName(AudioSource[] array, string name) 
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].clip.name == name)
                return array[i];
        }
        return null;
    }

}
