using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{
    public float JumpForce = 10;
    public float Velocity = 5;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;

    private static readonly string ANIMATOR_STATE = "estado";
    public static readonly int ANIMATION_RUN = 1;
    private static readonly int ANIMATION_JUMP = 2;
    private static readonly int ANIMATION_IDLE = 0;
    private static readonly int ANIMATION_CORRER_DISPARAR = 3;

    private static readonly int RIGHT = 1;
    private static readonly int LEFT = -1;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        ChangeAnimation(ANIMATION_IDLE);

        //TXT_score.text = "Vida: " + vida;

       if(Input.GetKey(KeyCode.RightArrow)) //si presiono flecha a la derecha
        {
            Desplazarse(RIGHT);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazarse(LEFT);
        }

        if(Input.GetKey(KeyCode.C))
        {
            CorrerDisparo(RIGHT);
        }

        if(Input.GetKey(KeyCode.V))
        {
            CorrerDisparo(LEFT);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            _rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            //_audioSource.PlayOneShot(SaltoAudioClip);
            ChangeAnimation(ANIMATION_JUMP);
        }
        //checkLife();
        //setGatoDeath();
    }

    private void Desplazarse(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);
        _sr.flipX = position == LEFT;
        ChangeAnimation(ANIMATION_RUN); //Cambiamos el valor del atributo
    }

    private void ChangeAnimation(int animation)
    {
        _animator.SetInteger(ANIMATOR_STATE, animation);
    }


    private void CorrerDisparo(int position)
    {
        _rb.velocity = new Vector2(Velocity * position, _rb.velocity.y);
        _sr.flipX = position == LEFT;
        ChangeAnimation(ANIMATION_CORRER_DISPARAR);
    }

}
