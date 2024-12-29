using System;

namespace PdUtils.ProcessorChain.Impl
{
    public class ProcessorChain<TReq, TResp> : IProcessorChain<TReq, TResp>
        where TReq : IRequest where TResp : IResponse
    {
        private const int Increment = 10;

        /**
         * The int which gives the current number of filters in the chain.
         */
        private int _n;

        /**
         * The int which is used to maintain the current pos
         * in the filter chain.
         */
        private int _pos;

        private IProcessor<TReq, TResp>[] _processors = new IProcessor<TReq, TResp>[0];

        public void DoProcess(TReq request, ref TResp response)
        {
            if (_pos >= _n) return;
            var processor = _processors[_pos++];
            processor.DoProcess(request, ref response, this);
        }

        public IProcessorChain<TReq, TResp> AddProcessor(IProcessor<TReq, TResp> processor)
        {
            // Prevent the same filter being added multiple times
            foreach (var p in _processors)
                if (p == processor)
                    return this;


            if (_n == _processors.Length)
            {
                var newProcessors = new IProcessor<TReq, TResp>[_n + Increment];
                Array.Copy(_processors, 0, newProcessors, 0, _n);
                _processors = newProcessors;
            }

            _processors[_n++] = processor;
            return this;
        }

        public void Release()
        {
            for (var i = 0; i < _n; i++) _processors[i] = null;
            _n = 0;
            _pos = 0;
        }

        public void Reset()
        {
            _pos = 0;
        }

        public int Size()
        {
            return _processors.Length;
        }
    }
}