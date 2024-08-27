using RSAECRSAPI.ECRSDAL;
using RSAECRSAPI.Models;

namespace RSAECRSAPI.ECRSBLL
{
    public class S3Service : IS3Service
    {
        private readonly IS3Repo _s3Repo;

        public S3Service(IS3Repo s3Repo)
        {
           _s3Repo = s3Repo;
        }

        public async Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {
            var result = await _s3Repo.commit(site, customer, transaction, sharedkey, secret, commitTranRequest);
            return result;
        }

        public async Task<BucketResponse> CreateBucket(string bucketName)
        {
            var result = await _s3Repo.CreateBucket(bucketName);
            return result;
        }

        public async Task<BucketResponse> DeleteBucket(string bucketName)
        {
            var result = await _s3Repo.DeleteBucket(bucketName);
            return result;
        }
        public async Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
           var result = await _s3Repo.transaction(site, customer, transaction, TranRequest);
            return result;
        }
        }
}
