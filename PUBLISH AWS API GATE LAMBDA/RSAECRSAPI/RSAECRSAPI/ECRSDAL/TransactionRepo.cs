using RSAECRSAPI.ECRSDAL.Models;

namespace RSAECRSAPI.ECRSDAL
{
    public class TransactionRepo : ITransactionRepo
    {
       

        public async Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            UpdateTransactionResponse updateTransactionResponse = null;
            updateTransactionResponse = new UpdateTransactionResponse();
            try
            {
                updateTransactionResponse.ErrorCode = "200";
                updateTransactionResponse.ErrorDesc = "Successful";
                updateTransactionResponse.Status = "Successful";
                
            }
            catch (Exception ex) {
                updateTransactionResponse.ErrorCode = "500";
                updateTransactionResponse.ErrorDesc = ex.Message.ToString();
                updateTransactionResponse.Status = "Internel server error.";
            }
            return updateTransactionResponse;
        }
        public async Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {
            CommitResponse commitResponse = null;
            commitResponse = new CommitResponse();
            try
            {
                commitResponse.ErrorCode = "200";
                commitResponse.ErrorDesc = "Successful";
                commitResponse.Status = "Successful";
            }
            catch (Exception ex)
            {
                commitResponse.ErrorCode = "500";
                commitResponse.ErrorDesc =ex.Message.ToString();
                commitResponse.Status = "Internel server error";

            }
            return commitResponse;
        }

        public async Task<CancelResponse> cancel(string site, string customer, string transaction, string sharedkey, string secret)
        {
            CancelResponse cancelResponse = null;
            cancelResponse = new CancelResponse();
            try
            {
                cancelResponse.ErrorCode = "200";
                cancelResponse.ErrorDesc = "Successful";
                cancelResponse.Status = "Successful";
            }
            catch (Exception ex) {
                cancelResponse.ErrorCode = "500";
                cancelResponse.ErrorDesc = ex.Message.ToString();
                cancelResponse.Status = "Internel server error";
            }
            return cancelResponse;
        }

        public async Task<CancelResponse> canceltransaction(CancelTransactionRequest cancelTranRequest)
        {
            CancelResponse cancelResponse = null;
            cancelResponse = new CancelResponse();
            try
            {
                cancelResponse.ErrorCode = "200";
                cancelResponse.ErrorDesc = "Successful";
                cancelResponse.Status = "Successful";
            }
            catch (Exception ex) 
            {
                cancelResponse.ErrorCode = "500";
                cancelResponse.ErrorDesc = ex.Message.ToString();
                cancelResponse.Status = "Internel server error";
            }
            return cancelResponse;
        }
    }
}
