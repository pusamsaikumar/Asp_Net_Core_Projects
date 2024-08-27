using RSAECRSAPI.Models;
using System.Data.SqlClient;
using System.Transactions;

namespace RSAECRSAPI.ECRSDAL
{
    public class TransactionRepo : ITransactionRepo
    {
        private readonly Helpers _helpers;
        private readonly List<AppConfigurations> _appConfigurations;

        public TransactionRepo(
            Helpers helpers,
            List<AppConfigurations> appConfigurations
            
            )
        {
            _helpers = helpers;
            _appConfigurations = appConfigurations;
        }

        public async Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            UpdateTransactionResponse updateTransactionResponse = null;
            updateTransactionResponse = new UpdateTransactionResponse();
            
           
            
            try
            {

                var jsonData = _appConfigurations.ToArray().FirstOrDefault(x => x.SharedKey == TranRequest.sharedKey && x.SecretKey == TranRequest.Secret);
                var connectionString = jsonData?.RetailerConnectionString.ToString();
               
              //  var jsonData = await _helpers.ReadJsonFile(TranRequest.sharedKey, TranRequest.Secret);
               // var connectionString = jsonData?.AppConfigurations?.RetailerConnectionString?.ToString();
                if (jsonData != null && connectionString != null) {
                    
                    SqlHelpers sqlHelpers = new SqlHelpers(connectionString);
                    var parametes = new SqlParameter[]
                    {
                        new SqlParameter("@Customer",TranRequest.Customer == null ? DBNull.Value : TranRequest.Customer),
                        new SqlParameter("@Site",TranRequest?.Site == null ? DBNull.Value : TranRequest.Site),
                        new SqlParameter("@Transactions",TranRequest?.Transaction == null ? DBNull.Value : TranRequest.Transaction),
                        new SqlParameter("@Cashier",TranRequest?.Cashier == null ? DBNull.Value : TranRequest.Cashier),
                        new SqlParameter("@Terminal",TranRequest?.Terminal == null ? DBNull.Value : TranRequest.Terminal),
                        new SqlParameter("@Time",TranRequest?.Time == null ? DBNull.Value : TranRequest.Time),
                        new SqlParameter("@SubTotal",TranRequest?.SubTotal == null ? DBNull.Value : TranRequest.SubTotal),
                        new SqlParameter("@TaxTotal",TranRequest?.TaxTotal == null ? DBNull.Value : TranRequest.TaxTotal),
                        new SqlParameter("@GrossTotal",TranRequest?.TaxTotal == null ? DBNull.Value : TranRequest.GrossTotal),
                        new SqlParameter("@PhoneNumber",TranRequest?.TaxTotal == null ? DBNull.Value : TranRequest.PhoneNumber),
                        new SqlParameter("@PosDiscountApplied",TranRequest?.TaxTotal == null ? DBNull.Value : TranRequest.PosDiscountApplied),

                    };
                    var storedProcName = "InsertTransaction";
                    var updateTransaction = await sqlHelpers.InsertTable(storedProcName,parametes);
                   if(updateTransaction > 0)
                    {
                        updateTransactionResponse.ErrorCode = "200";
                        updateTransactionResponse.ErrorDesc = "Successful";
                        updateTransactionResponse.Status = "Successful";
                        return updateTransactionResponse;
                    }
                   else
                    {
                        updateTransactionResponse.ErrorCode = "400";
                        updateTransactionResponse.ErrorDesc = "Faield";
                        updateTransactionResponse.Status = "Failed";
                        return updateTransactionResponse;
                    }

                }
               

                updateTransactionResponse.ErrorCode = "400";
                updateTransactionResponse.ErrorDesc = "";
                updateTransactionResponse.Status = "Failed.";
                
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
