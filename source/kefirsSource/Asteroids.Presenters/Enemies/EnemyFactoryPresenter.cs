using System;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Pull.Pulls;
using Asteroids.Data.Enemies;
using Asteroids.Utilities;
using Asteroids.View;
using Asteroids.View.ViewManagers;

namespace Asteroids.Presenters.Enemies
{
    public class EnemyFactoryPresenter : IPresenter
    {
        private readonly EnvironmentData _environmentData;
        private readonly EnemyFactoryData _data;

        private readonly Dictionary<SubEnemyData, BaseEnemyPresenter> _presenters =
            new Dictionary<SubEnemyData, BaseEnemyPresenter>();

        private readonly Dictionary<SubEnemyData, ISubEnemyView> _views = new Dictionary<SubEnemyData, ISubEnemyView>();

        public EnemyFactoryPresenter(EnvironmentData environmentData, EnemyFactoryData data)
        {
            _environmentData = environmentData;
            _data = data;
        }

        public void Attach()
        {
            _data.OnGenerate += Generate;
            _data.OnUpdate += Update;
        }

        public void Detach()
        {
            _data.OnUpdate -= Update;
            _data.OnGenerate -= Generate;
            Clear();
        }

        public void Clear()
        {
            _data.DeletedDatas.AddRange(_data.SubEnemyDatas);
            Update();
            _data.DeletedDatas.AddRange(_data.SubEnemyDatas);
            Update();
        }

        private void Update()
        {
            foreach (var deletedData in _data.DeletedDatas)
            {
                Destroy(deletedData);
            }

            _data.DeletedDatas.Clear();
        }

        private void Generate(EnemyType type)
        {
            var random = _environmentData.Random;
            var spawnArea = _environmentData.SpawnAreas[random.Next(0, _environmentData.SpawnAreas.Count - 1)];
            var position = new Vector2(random.Next(spawnArea.XMin, spawnArea.XMax),
                random.Next(spawnArea.YMin, spawnArea.YMax));
            var gameArea = _environmentData.GameArea;
            var directionPos = new Vector2(random.Next(gameArea.XMin, gameArea.XMax),
                random.Next(gameArea.XMin, gameArea.YMin));
            var direction = Math.Atan2(directionPos.X - position.X, directionPos.Y - position.Y) * 180 / Math.PI;
            Create(type, position, (float) direction);
        }

        private void Create(EnemyType type, Vector2 position, float direction)
        {
            var data = new SubEnemyData(type, type == EnemyType.Asteroid,
                type == EnemyType.Alien
                    ? _environmentData.EnemyData.EnemyDescription.AlienSpeed
                    : _environmentData.Random.Next((int) _environmentData.EnemyData.EnemyDescription.MinSpeed,
                        (int) _environmentData.EnemyData.EnemyDescription.MaxSpeed), position,
                direction);
            _data.SubEnemyDatas.Add(data);
            ISubEnemyView view = GetPull(type).Get();
            _views.Add(data, view);
            BaseEnemyPresenter presenter;
            switch (type)
            {
                case EnemyType.Alien:
                    presenter = new AlienEnemyPresenter(_environmentData, data, view);
                    break;
                default:
                    presenter = new AsteroidEnemyPresenter(_environmentData, data, view);
                    break;
            }

            presenter.Attach();
            _presenters.Add(data, presenter);
        }


        private void Destroy(SubEnemyData data)
        {
            if (_data.SubEnemyDatas.Contains(data))
            {
                _presenters[data].Detach();
                _presenters.Remove(data);
                GetPull(data.Type).Put(_views[data]);
                _views.Remove(data);
                _data.SubEnemyDatas.Remove(data);
                if (data.CanSpawnOther)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        Create(EnemyType.AsteroidPiece,
                            new Vector2(data.Position.X - 0.3f * i, data.Position.Y - i * 0.3f),
                            data.Direction + 120 * i);
                    }
                }
            }
        }


        private EnemyPull GetPull(EnemyType type)
        {
            EnemyPull pull = null;
            switch (type)
            {
                case EnemyType.Alien:
                    pull = _environmentData.AlienPull;
                    break;
                case EnemyType.Asteroid:
                    pull = _environmentData.AsteroidPull;
                    break;
                case EnemyType.AsteroidPiece:
                    pull = _environmentData.AsteroidPiecePull;
                    break;
            }

            return pull;
        }
    }
}