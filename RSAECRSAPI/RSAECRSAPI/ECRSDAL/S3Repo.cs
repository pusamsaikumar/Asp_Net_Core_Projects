using Amazon.Lambda.RuntimeSupport.Helpers;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using RSAECRSAPI.Models;
using System.Security.Cryptography.Xml;
using System.Transactions;

namespace RSAECRSAPI.ECRSDAL
{
    public class S3Repo : IS3Repo
    {
        private readonly IAmazonS3 _amazonS3;
        private readonly List<AppConfigurations> _appConfigurations;
        private readonly S3BucketHelpers _s3BucketHelpers;

        public S3Repo(
            IAmazonS3 amazonS3,
            List<AppConfigurations> appConfigurations,
            S3BucketHelpers s3BucketHelpers
            )
        {
            _amazonS3 = amazonS3;
            _appConfigurations = appConfigurations;
            _s3BucketHelpers = s3BucketHelpers;
        }
        public async Task<UpdateTransactionResponse> transaction(string site, string customer, string transaction, UpdateTransactionRequest TranRequest)
        {
            UpdateTransactionResponse response = new UpdateTransactionResponse();
            try
            {
                var appConfigurationData = _appConfigurations.ToArray();
                AppConfigurations appConfigurations = new AppConfigurations();
                // appConfigurations = appConfigurationData.FirstOrDefault(x => x.SharedKey == TranRequest.sharedKey && x.SecretKey == TranRequest.Secret);

                var jsonData = _appConfigurations.ToArray().FirstOrDefault(x => x.SharedKey == TranRequest.sharedKey && x.SecretKey == TranRequest.Secret);
                TransactionData transactionData = null;
                if (jsonData != null)
                {
                    transactionData = new TransactionData
                    {
                        SharedKey = jsonData.SharedKey,
                        SecretKey = jsonData.SecretKey,
                        Retailer = jsonData.RetailerName,
                        Customer = TranRequest.Customer,
                        StoreId = 4,
                        TransactionId = TranRequest.Transaction,
                        Cashier = TranRequest.Cashier,
                        Terminal = TranRequest.Terminal,
                        TransactionDate = DateTime.Now,
                        TransactionTime = new TimeSpan(),
                        Items = new List<TransactionItem>()
                                    {
                                        new TransactionItem
                                                {

                                                    Id = 1,
                                                    IdType = "TypeB",
                                                    UPC = "098765432109",
                                                    Amount = 5,
                                                    StandardPrice = 6,
                                                    AmountPaid = 6,
                                                    Qty = 2, 
                                                    QtyType = "Piece",
                                                    ItemWeight = 0,
                                                    ItemType = "Grocery",
                                                    DeptId = 102,
                                                    FamilyCode1 = "FC3",
                                                    FamilyCode2 = "FC4",
                                                    SaleType = "Retail",
                                                    CoPrefix = "PrefixB",
                                                    LineID = "Line2",
                                                    IsDiscountable = false,
                                                    Weightunit = "kg"


                                                   }
                        },
                        TransactionTotalAmount = (int)TranRequest.SubTotal,
                        TransactionTaxAmount = (int)TranRequest.TaxTotal,
                        TransactionGrossTotal = (int)TranRequest.GrossTotal,
                        PhoneNumber = TranRequest.PhoneNumber,
                        Tenders = new List<TransactionTender>()
                                         {
                                                new TransactionTender
                                                {
                                                    Type = "CreditCard",
                                                    Amount = 0,
                                                }
                                        },
                        TenderType = "CreditCard",
                        PosType = jsonData.POSType,
                        DBInstanceName = jsonData.DBInstanceName,
                        DBName = jsonData.DBName,
                        IsMemberTransaction = false,
                        Coupons = null,
                        Promotions = null,
                        //Coupons = new List<AppliedCoupon>()
                        //                {
                        //                         new AppliedCoupon
                        //                         {
                        //                               PromotionId = "promo123",
                        //                               IdType = "Coupon",
                        //                               Title = "10% Off",
                        //                               Items = new List<CouponLineItem>()
                        //                                        {
                        //                                             new CouponLineItem
                        //                                             {
                        //                                                 LineId = 1,
                        //                                                 DiscountAmount = 2,
                        //                                                 Quantity = 1
                        //                                             }
                        //                                         },
                        //                               TotalDiscount = 2,
                        //                               CouponTypeId = 1,
                        //                               AppliedCount = 1,
                        //                               CouponType = "Discount",
                        //                               CouponSource = "POS",
                        //                               QualifiedLineIds = "1",
                        //                               QualifiedUPCs = "123456789012",
                        //                               IsAppliedAtPOS = true
                        //                         }
                        //                 },
                        //Promotions = new List<AppliedPromotion>()
                        //                  {
                        //                         new AppliedPromotion
                        //                         {

                        //                            PromotionId = "promo123",
                        //                            IdType = "Promotion",
                        //                            Title = "10% Off",
                        //                            Items = new List<CouponLineItem>()
                        //                                    {
                        //                                        new CouponLineItem
                        //                                        {
                        //                                            LineId = 1,
                        //                                            DiscountAmount = 2,
                        //                                            Quantity = 1
                        //                                        }
                        //                                     },
                        //                            TotalDiscount = 2,
                        //                            CouponTypeId = 1,
                        //                            AppliedCount = 1,
                        //                            CouponType = "Discount",
                        //                            CouponSource = "POS",
                        //                            QualifiedLineIds = "1",
                        //                            QualifiedUPCs = "123456789012",
                        //                            IsAppliedAtPOS = true
                        //                         }
                        //                     },

                     
                        CommitRequest = new CommitData(),
                        CloudRetailerName = "rsaecrsapidemo",
                        CloudFileName = "retailer04",
                        CloudFolderName = "Transaction"



                    };
                }





                var bucketName = transactionData?.CloudRetailerName;

                //var listOfBuckets = await _amazonS3.ListBucketsAsync();
                //var existBucketName = listOfBuckets.Buckets.Any(b => b.BucketName == bucketName);


               

                var existBucketName = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
            
                if (existBucketName && bucketName != null && transactionData != null)
                {

                    string json = JsonConvert.SerializeObject(transactionData);

                    var storeId = transactionData.StoreId;
                    var transactionDate = transactionData.TransactionDate.ToString("MMddyyyy");
                    var folderName = transactionData.CloudFolderName;
                    var fileName = transactionData.CloudFileName;
                  
                    string key = $"{folderName}/{transactionDate}/{storeId}/{fileName}";

                    //var putObjectRequest = new PutObjectRequest
                    //{
                    //    BucketName = bucketName,
                    //    Key = key,
                    //    ContentBody = json,
                    //    ContentType = "application/json",
                    //};
                    // PutObjectResponse putObjectResponse = await _amazonS3.PutObjectAsync(putObjectRequest);

                    var saveS3Obj = await _s3BucketHelpers.SaveS3BucketObject(bucketName, key, json);

                   
                    if (saveS3Obj.Status == "Success")
                    {
                        response.ErrorCode = saveS3Obj.ErrorCode;
                        response.ErrorDesc = saveS3Obj.ErrorDesc;
                        response.Status = saveS3Obj.Status;
                        return response;
                    }


                    response.ErrorCode = "400";
                    response.ErrorDesc = saveS3Obj.ErrorDesc;
                    response.Status = "Failed";
                    return response;




                }

                response.ErrorCode = "400";
                response.ErrorDesc = "Invalid bucket name.";
                response.Status = "Failed";

            }
            catch (Exception ex)
            {
                response.ErrorCode = "500";
                response.ErrorDesc = ex.Message;
                response.Status = "Internel server error";
            }
            return response;
        }
        public async Task<CommitResponse> commit(string site, string customer, string transaction, string sharedkey, string secret, CommitTransactionRequest commitTranRequest)
        {
            CommitResponse commitResponse = new CommitResponse();

            try
            {

                var jsonData = _appConfigurations?.FirstOrDefault(x => x.SharedKey == commitTranRequest.SharedKey && x.SecretKey == commitTranRequest.Secret);
                var bucketName = "rsaecrsapidemo";
                var folderName = "Transaction";
                var storeId = 4;
                var transactionDate = DateTime.Now.ToString("MMddyyyy");
                var fileName = "retailer04";

                var key = $"{folderName}/{transactionDate}/{storeId}/{fileName}";


                // validate BucketName:
                // var existBucket = await _amazonS3.DoesS3BucketExistAsync(bucketName);


                //var listbuckets = await _amazonS3.ListBucketsAsync();
                //var existBucket = listbuckets.Buckets.Any(b => b.BucketName == bucketName);


                var existBucket = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
                var transactiondata = new TransactionData();
                if (existBucket)
                {
                     var validPath = await _s3BucketHelpers.ValidateKeyPathAsync(bucketName, folderName, transactionDate, storeId, fileName);

                   if (!string.IsNullOrEmpty(validPath))
                    {

                        //string key = Transaction/08212024/2/retailer02;
                        var getS3TransactionData = await _s3BucketHelpers.GetS3BucketObjectDetails(bucketName, validPath);
                        transactiondata = JsonConvert.DeserializeObject<TransactionData>(getS3TransactionData);

                        if (transactiondata != null)
                        {
                            var commitData = new CommitData
                            {
                                SharedKey = transactiondata.SharedKey,
                                SecretKey = transactiondata.SecretKey,
                                Customer = transactiondata.Customer,
                                StoreId = transactiondata.StoreId,
                                TransactionId = transactiondata.TransactionId,
                                Cashier = transactiondata.Cashier,
                                Terminal = transactiondata.Terminal,
                                DateTime = transactiondata.TransactionDate,
                                Coupons = new List<string> { "COUPON123", "COUPON456" },
                                Tenders = new List<TransactionTender>
                                                 {
                                                      new TransactionTender {Type = "Credit",Amount=90},
                                                      new TransactionTender {Type = "Cash",Amount=90},
                                                  },
                                TenderType = "Mixed",
                                IsMemberTransaction = transactiondata.IsMemberTransaction,
                                CloudRetailerName = transactiondata.CloudRetailerName,
                                CloudFileName = transactiondata.CloudFileName,
                                CloudFolderName = transactiondata.CloudFolderName,
                            };

                            transactiondata.Coupons = new List<AppliedCoupon>
                            {
                                new AppliedCoupon()
                            };
                            transactiondata.Promotions = new List<AppliedPromotion>
                            {
                                new AppliedPromotion()
                            };
                            transactiondata.CommitRequest = commitData;

                            // delete transaction
                            await _s3BucketHelpers.DeleteBucketObject(bucketName, validPath);


                        }

                    }

                    else
                    {
                        if (jsonData != null)
                        {
                            var commitData = new CommitData
                            {
                                SharedKey = jsonData.SharedKey,
                                SecretKey = jsonData.SecretKey,
                                Customer = commitTranRequest.Customer,
                                StoreId = 4,
                                TransactionId = commitTranRequest.Transaction,
                                Cashier = commitTranRequest.Cashier,
                                Terminal = commitTranRequest.Terminal,
                                DateTime = DateTime.Now,
                                Coupons = commitTranRequest.coupons,
                                Tenders = commitTranRequest.tenders.Select(x =>
                                            {
                                                return new TransactionTender { Type = x.Type, Amount = (decimal)x.Amount };
                                            }).ToList(),
                                TenderType = "Mixed",
                                IsMemberTransaction = true,
                                CloudRetailerName = "rsaecrsapidemo",
                                CloudFileName = "retailer04",
                                CloudFolderName = "Commit"
                            };


                         
                            transactiondata.StoreId = 4;
                            transactiondata.TransactionDate = DateTime.Now;
                            transactiondata.Coupons = new List<AppliedCoupon>
                            {
                                new AppliedCoupon()
                            };
                            transactiondata.Promotions = new List<AppliedPromotion>
                            {
                                new AppliedPromotion()
                            };
                            transactiondata.CommitRequest = commitData;
                            transactiondata.CloudRetailerName = "rsaecrsapidemo";
                            transactiondata.CloudFileName = "retailer04";
                            transactiondata.CloudFolderName = "Commit";
                            

                        //    transactiondata = new TransactionData
                        //    {
                        //        SharedKey = jsonData.SharedKey,
                        //        SecretKey = jsonData.SecretKey,
                        //        Retailer = jsonData.RetailerName,
                        //        Customer = "saikumar",
                        //        StoreId = 3,
                        //        TransactionId = "349857",
                        //        Cashier = 49,
                        //        Terminal = 99,
                        //        TransactionDate = DateTime.Now,
                        //        TransactionTime = new TimeSpan(),
                        //        Items = new List<TransactionItem>()
                        //            {
                        //                new TransactionItem
                        //                        {

                        //                            Id = 1,
                        //                            IdType = "TypeB",
                        //                            UPC = "098765432109",
                        //                            Amount = 5,
                        //                            StandardPrice = 6,
                        //                            AmountPaid = 6,
                        //                            Qty = 2,
                        //                            QtyType = "Piece",
                        //                            ItemWeight = 0,
                        //                            ItemType = "Grocery",
                        //                            DeptId = 102,
                        //                            FamilyCode1 = "FC3",
                        //                            FamilyCode2 = "FC4",
                        //                            SaleType = "Retail",
                        //                            CoPrefix = "PrefixB",
                        //                            LineID = "Line2",
                        //                            IsDiscountable = false,
                        //                            Weightunit = "kg"


                        //                           }
                        //},
                        //        TransactionTotalAmount = 29,
                        //        TransactionTaxAmount = 49,
                        //        TransactionGrossTotal = 49,
                        //        PhoneNumber = "9959608677",
                        //        Tenders = new List<TransactionTender>()
                        //                 {
                        //                        new TransactionTender
                        //                        {
                        //                            Type = "CreditCard",
                        //                            Amount = 0,
                        //                        }
                        //                },
                        //        TenderType = "CreditCard",
                        //        PosType = jsonData.POSType,
                        //        DBInstanceName = jsonData.DBInstanceName,
                        //        DBName = jsonData.DBName,
                        //        IsMemberTransaction = false,
                        //        Coupons = new List<AppliedCoupon>()
                        //                {
                        //                         new AppliedCoupon
                        //                         {
                        //                               PromotionId = "promo123",
                        //                               IdType = "Coupon",
                        //                               Title = "10% Off",
                        //                               Items = new List<CouponLineItem>()
                        //                                        {
                        //                                             new CouponLineItem
                        //                                             {
                        //                                                 LineId = 1,
                        //                                                 DiscountAmount = 2,
                        //                                                 Quantity = 1
                        //                                             }
                        //                                         },
                        //                               TotalDiscount = 2,
                        //                               CouponTypeId = 1,
                        //                               AppliedCount = 1,
                        //                               CouponType = "Discount",
                        //                               CouponSource = "POS",
                        //                               QualifiedLineIds = "1",
                        //                               QualifiedUPCs = "123456789012",
                        //                               IsAppliedAtPOS = true
                        //                         }
                        //                 },
                        //        Promotions = new List<AppliedPromotion>()
                        //                  {
                        //                         new AppliedPromotion
                        //                         {

                        //                            PromotionId = "promo123",
                        //                            IdType = "Promotion",
                        //                            Title = "10% Off",
                        //                            Items = new List<CouponLineItem>()
                        //                                    {
                        //                                        new CouponLineItem
                        //                                        {
                        //                                            LineId = 1,
                        //                                            DiscountAmount = 2,
                        //                                            Quantity = 1
                        //                                        }
                        //                                     },
                        //                            TotalDiscount = 2,
                        //                            CouponTypeId = 1,
                        //                            AppliedCount = 1,
                        //                            CouponType = "Discount",
                        //                            CouponSource = "POS",
                        //                            QualifiedLineIds = "1",
                        //                            QualifiedUPCs = "123456789012",
                        //                            IsAppliedAtPOS = true
                        //                         }
                        //                     },
                        //        //CommitRequest = null,
                        //        CommitRequest = commitData,

                        //        CloudRetailerName = "rsaecrsapidemo",
                        //        CloudFileName = "retailer03",
                        //        CloudFolderName = "Commit"



                        //    };

                        }
                    }



                    var jsonTransactiondata = JsonConvert.SerializeObject(transactiondata);

                    var BucketName = transactiondata?.CloudRetailerName;
                    var FileName = transactiondata?.CloudFileName;
                    // var FolderName = transactiondata.CloudFolderName;
                    var FolderName = "Commit";
                    var StoreId = transactiondata?.StoreId;
                    var TransactionDate = transactiondata?.TransactionDate.ToString("MMddyyyy");
                    var Key = $"{FolderName}/{TransactionDate}/{StoreId}/{FileName}";
                  
                    var savedCommitData = await _s3BucketHelpers.SaveS3BucketObject(BucketName, Key, jsonTransactiondata);
                    // var deleteOldTransactiondata = await _s3BucketHelpers.DeleteBucketObject(bucketName, key);
                    if (savedCommitData.Status == "Success")
                    {
                        commitResponse.ErrorCode = savedCommitData.ErrorCode;
                        commitResponse.ErrorDesc = savedCommitData.ErrorDesc;
                        commitResponse.Status = savedCommitData.Status;
                        return commitResponse;
                    }
                    commitResponse.ErrorCode = savedCommitData.ErrorCode;
                    commitResponse.ErrorDesc = savedCommitData.ErrorDesc;
                    commitResponse.Status = "Failed";
                    return commitResponse;



                }


                commitResponse.ErrorCode = "400";
                commitResponse.ErrorDesc = "Something went wrong. Please try again.";
                commitResponse.Status = "Failed";
                return commitResponse;


            }

            catch (Exception ex)
            {
                commitResponse.ErrorCode = "500";
                commitResponse.ErrorDesc = ex.Message;
                commitResponse.Status = "Internel server error";

            }
            return commitResponse;
        }

