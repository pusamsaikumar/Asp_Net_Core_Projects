using RSAECRSAPI.ECRSDAL;
using RSAECRSAPI.Models;

namespace RSAECRSAPI.ECRSBLL
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;

        public TransactionService(ITransactionRepo transactionRepo) 
        {
            _transactionRepo = transactionRepo;
        }
        public async Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            var result = await _transactionRepo.transaction(site, customer, transaction, TranRequest);
            return result;
        }
        public async Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {
            var result = await _transactionRepo.commit(site, customer, transaction, sharedkey, secret, commitTranRequest);
            return result;
        }

        public async Task<CancelResponse> cancel(string site, string customer, string transaction, string sharedkey, string secret)
        {
            var result = await _transactionRepo.cancel(site, customer, transaction, sharedkey, secret);
            return result;

        }
        public async Task<CancelResponse> canceltransaction(CancelTransactionRequest cancelTranRequest)
        {
            var result = await _transactionRepo.canceltransaction(cancelTranRequest);
            return result;
        }
    }
}
