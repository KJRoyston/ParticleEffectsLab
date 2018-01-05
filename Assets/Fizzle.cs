using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fizzle : Firework{
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            GetComponent<ParticleSystem>().Stop();
            GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f); //make the sprite invisible
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;

            timer = 10000f; //arbitrarily large value to prevent spamming explosions
            Destroy(gameObject, 10f); //10 seconds to give any firework time to clear out
        }

    }

    protected override void selectRandomColor()
    {
        baseColor = Random.ColorHSV(.0f, 1.0f, .7f, 1.0f, .9f, 1.0f);
        baseColor.a = .5f;

        GetComponent<SpriteRenderer>().color = baseColor;

        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(baseColor);

        GetComponent<TrailRenderer>().startColor = baseColor;
    }
}
