using RSAECRSAPI.Models;

namespace RSAECRSAPI.ECRSDAL
{
    public interface ITransactionRepo
    {
        Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest);
        Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest);
        Task<CancelResponse> cancel(string site, string customer, string transaction, string sharedkey, string secret);
        Task<CancelResponse> canceltransaction(CancelTransactionRequest cancelTranRequest);
    }
}
