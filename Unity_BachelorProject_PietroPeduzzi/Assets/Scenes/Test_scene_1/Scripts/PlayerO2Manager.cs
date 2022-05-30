using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerO2Manager : MonoBehaviour
{
    [SerializeField] private float playerStartOxygen = 10;
    [SerializeField] public float playerMaxOxygen = 10;
    [SerializeField] public float oxygenDeploySpeed = 1;

    [SerializeField] private float _maxPlayerHP = 20;

    [SerializeField] private float ditance_1 = 100;
    [SerializeField] private float ditance_2 = 200;
    [SerializeField] private float ditance_3 = 200;

    [SerializeField] private GameObject fadeOutCanvas;

    //animations
    private Animator animator;
    

    private void Start()
    {
        StaticValues.oxygenOnPlayer = playerStartOxygen;
        StaticValues.maxPlayerHP = _maxPlayerHP;
        StaticValues.playerHP = StaticValues.maxPlayerHP;
        StaticValues.playerIsDead = false;

        //animations
        animator = GetComponentInChildren<Animator>();
        AudioListener.pause = false;
    }

    private void Update()
    {
        /*if (StaticValues.distanceTraveled >= ditance_1 && StaticValues.distanceTraveled < ditance_2) oxygenDeploySpeed = 2f;
        if (StaticValues.distanceTraveled >= ditance_2 && StaticValues.distanceTraveled < ditance_3) oxygenDeploySpeed = 4f;
        if (StaticValues.distanceTraveled >= ditance_3) oxygenDeploySpeed = 6;*/
    }

    public void OxygenUsage()
    {
        if (StaticValues.oxygenOnPlayer > 0) StaticValues.oxygenOnPlayer -= Time.deltaTime * oxygenDeploySpeed;
        else if (StaticValues.oxygenOnPlayer <= 0) StaticValues.oxygenOnPlayer = 0;
    }

    public void HPDeploy()
    {
        if (StaticValues.oxygenOnPlayer <= 0 && !StaticValues.playerIsDead) StaticValues.playerHP -= Time.deltaTime;
        if (StaticValues.playerHP <= 0 && !StaticValues.playerIsDead)
        {
            animator.SetTrigger("Death");
            StaticValues.playerIsDead = true;
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        fadeOutCanvas.SetActive(true);
        AudioListener.pause = true;
    }
}