        public async Task<BucketResponse> CreateBucket(string bucketName)
        {
            BucketResponse response = new BucketResponse();
            try
            {
                //var bucketExists = await Amazon.S3.Util.AmazonS3Util.DoesS3BucketExistV2Async(_amazonS3, bucketName);
               
                var listOfBuckets = await _amazonS3.ListBucketsAsync();

            
                var existBucket = listOfBuckets.Buckets.Any(b => b.BucketName == bucketName);
                if (existBucket)
                {
                    response.ErrorCode = "400";
                    response.ErrorDesc = $"Bucket {bucketName} already existed.";
                    response.Status = "Failed";
                    return response;
                }
                var putBucketRequest = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true,
                };

                await _amazonS3.PutBucketAsync(putBucketRequest);
                response.ErrorCode = "200";
                response.ErrorDesc = $"Bucket {bucketName} created successfully.";
                response.Status = "Success";

            }
            catch (Exception ex)
            {
                response.ErrorCode = "500";
                response.ErrorDesc = ex.Message;
                response.Status = "Internel server error";
            }
            return response;
        }

        public async Task<BucketResponse> DeleteBucket(string bucketName)
        {
            BucketResponse response = new BucketResponse();
            try
            {
                await _amazonS3.DeleteBucketAsync(bucketName);

                response.ErrorCode = "200";
                response.ErrorDesc = $"Bucket {bucketName} deleted successfully.";
                response.Status = "Success";
            }
            catch (Exception ex)
            {
                response.ErrorCode = "500";
                response.ErrorDesc = "";
                response.Status = "Internel server error";
            }
            return response;
        }


    }
}
