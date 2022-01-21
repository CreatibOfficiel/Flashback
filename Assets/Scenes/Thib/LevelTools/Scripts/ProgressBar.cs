using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    [SerializeField] Transform Player;
    [SerializeField] Transform Enemy;
    [SerializeField] Transform EndLine;
    [SerializeField] Slider sliderEnemy;
    [SerializeField] Slider slider;

    float maxDistance;

    // Start is called before the first frame update
    void Start()
    {
        maxDistance = getPlayerDistance();
    }

    // Update is called once per frame
    void Update()
    {
       if(Player.position.x <= maxDistance && Player.position.x <= EndLine.position.x)
        {
            float distance = 1 - (getPlayerDistance() / maxDistance);

            slider.value = distance;
        }

        if (Enemy.position.x <= maxDistance && Enemy.position.x <= EndLine.position.x)
        {
            float distance = 1 - (getEnemyDistance() / maxDistance);

            sliderEnemy.value = distance;
        }
    }

    float getPlayerDistance()
    {
        return Vector2.Distance(Player.position, EndLine.position);
    }

    float getEnemyDistance()
    {
        return Vector2.Distance(Enemy.position, EndLine.position);
    }
}
