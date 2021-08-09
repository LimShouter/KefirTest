using System;
using System.Collections.Generic;
using Asteroids.Core;
using Asteroids.Core.Pull;
using Asteroids.Data.Enemies;
using Asteroids.Utilities;
using Asteroids.View.ViewManagers;
using Environment = Asteroids.Core.Environment;

namespace Asteroids.Presenters.Enemies
{
    public class EnemyFactoryPresenter : IPresenter
    {
        private readonly EnemyFactoryData _data;
        private readonly Environment _environment;

        private readonly Dictionary<SubEnemyData, BaseEnemyPresenter> _presenters =
            new Dictionary<SubEnemyData, BaseEnemyPresenter>();

        private readonly Dictionary<SubEnemyData, ISubEnemyView> _views = new Dictionary<SubEnemyData, ISubEnemyView>();

        public EnemyFactoryPresenter(Environment environment, EnemyFactoryData data)
        {
            _environment = environment;
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
            foreach (var deletedData in _data.DeletedDatas) Destroy(deletedData);

            _data.DeletedDatas.Clear();
        }

        private void Generate(EnemyType type)
        {
            var random = _environment.EnvironmentData.Random;
            var spawnArea =
                _environment.EnvironmentData.SpawnAreas[
                    random.Next(0, _environment.EnvironmentData.SpawnAreas.Count - 1)];
            var position = new Vector2(random.Next(spawnArea.XMin, spawnArea.XMax),
                random.Next(spawnArea.YMin, spawnArea.YMax));
            var gameArea = _environment.EnvironmentData.GameArea;
            var directionPos = new Vector2(random.Next(gameArea.XMin, gameArea.XMax),
                random.Next(gameArea.XMin, gameArea.YMin));
            var direction = Math.Atan2(directionPos.X - position.X, directionPos.Y - position.Y) * 180 / Math.PI;
            Create(type, position, (float)direction);
        }

        private void Create(EnemyType type, Vector2 position, float direction)
        {
            var data = new SubEnemyData(type, type == EnemyType.Asteroid,
                type == EnemyType.Alien
                    ? _environment.EnvironmentData.EnemyData.EnemyDescription.AlienSpeed
                    : _environment.EnvironmentData.Random.Next(
                        (int)_environment.EnvironmentData.EnemyData.EnemyDescription.MinSpeed,
                        (int)_environment.EnvironmentData.EnemyData.EnemyDescription.MaxSpeed), position,
                direction);
            _data.SubEnemyDatas.Add(data);
            var view = GetPull(type).Get();
            _views.Add(data, view);
            BaseEnemyPresenter presenter;
            switch (type)
            {
                case EnemyType.Alien:
                    presenter = new AlienEnemyPresenter(_environment, data, view);
                    break;
                default:
                    presenter = new AsteroidEnemyPresenter(_environment, data, view);
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
                    for (var i = -1; i < 2; i++)
                        Create(EnemyType.AsteroidPiece,
                            new Vector2(data.Position.X - 0.3f * i, data.Position.Y - i * 0.3f),
                            data.Direction + 120 * i);
            }
        }


        private BasePull<ISubEnemyView> GetPull(EnemyType type)
        {
            BasePull<ISubEnemyView> pull = null;
            switch (type)
            {
                case EnemyType.Alien:
                    pull = _environment.PullCollection.AlienPull;
                    break;
                case EnemyType.Asteroid:
                    pull = _environment.PullCollection.AsteroidPull;
                    break;
                case EnemyType.AsteroidPiece:
                    pull = _environment.PullCollection.AsteroidPiecePull;
                    break;
            }

            return pull;
        }
    }
}