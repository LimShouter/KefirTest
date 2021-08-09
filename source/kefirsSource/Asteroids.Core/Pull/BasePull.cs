using System.Collections.Generic;
using Asteroids.View;

namespace Asteroids.Core.Pull
{
    public class BasePull<TComponent> : IPull<TComponent> where TComponent : IPullObject
    {
        private readonly Queue<TComponent> _queue = new Queue<TComponent>();
        private IPullContainer<TComponent> _container;

        public virtual void Init(IPullContainer<TComponent> container)
        {
            _container = container;
            for (var i = 1; i <= _container.GetStartCount(); i++)
            {
                var pullObject = container.CreateObject();
                pullObject.Hide();
                _queue.Enqueue(pullObject);
            }
        }

        public virtual void Dispose()
        {
            for (int i = 0; i < _queue.Count; i++)
            {
                _container.DestroyObject(_queue.Dequeue());
            }
        }

        public int GetMaxCount()
        {
            return _container.GetStartCount();
        }

        public TComponent Get()
        {
            if (_queue.Count == 0)
            {
                _queue.Enqueue(_container.CreateObject());
            }

            var pullObject = _queue.Dequeue();
            return pullObject;
        }

        public virtual void Put(TComponent component)
        {
            _queue.Enqueue(component);
        }
    }
}