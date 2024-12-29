namespace PdUtils.ProcessorChain
{
    public interface IProcessorService<in TReq, TResp> where TReq : IRequest where TResp : IResponse
    {
        void SetRequestResponseBuilder(IRequestResponseBuilder<TReq, TResp> builder);
        TResp DoProcess();
    }
}