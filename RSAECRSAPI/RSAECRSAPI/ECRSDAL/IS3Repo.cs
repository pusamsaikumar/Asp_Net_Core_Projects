using RSAECRSAPI.Models;

namespace RSAECRSAPI.ECRSDAL
{
    public interface IS3Repo
    {
        Task<BucketResponse> CreateBucket(string bucketName);
        Task<BucketResponse> DeleteBucket(string bucketName);
        Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest);
        Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest);
        
    }
}
