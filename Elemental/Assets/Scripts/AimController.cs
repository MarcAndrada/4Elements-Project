using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AimController : MonoBehaviour
{
    public float fireRate;

    [Header("Fire")]
    public GameObject Fire;
    public float FireFirerate;
    private GameObject fireChildren;
    public GameObject FireHighlighted;
    public GameObject FireCircle;
    private float FirecircleValue = 1;
    private float timePassedFireCircle;
    [Header("Water")]
    public GameObject Water;
    public float WaterFirerate;
    public GameObject WaterHighlighted;
    public GameObject WaterCircle;
    private float WatercircleValue = 1;
    private float timePassedWaterCircle;

    [Header("Wind")]
    public GameObject Wind;
    public GameObject WindUp;
    public float WindFirerate;
    public GameObject WindHighlighted;
    public GameObject WindCircle;
    private float WindcircleValue = 1;
    private float timePassedWindCircle;

    [Header("Earth")]
    public GameObject Earth;
    public float EarthFirerate;
    public GameObject EarthHighlighted;
    public GameObject EarthCircle;
    private float EarthcircleValue = 1;
    private float timePassedEarthCircle;

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


    private float TimeToShoot;
    private float FireCD;
    private float WindCD;
    private float WaterCD;
    private float EarthCD;

    private float TimeToPassCircle = 0.1f;


    private enum Elements { FIRE, EARTH, WATER, WIND };
    private Elements CurrentElement;

    // Start is called before the first frame update
    void Start()
    {
        CurrentElement = Elements.FIRE;
        FireHighlighted.SetActive(true);
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
            CurrentElement = Elements.FIRE;
            FireHighlighted.SetActive(true);
            WaterHighlighted.SetActive(false);
            WindHighlighted.SetActive(false);
            EarthHighlighted.SetActive(false);

        }
        else if (PlayerInput.Water)
        {
            CurrentElement = Elements.WATER;
            WaterHighlighted.SetActive(true);
            FireHighlighted.SetActive(false);
            WindHighlighted.SetActive(false);
            EarthHighlighted.SetActive(false);

        }
        else if (PlayerInput.Wind)
        {
            CurrentElement = Elements.WIND;
            WindHighlighted.SetActive(true);
            FireHighlighted.SetActive(false);
            WaterHighlighted.SetActive(false);
            EarthHighlighted.SetActive(false);

        }
        else if (PlayerInput.Earth)
        {
            CurrentElement = Elements.EARTH;
            EarthHighlighted.SetActive(true);
            FireHighlighted.SetActive(false);
            WaterHighlighted.SetActive(false);
            WindHighlighted.SetActive(false);

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

                            FirecircleValue = 1;
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

                            EarthcircleValue = 1;
                            EarthCD = 0;
                        }
                        break;

                    case Elements.WATER:

                        if (WaterCD >= WaterFirerate)
                        {
                            Instantiate(Water, transform.position, Quaternion.identity);
                            WatercircleValue = 1;
                            WaterCD = 0;
                        }
                        break;
                    case Elements.WIND:

                        if (WindCD >= WindFirerate)
                        {
                            GameObject CurrentWind = Wind;
                            SpriteRenderer WindSprite;

                            if (PlayerInput.ShootDown || PlayerInput.ShootUp){
                                CurrentWind = WindUp;
                                

                            }else if (PlayerInput.ShootLeft || PlayerInput.ShootRight){ 
                                CurrentWind = Wind;
                                
                            }

                            AnguloRot1 = transform.rotation * Quaternion.Euler(0, 0, 10);
                            AnguloRot2 = transform.rotation;
                            AnguloRot3 = transform.rotation * Quaternion.Euler(0, 0, -10);
                            wind1 = Instantiate(CurrentWind, pos, AnguloRot1);
                            Destroy(wind1, 1.3f);
                            wind2 = Instantiate(CurrentWind, pos, AnguloRot2);
                            Destroy(wind2, 1.3f);
                            wind3 = Instantiate(CurrentWind, pos, AnguloRot3);
                            Destroy(wind3, 1.3f);

                            if (PlayerInput.ShootDown)
                            {
                                WindSprite = wind1.GetComponent<SpriteRenderer>();
                                WindSprite.flipY = true;

                                WindSprite = wind2.GetComponent<SpriteRenderer>();
                                WindSprite.flipY = true;

                                WindSprite = wind3.GetComponent<SpriteRenderer>();
                                WindSprite.flipY = true;

                            }
                            else if (PlayerInput.ShootLeft)
                            {
                                WindSprite = wind1.GetComponent<SpriteRenderer>();
                                WindSprite.flipX = true;

                                WindSprite = wind2.GetComponent<SpriteRenderer>();
                                WindSprite.flipX = true;

                                WindSprite = wind3.GetComponent<SpriteRenderer>();
                                WindSprite.flipX = true;
                            }


                            WindcircleValue = 1;
                            WindCD = 0;
                        }
                        
                        break;

                    default:
                        break;
                }

               

                TimeToShoot = 0;
                SoundManager.PlaySound("Attack");
            }
        }

        if (FirecircleValue >= 0)
        {
            timePassedFireCircle += Time.deltaTime;

            if (timePassedFireCircle >= TimeToPassCircle)
            {
                FirecircleValue -= 0.022f;
                timePassedFireCircle = 0;
            }
            FireCircle.GetComponent<Image>().fillAmount = FirecircleValue;
        }

        if (WatercircleValue >= 0)
        {
            timePassedWaterCircle += Time.deltaTime;

            if (timePassedWaterCircle >= TimeToPassCircle)
            {
                WatercircleValue -= 0.025f;
                timePassedWaterCircle = 0;            
            }
            WaterCircle.GetComponent<Image>().fillAmount = WatercircleValue;

        }

        if (WindcircleValue >= 0)
        {
            timePassedWindCircle += Time.deltaTime;

            if (timePassedWindCircle >= TimeToPassCircle)
            {
                WindcircleValue -= 0.05f;
                timePassedWindCircle = 0;
            }
            WindCircle.GetComponent<Image>().fillAmount = WindcircleValue;

        }

        if (EarthcircleValue >= 0)
        {
            timePassedEarthCircle += Time.deltaTime;

            if (timePassedEarthCircle >= TimeToPassCircle)
            {
                EarthcircleValue -= 0.014f;
                timePassedEarthCircle = 0;
            }
            EarthCircle.GetComponent<Image>().fillAmount = EarthcircleValue;

        }

    }
}
