namespace PdUtils.ProcessorChain
{
    public interface IProcessorChain<TReq, TResp> where TReq : IRequest where TResp : IResponse
    {
        void DoProcess(TReq request, ref TResp response);

        IProcessorChain<TReq, TResp> AddProcessor(IProcessor<TReq, TResp> processor);

        void Release();

        void Reset();

        int Size();
    }
}