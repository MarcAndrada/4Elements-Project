using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AimController : MonoBehaviour
{
    public GameObject Fire;
    public GameObject Water;
    public GameObject Wind;
    public GameObject Earth;
    public float fireRate;
    public float FireFirerate;
    public float WaterFirerate;
    public float WindFirerate;
    public float EarthFirerate;
    public Image CurrentElementHUD;
    private Quaternion AnguloRot1;
    private Quaternion AnguloRot2;
    private Quaternion AnguloRot3;
    private Quaternion AnguloRot4;
    private Quaternion AnguloRot5;
    private Quaternion AnguloRot6;
    private Quaternion AnguloRot7;
    private Quaternion AnguloRot8;
    private Quaternion AnguloRot9;
    private Quaternion AnguloRot10;
    private Quaternion AnguloRot11;
    private Quaternion AnguloRot12;
    private Quaternion AnguloRot13;
    private Quaternion AnguloRot14;
    private Quaternion AnguloRot15;
    private Quaternion AnguloRot16;
    private Quaternion AnguloRot17;
    private Quaternion AnguloRot18;

    private GameObject wind1;
    private GameObject wind2;
    private GameObject wind3;
    private GameObject rock1;
    private GameObject rock2;
    private GameObject rock3;
    private GameObject rock4;
    private GameObject rock5;
    private GameObject rock6;
    private GameObject rock7;
    private GameObject rock8;
    private GameObject rock9;
    private GameObject rock10;
    private GameObject rock11;
    private GameObject rock12;
    private GameObject rock13;
    private GameObject rock14;
    private GameObject rock15;
    private GameObject rock16;
    private GameObject rock17;
    private GameObject rock18;

    private GameObject fireChildren;

    private Color FireColor = new Color(0.81f,0.42f,0.05f);
    private Color EarthColor = new Color(0.36f, 0.19f, 0.01f);
    private Color WaterColor = new Color(0.09f, 0.48f, 0.85f);
    private Color WindColor = new Color(0.57f, 0.75f, 0.75f);

    private float TimeToShoot;
    private float FireCD;
    private float WindCD;
    private float WaterCD;
    private float EarthCD;

    private enum Elements { FIRE, EARTH, WATER, WIND };
    private Elements CurrentElement;

    // Start is called before the first frame update
    void Start()
    {
        CurrentElement = Elements.FIRE;
        CurrentElementHUD.color = FireColor;

    }

    // Update is called once per frame
    void Update()
    {

        float delta = Time.deltaTime * 1000;

        
        Vector3 pos = transform.position;

        TimeToShoot += delta;
        FireCD += delta;
        WindCD += delta;
        WaterCD += delta;
        EarthCD += delta;


        if (PlayerInput.Fire)
        {
            CurrentElementHUD.color = FireColor;
            CurrentElement = Elements.FIRE;
        }
        else if (PlayerInput.Water)
        {
            CurrentElementHUD.color = WaterColor;
            CurrentElement = Elements.WATER;
        }
        else if (PlayerInput.Wind)
        {
            CurrentElementHUD.color = WindColor;
            CurrentElement = Elements.WIND;
        }
        else if (PlayerInput.Earth)
        {
            CurrentElementHUD.color = EarthColor;
            CurrentElement = Elements.EARTH;
        }

        if (PlayerInput.ShootDown || PlayerInput.ShootUp || PlayerInput.ShootRight || PlayerInput.ShootLeft)
        {
            if (TimeToShoot > fireRate)
            {
                switch (CurrentElement)
                {
                    case Elements.FIRE:
                        if (FireCD >= FireFirerate)
                        {
                            if (PlayerInput.ShootDown)
                            {
                                fireChildren = Instantiate(Fire, transform.position, transform.rotation * Quaternion.Euler(0, 0, 180));
                                fireChildren.transform.parent = gameObject.transform;

                            }
                            else if (PlayerInput.ShootUp)
                            {
                                fireChildren = Instantiate(Fire, transform.position, Quaternion.identity);
                                fireChildren.transform.parent = gameObject.transform;
                            }
                            else if (PlayerInput.ShootRight)
                            {
                                fireChildren = Instantiate(Fire, transform.position, transform.rotation * Quaternion.Euler(0, 0, 270));
                                fireChildren.transform.parent = gameObject.transform;
                            }
                            else if (PlayerInput.ShootLeft)
                            {
                                fireChildren = Instantiate(Fire, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
                                fireChildren.transform.parent = gameObject.transform;
                            }


                            FireCD = 0;


                        }
                        

                        break;

                    case Elements.EARTH:

                        if (EarthCD >= EarthFirerate)
                        {
                            Quaternion rot = transform.rotation;
                            AnguloRot1 = transform.rotation * Quaternion.Euler(0, 0, 180);
                            AnguloRot2 = transform.rotation * Quaternion.Euler(0, 0, 160);
                            AnguloRot3 = transform.rotation * Quaternion.Euler(0, 0, 140);
                            AnguloRot4 = transform.rotation * Quaternion.Euler(0, 0, 120);
                            AnguloRot5 = transform.rotation * Quaternion.Euler(0, 0, 100);
                            AnguloRot6 = transform.rotation * Quaternion.Euler(0, 0, 80);
                            AnguloRot7 = transform.rotation * Quaternion.Euler(0, 0, 60);
                            AnguloRot8 = transform.rotation * Quaternion.Euler(0, 0, 40);
                            AnguloRot9 = transform.rotation * Quaternion.Euler(0, 0, 20);
                            AnguloRot10 = transform.rotation;
                            AnguloRot11 = transform.rotation * Quaternion.Euler(0, 0, -20);
                            AnguloRot12 = transform.rotation * Quaternion.Euler(0, 0, -40);
                            AnguloRot13 = transform.rotation * Quaternion.Euler(0, 0, -60);
                            AnguloRot14 = transform.rotation * Quaternion.Euler(0, 0, -80);
                            AnguloRot15 = transform.rotation * Quaternion.Euler(0, 0, -100);
                            AnguloRot16 = transform.rotation * Quaternion.Euler(0, 0, -120);
                            AnguloRot17 = transform.rotation * Quaternion.Euler(0, 0, -140);
                            AnguloRot18 = transform.rotation * Quaternion.Euler(0, 0, -160);

                            rock1 = Instantiate(Earth, pos, AnguloRot1);
                            Destroy(rock1, 1f);
                            rock2 = Instantiate(Earth, pos, AnguloRot2);
                            Destroy(rock2, 1f);
                            rock3 = Instantiate(Earth, pos, AnguloRot3);
                            Destroy(rock3, 1f);
                            rock4 = Instantiate(Earth, pos, AnguloRot4);
                            Destroy(rock4, 1f);
                            rock5 = Instantiate(Earth, pos, AnguloRot5);
                            Destroy(rock5, 1f);
                            rock6 = Instantiate(Earth, pos, AnguloRot6);
                            Destroy(rock6, 1f);
                            rock7 = Instantiate(Earth, pos, AnguloRot7);
                            Destroy(rock7, 1f);
                            rock8 = Instantiate(Earth, pos, AnguloRot8);
                            Destroy(rock8, 1f);
                            rock9 = Instantiate(Earth, pos, AnguloRot9);
                            Destroy(rock9, 1f);
                            rock10 = Instantiate(Earth, pos, AnguloRot10);
                            Destroy(rock10, 1f);
                            rock11 = Instantiate(Earth, pos, AnguloRot11);
                            Destroy(rock11, 1f);
                            rock12 = Instantiate(Earth, pos, AnguloRot12);
                            Destroy(rock12, 1f);
                            rock13 = Instantiate(Earth, pos, AnguloRot13);
                            Destroy(rock13, 1f);
                            rock14 = Instantiate(Earth, pos, AnguloRot14);
                            Destroy(rock14, 1f);
                            rock15 = Instantiate(Earth, pos, AnguloRot15);
                            Destroy(rock15, 1f);
                            rock16 = Instantiate(Earth, pos, AnguloRot16);
                            Destroy(rock16, 1f);
                            rock17 = Instantiate(Earth, pos, AnguloRot17);
                            Destroy(rock17, 1f);
                            rock18 = Instantiate(Earth, pos, AnguloRot18);
                            Destroy(rock18, 1f);


                            EarthCD = 0;
                        }
                        break;

                    case Elements.WATER:

                        if (WaterCD >= WaterFirerate)
                        {
                            Instantiate(Water, transform.position, Quaternion.identity);
                            WaterCD = 0;
                        }
                        break;
                    case Elements.WIND:

                        if (WindCD >= WindFirerate)
                        {
                            Quaternion rot = transform.rotation;
                            AnguloRot1 = transform.rotation * Quaternion.Euler(0, 0, 10);
                            AnguloRot2 = transform.rotation;
                            AnguloRot3 = transform.rotation * Quaternion.Euler(0, 0, -10);
                            wind1 = Instantiate(Wind, pos, AnguloRot1);
                            Destroy(wind1, 1.3f);
                            wind2 = Instantiate(Wind, pos, AnguloRot2);
                            Destroy(wind2, 1.3f);
                            wind3 = Instantiate(Wind, pos, AnguloRot3);
                            Destroy(wind3, 1.3f);
                            WindCD = 0;
                        }
                        
                        break;

                    default:
                        break;
                }

               

                TimeToShoot = 0;

            }
        }
    }
}
