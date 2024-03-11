using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public bool isHit;
    Player player;
    enemyState state;
    Controller controller;
    PathManager pathManager;
    [SerializeField] LayerMask layers;
    [SerializeField] float attackRange = 3f;
    [SerializeField] float attackDelay = 2f;
    Vector3 dir;
    float vel;
    RaycastHit hit;
    float t = 2f;

    Path nextPos;
    private void Start()
    {
        player = Player.Instance;
        controller = Controller.Instance;
        pathManager = FindAnyObjectByType<PathManager>();
        state = enemyState.search;
        findPlayerPath();
        t = 0;
    }

    private void Update()
    {
        switch (state)
        {
            case enemyState.chase:
                chase();
                break;
            case enemyState.search:
                search();
                break;
            case enemyState.attack:
                attack();
                break;
            case enemyState.die:
                SceneManager.LoadScene(sceneBuildIndex: 0);
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            state = enemyState.die;
            isHit = true;
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
    }


    private void chase()
    {
        if (!ICanSeePlayer()) { state = enemyState.search; }

        dir = calcTargetDirection(player.transform.position);

        if (distSQR(player.getPosition()) < attackRange)
        {
            state = enemyState.attack;
        }
        Move();
    }
    private void search()
    {
        if (ICanSeePlayer()) { state = enemyState.chase; }

        dir = calcTargetDirection(nextPos.position);
        if (distSQR(nextPos.position) < 0.2f)
        {
            nextPos = pathManager.CalcPath(nextPos);
        }
        Move();
    }
    private void attack()
    {
        //Dur
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        else
        {
            if (distSQR(player.getPosition()) < attackRange)
            {
                controller.RotateBody(transform, controller.CalcAngle(calcTargetDirection(player.getPosition())), ref vel);
                //Sald�r
                GameManager.Instance.CheckILose();
                t = attackDelay;
            }
            else
            {
                state = enemyState.search;
            }

            //Devam et
        }

    }

    Vector3 calcTargetDirection(Vector3 target)
    {
        Vector3 pos = transform.position;
        pos.y = 0;
        target.y = 0;
        return (target - pos).normalized;
    }

    private void findPlayerPath()
    {
        nextPos = pathManager.getClosestPath();
    }

    private bool ICanSeePlayer()
    {
        bool view = false;
        Ray ray = new Ray(transform.position + Vector3.up, calcTargetDirection(player.getPosition()));
        Physics.Raycast(ray, out hit, 25f, layers, QueryTriggerInteraction.Collide);
        Debug.DrawRay(transform.position + Vector3.up, calcTargetDirection(player.getPosition()) * hit.distance);
        if (hit.collider != null)
        {
            view = hit.collider.CompareTag("Player");
        }
        return view;
    }
    private float distSQR(Vector3 target)
    {
        Vector3 pos = transform.position;
        pos.y = 0;
        target.y = 0;
        return (target - pos).sqrMagnitude;
    }

    private void Move()
    {
        dir.y = 0;
        controller.MoveAndRotateDir(transform, controller.CalcAngle(dir), 2f, ref vel);
    }

}

public enum enemyState { chase, search, attack, die }