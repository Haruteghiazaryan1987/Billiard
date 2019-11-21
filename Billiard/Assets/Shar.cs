using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shar : MonoBehaviour {
    static public float a ;
    static public float b;
    Rigidbody rig;
    static public int ki1qcacSharN;
    static public int ki2qcacSharN;
    static public bool xphec;
    AudioSource sharinkpnel;
    AudioSource kinSharin;
    AudioSource sharypatin;
    static public Vector3 verjTex1;
    static public Vector3 verjTex2;
    public static bool GuiGood;

	
	void Start () {
        AudioSource[] zvuker = GetComponents<AudioSource>();
        sharinkpnel = GetAudioSourceFromArrayByName(zvuker, "shar@sharin");
        kinSharin = GetAudioSourceFromArrayByName(zvuker, "kiixphac");
        sharypatin = GetAudioSourceFromArrayByName(zvuker, "shar@patin 1");
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}
    public void OnTriggerEnter(Collider col)
    {
        Manager.kiUdar = false;
        if (Manager.ki1)
        {
            GuiGood = true;
            xphec = true;
            ki1qcacSharN++;
            Key.ki1XphecN = ki1qcacSharN;
            a = a + 1;
            Manager.sharjumChka = false;
            if (col.gameObject.transform.name != "Sexan")
            {

                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<SharVliz>().enabled = true;
                verjTex1 = new Vector3(9, 2, 6-a);



            }
        }
        if (Manager.ki2)
        {
            GuiGood = true;
            xphec = true;
            ki2qcacSharN++;
            Key2.ki2XphecN = ki2qcacSharN;
            b = b +1;
            Manager.sharjumChka = false;
            if (col.gameObject.transform.name != "Sexan")
            {
                gameObject.GetComponent<Rigidbody>().useGravity = false;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<SharVliz2>().enabled = true;
                verjTex2 = new Vector3(21 , 2, 6-b);
                //print(verjTex2);


            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.name=="Sexan")
            return ;
        if (col.collider.name.Contains("shar"))
            sharinkpnel. Play();
        if (col.collider.name.Contains("keycub"))
            kinSharin.Play();
        if (col.collider.name.Contains("pat"))
            sharypatin.Play();

         float m = rig.velocity.magnitude + 0.1f;
        Vector3 v = rig.velocity;
        v.Normalize();
        rig.velocity = v * m;

    }
    AudioSource GetAudioSourceFromArrayByName(AudioSource[] asArray, string name)
    {
        for (int i = 0; i < asArray.Length; i++)
        {
            if (asArray[i].clip.name == name)
                return asArray[i];
        }
        return null;
    }
}
