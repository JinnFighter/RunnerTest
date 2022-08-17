using System.Collections.Generic;

namespace Updaters
{
    public class UpdaterRunner
    {
        private readonly LinkedList<IUpdater> _updaters = new();
        private readonly Dictionary<IUpdater, bool> _updaterState = new();

        public void Add(IUpdater updater)
        {
            if (_updaterState.TryGetValue(updater, out var isRun))
            {
                if(!isRun)
                {
                    _updaterState[updater] = true;
                }
            }
            else
            {
                _updaterState.Add(updater, true);
                _updaters.AddLast(updater);
            }
        }
    
        public void Remove(IUpdater updater)
        {
            if(_updaterState.TryGetValue(updater, out _))
            {
                _updaterState[updater] = false;
            }
        }

        public void Run(float deltaTime)
        {
            var current = _updaters.First;
            while(current != null)
            {
                if (_updaterState[current.Value])
                {
                    current.Value.Update(deltaTime);
                }
                else
                {
                    _updaters.Remove(current);
                    _updaterState.Remove(current.Value);
                }

                current = current.Next;
            }
        }

        public void Clear()
        {
            _updaters.Clear();
            _updaterState.Clear();
        }
    }
}
