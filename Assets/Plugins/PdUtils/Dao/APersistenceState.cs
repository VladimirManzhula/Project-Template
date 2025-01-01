using System;
using UniRx;

namespace PdUtils.Dao
{
    public abstract class APersistenceState<TDao, TState>
        where TDao : IDao<TState>
    {
        protected readonly TDao Dao;

        private IDisposable _disposable;

        public APersistenceState(TDao dao)
        {
            Dao = dao;
        }

        protected void SetDirty()
        {
            if (_disposable != null)
                return;

            _disposable = Observable.NextFrame(FrameCountType.EndOfFrame)
                .Subscribe(OnSave);
        }

        private void OnSave(Unit obj)
        {
            _disposable = null;
            var state = ConvertToState();
            Dao.Save(state);
        }

        protected abstract TState ConvertToState();
    }
}