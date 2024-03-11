using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] Path[] PathList;
    Player player;
    Enemy enemy;

    public Path getClosestPath()
    {
        player = Player.Instance;
        enemy = FindObjectOfType<Enemy>();
        float closestDist = 200;
        Path closestPath = PathList[0];
        foreach (var path in PathList)
        {
            Vector3 pos = enemy.transform.position;
            pos.y = 0;
            path.position.y = 0;
            float dist = Vector3.SqrMagnitude(enemy.transform.position - path.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestPath = path;
            }
        }
        return closestPath;
    }

    public Path CalcPath(Path path)
    {
        float neightbour1 = Vector3.SqrMagnitude(path.neighbour1.position - player.getPosition()) + Vector3.SqrMagnitude(path.neighbour1.position - enemy.transform.position);
        float neightbour2 = Vector3.SqrMagnitude(path.neighbour2.position - player.getPosition()) + Vector3.SqrMagnitude(path.neighbour2.position - enemy.transform.position);
        return (neightbour1 > neightbour2) ? path.neighbour2 : path.neighbour1;
    }
}