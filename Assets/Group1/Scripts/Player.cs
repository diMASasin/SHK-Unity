using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        transform.Translate(moveDirection * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.Die();
        }
        else if (collision.TryGetComponent<Booster>(out Booster booster))
        {
            StartCoroutine(UseBooster(booster));
            Destroy(booster.gameObject);
        }
    }

    private IEnumerator UseBooster(Booster booster)
    {
        _speed *= booster.SpeedIncreaseMultiplier;
        yield return new WaitForSeconds(booster.Duration);
        _speed /= booster.SpeedIncreaseMultiplier;
    }
}
