using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Description;
using UnityEngine;
[CreateAssetMenu(fileName = "GameDescription",menuName = "Create game description")]
public class DescriptionSo : ScriptableObject
{
    [SerializeField]private int offset;
    [SerializeField]private int cameraZ;
    public ShipDescription shipDescription;
    public ShotDescription shotDescription;
    public EnemyDescription enemyDescription;
    public ScoreDescription scoreDescription;
    private CustomRandom _random = new CustomRandom();

    public DescriptionCollection GetDescription()
    {
        var camera = Camera.main;
        var maxPos = camera.ScreenToWorldPoint(new Vector3 (camera.pixelWidth,camera.pixelHeight,cameraZ))+new Vector3(offset,offset) ;
        var minPos = camera.ScreenToWorldPoint(new Vector3(0, 0, cameraZ))-new Vector3(offset,offset);
        var maxPlayablePos = camera.ScreenToWorldPoint(new Vector3 (camera.pixelWidth+offset,camera.pixelHeight + offset,cameraZ));
        var minPlayablePos = camera.ScreenToWorldPoint(new Vector3(-offset, -offset, cameraZ));
        var playableArea = new GameArea((int) maxPlayablePos.x, (int) minPlayablePos.x, (int) minPlayablePos.y, (int) maxPlayablePos.y);
        var spawnAreas = new List<GameArea>()
        {
            new GameArea((int) maxPos.x,(int) maxPlayablePos.x,(int) minPos.y,(int) maxPos.y),
            new GameArea((int) minPos.x,(int) maxPos.x,(int) minPos.y,(int) minPlayablePos.y),
            new GameArea((int) minPos.x,(int) maxPos.x,(int) maxPlayablePos.y,(int) maxPos.y),
            new GameArea((int) minPlayablePos.x,(int) minPos.x,(int) minPos.y,(int) maxPos.y)
        };
        return new DescriptionCollection(shipDescription, spawnAreas, playableArea, shotDescription, enemyDescription,
            scoreDescription,_random);
    }
}