using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Key2 : MonoBehaviour
{
    public Canvas slider;
    public Slider uj;

    public Transform PharentShar;
    Transform sharMotik;
    Rigidbody rig;
    public static int udar = 0;
    int tx;
    int c = 0;
    CanvasGroup sl;

    public static int ki2XphecN;



    // Use this for initialization
    void Start()
    {
        sl = slider.GetComponent<CanvasGroup>();

        // slider = transform.FindChild("Canvas/Slider").gameObject;
        rig = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Manager.start)
        {


            if (Input.GetMouseButton(0))
            {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] allHit = Physics.RaycastAll(ray, 100);

                if (allHit.Length != 0)
                {
                    for (int i = 0; i < allHit.Length; i++)
                    {



                        if (allHit[i].transform.name == "Sexan")
                        {
                            sharMotik = Hamematel(allHit[i].point);
                            float dist = (allHit[i].point - sharMotik.position).magnitude;
                            if (dist > 1)
                            {

                                transform.position = new Vector3(allHit[i].point.x, allHit[i].point.y + 0.28f, allHit[i].point.z);

                                transform.LookAt(sharMotik);
                            }

                        }

                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {


                transform.LookAt(sharMotik);
                rig.velocity = transform.forward * udar;
                rig.drag = 0;
                udar = 0;
                c = 0;
                uj.value = 0;
                slider.gameObject.SetActive(false);


            }

            if (Input.GetMouseButton(1))
            {
                sl.alpha = 1;
                slider.gameObject.SetActive(true);
                int t = (int)Time.time;
                if (tx != t)
                {
                    tx = t;
                    c++;
                    udar = c * 7;
                }
                if (udar > 35)
                    udar = 35;
                uj.value = udar;
            }
        }
        
    }
    Transform Hamematel(Vector3 mouspos)
    {
        Transform veradarcnelMotik = null;
        float maxRad = 100;
        for (int i = 0; i < PharentShar.childCount; i++)
        {
            float herav = (PharentShar.GetChild(i).position - mouspos).magnitude;
            if (herav < maxRad)
            {
                maxRad = herav;
                veradarcnelMotik = PharentShar.GetChild(i);

            }
        }
        return veradarcnelMotik;
    }
    void OnCollisionEnter(Collision a)
    {
        Manager.kiUdar=true;
        //sl.alpha = 0;
        rig.drag = 10;
        ki2XphecN++;
    }


}