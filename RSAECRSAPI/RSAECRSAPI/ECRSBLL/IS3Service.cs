using RSAECRSAPI.Models;

namespace RSAECRSAPI.ECRSBLL
{
    public interface IS3Service
    {
        Task<BucketResponse> CreateBucket(string bucketName);
        Task<BucketResponse> DeleteBucket(string bucketName);
        Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest);
        Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest);
    }
}
