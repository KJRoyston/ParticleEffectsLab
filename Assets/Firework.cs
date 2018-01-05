using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float timeToDetonate;        // Time in seconds before firework detonates

    protected float timer;
    Transform leftSpawn;         // The firework will spawn along the line between leftSpan and rightSpawn
    Transform rightSpawn;            // It is generally better to base locations off of screen dimensions when possible !!!
    Transform aimTowards;        // The firework's initial velocity will point it towards this location (doesn't take into account gravity)
    [Range(0.0f, 50f)]
    public float maxAngleDeviance;      // Initial angle will be within maxAngleDeviance of pointing towards aimTowards 
    public float initialSpeedMin;       // Initial velocity will be randomly between these two values
    public float initialSpeedMax;

    protected Rigidbody2D rb;
    protected Color baseColor;

    void Start()
    {
        leftSpawn = GameObject.Find("LeftSpawn").transform;
        rightSpawn = GameObject.Find("RightSpawn").transform;
        aimTowards = GameObject.Find("AimTowards").transform;

        selectRandomColor();

        Vector3 spawnDelta = rightSpawn.position - leftSpawn.position;
        transform.position = leftSpawn.position + spawnDelta * Random.value; // This is known as linear interpolation (or lerp for short)
        // The above two lines coule more simply be written as:
        transform.position = Lerp(leftSpawn.position, rightSpawn.position, Random.value);
        // See the function below for a clearer implementation of a lerp
        GetComponent<TrailRenderer>().Clear(); //otherwise you get a trail on this reposition

        Vector3 aimDelta3D = aimTowards.position - transform.position;
        Vector2 aimDelta2D = new Vector2(aimDelta3D.x, aimDelta3D.y); //truncating off the z axis

        rb = GetComponent<Rigidbody2D>();

        float angle = Vector2.Angle(Vector2.right, aimDelta2D);
        angle += Random.Range(-1 * maxAngleDeviance, maxAngleDeviance); //converting to an angle and back
        rb.velocity = DegreeToVector2(angle);

        rb.velocity.Normalize();    //Normalizing a vectory sets its' magnitude to 1 while keeping its' direction the same
        rb.velocity *= Random.Range(initialSpeedMin, initialSpeedMax);

        timer = timeToDetonate;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GetComponent<ParticleSystem>().Play(); // Also check out emit as well as EmitParams!
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f); //make the sprite invisible
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

            timer = 10000f; //arbitrarily large value to prevent spamming explosions
            Destroy(gameObject, 10f); //10 seconds to give any firework time to clear out
        }

    }

    protected virtual void selectRandomColor()
    {
        baseColor = Random.ColorHSV(.0f, 1.0f, .8f, 1.0f, .9f, 1.0f);


        GetComponent<SpriteRenderer>().color = baseColor;

        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(baseColor);

        GetComponent<TrailRenderer>().startColor = baseColor;
    }


    //////////////////////
    // HELPER FUNCTIONS //
    //////////////////////

    // Unity provides this function for you with Mathf.Lerp (only for floats)
    Vector2 Lerp(Vector2 a, Vector2 b, float t) // Returns a value between A and B with t=0 being A and t=1 being B
    {
        t = Mathf.Clamp(t, 0f, 1f); // returns 0 for t<0 and 1 for t>1, otherwise it just returns t
        return a + (b - a) * t;
    }

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }

}
