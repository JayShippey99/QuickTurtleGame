using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurtleMove : MonoBehaviour
{
    public Rigidbody rb;
    public float boostAmount;
    float boostA;
    public float boostPower;
    public float power;
    public float powerGainAmount;
    public float powerLimit;
    bool shot;
    bool shoot;

    public int turns;
    public int turnNumber;


    Vector3 startPos;

    public float shootBuffer;
    float shootb;

    bool checkToReset;

    public int points;
    public int totalPoints;

    public TextMeshProUGUI scoreText;

    public GameObject booster;
    public GameObject boostFire;
    void Start()
    {
        startPos = transform.position;
        boostA = boostAmount;
    }

    // Update is called once per frame
    void Update()
    {
        print(shot);
        if (Input.GetMouseButton(0) && !shot)
        {
            power += Time.deltaTime * powerGainAmount;

            if (power > powerLimit) power = powerLimit; 
        }

        if (Input.GetMouseButtonUp(0) && !shot)
        {
            shoot = true;
            shootb = shootBuffer;
        }

        if (!shot)
        {
            transform.position = startPos + Mathf.Cos(Time.time) * Vector3.right * 2;
        }

        if (shot) shootb -= Time.deltaTime;

        if (shootb <= 0) checkToReset = true;

        // need to get world to screen point of turtle, and mouse position, get the angle to the mouse position and hten set the y rotation of the booster to that?
        Vector3 cPos = Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(Input.mousePosition.y - cPos.y, cPos.x - Input.mousePosition.x);

        booster.transform.rotation = Quaternion.Euler(0, (Mathf.Rad2Deg * angle), 0);
    }


    private void FixedUpdate()
    {
        if (shot && Input.GetMouseButton(0) && boostA > 0)
        {
            Vector3 cPos = Camera.main.WorldToScreenPoint(transform.position);
            float angle = Mathf.Atan2(Input.mousePosition.y - cPos.y, Input.mousePosition.x - cPos.x);

            rb.AddForce(new Vector3(Mathf.Cos(angle) * boostPower, 0, Mathf.Sin(angle) * boostPower));

            boostA -= Time.deltaTime;
            print(boostA);
            boostFire.SetActive(true);
        }
        else
        {
            boostFire.SetActive(false);
        }

        if (rb.velocity.magnitude < .1 && shot && checkToReset)
        {
            Return();
        }

        if (shoot)
        {
            shoot = false;
            shot = true;
            rb.AddForce(Vector3.forward * power);
            rb.AddTorque(Vector3.up * power / 10f);
        }
    }

    void Return()
    {
        transform.rotation = Quaternion.Euler(new Vector3(-90, 0, -90));
        GetPoints();
        checkToReset = false;
        power = 0;
        shot = false;
        transform.position = startPos;
        boostA = boostAmount;
        turnNumber++;

        if (turnNumber > turns)
        {
            print("game over");
        }
    }

    void GetPoints()
    {
        points = 0;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, GetComponent<CapsuleCollider>().radius);
        foreach (var hitCollider in hitColliders)
        {
            print(hitCollider.name);
            if (hitCollider.GetComponent<PointsRing>() != null)
            {
                if (points < hitCollider.GetComponent<PointsRing>().points) points = hitCollider.GetComponent<PointsRing>().points;
            }
        }
        AddToPoints();
    }
    
    void AddToPoints()
    {
        totalPoints += points;
        scoreText.text = "Points: " + totalPoints;
    }
}
