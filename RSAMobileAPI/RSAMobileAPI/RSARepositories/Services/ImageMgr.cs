using RSAMobileAPI.RSARepositories.Interfaces;

namespace RSAMobileAPI.RSARepositories.Services
{
    public class ImageMgr : IImageMgr
    {
        public ImageMgr(ConfigurationHelper configurationHelper)
        {
            ConfigurationHelper = configurationHelper;
        }

        public ConfigurationHelper ConfigurationHelper { get; }

        public  string GetImageUrl(int userId, EnumMgr.UploadLocations uploadLocation,string ImageName, bool useThumbNail)
        {
            string imageUrl = string.Empty;
            if(string.IsNullOrEmpty(ImageName) == true)
            {
              switch(uploadLocation)
                {
                    case EnumMgr.UploadLocations.CompanyLogo:
                        return string.Concat(imageUrl, "/",ConstantMgr.COMPANY_FOLDER_NAME,"/",ConstantMgr.CompanyLogo);
                }
                return string.Empty;
            }
            string thumbNailImageForExtension = string.Empty;
            if(useThumbNail == true)
            {
                thumbNailImageForExtension = GetThumbNailLogo(Path.GetExtension(ImageName));
            }
            switch (ConfigurationHelper.FileUploadMode)
            {
                case EnumMgr.FileUploadMode.LocalFileSystem:
                    imageUrl = ConfigurationHelper.WebSiteUrl;

                    switch (uploadLocation)
                    {
                        case EnumMgr.UploadLocations.CompanyLogo:
                            imageUrl = String.Concat(imageUrl, "/", ConstantMgr.COMPANY_FOLDER_NAME, "/", ImageName);//String.Concat(ConstantMgr.COMPANY_FOLDER_NAME, ImageName);
                            break;
                        case EnumMgr.UploadLocations.ClientLogo:
                            imageUrl = String.Concat(imageUrl, "/", ConstantMgr.CLIENT_FOLDER_NAME, "/", ImageName); //String.Concat(ConstantMgr.CLIENT_FOLDER_NAME, ImageName);
                            break;
                        case EnumMgr.UploadLocations.ProductsLogo:
                            imageUrl = String.Concat(imageUrl, "/", ConstantMgr.PRODUCT_FOLDER_NAME, "/", ImageName); // String.Concat(ConstantMgr.PRODUCT_FOLDER_NAME, ImageName); // ImageName; 
                            break;
                        case EnumMgr.UploadLocations.SpecialsLogo:
                            imageUrl = String.Concat(imageUrl, "/", ConstantMgr.SPECIALS_FOLDER_NAME, "/", ImageName); // String.Concat(ConstantMgr.SPECIALS_FOLDER_NAME, ImageName); // ImageName; 
                            break;
                        case EnumMgr.UploadLocations.BarcodeLogo:
                            imageUrl = String.Concat(imageUrl, "/", ConstantMgr.BarCode_FOLDER_NAME, "/", ImageName); // String.Concat(ConstantMgr.PRODUCT_FOLDER_NAME, ImageName); // ImageName; 
                            break;
                        case EnumMgr.UploadLocations.WeeklySpecialsLogo:
                            imageUrl = String.Concat(imageUrl, "/", ConstantMgr.AMZ_WEEKLYSPECIALS_FOLDER_NAME, "/", ImageName); // String.Concat(ConstantMgr.PRODUCT_FOLDER_NAME, ImageName); // ImageName; 
                            break;
                            //case EnumMgr.UploadLocations.ApplicationImage:
                            //    if (useThumbNail == true)
                            //    {
                            //        if (String.IsNullOrEmpty(thumbNailImageForExtension))
                            //        {
                            //            imageUrl = String.Concat(ConstantMgr.APPLICATION_IMAGES_PATH, "thumb_", ImageName);
                            //        }
                            //        else
                            //        {
                            //            //if (ConfigurationHelper.IsForWebService)
                            //            //{
                            //            //    imageUrl = String.Concat(ConstantMgr.APPLICATION_IMAGES_PATH, "thumb_", ImageName);
                            //            //}
                            //            //else
                            //            //{
                            //                imageUrl = thumbNailImageForExtension != null ? thumbNailImageForExtension : String.Empty;
                            //           // }
                            //        }
                            //    }
                            //    else
                            //        imageUrl = String.Concat(ConstantMgr.APPLICATION_IMAGES_PATH, ImageName);
                            //    break;
                    }
                    break;
                case EnumMgr.FileUploadMode.DataBase:
                    if (useThumbNail == true)
                    {
                        if (string.IsNullOrEmpty(thumbNailImageForExtension) == true)
                        {
                            imageUrl = string.Concat("~/ImageViewer/Details?type=", Convert.ToString((int)uploadLocation), "&name=", ImageName, "&thumbNail=", useThumbNail.ToString());
                            
                        }
                        else
                        {
                            imageUrl = thumbNailImageForExtension !=null ? thumbNailImageForExtension : string.Empty;
                        }
                    }
                    else
                    {
                        imageUrl = string.Concat("~/ImageViewer/Details?type=", Convert.ToString((int)uploadLocation), "&name=", ImageName, "&thumbNail=", useThumbNail.ToString());


                    }
                    break;
                case EnumMgr.FileUploadMode.AmazonS3:
                    string bucketName = ConfigurationHelper.AmazonBucketName;
                    string folderName = string.Empty;
                    imageUrl = string.Concat(ConfigurationHelper.AmazonS3Url, ConfigurationHelper.AmazonBucketName);
                   switch(uploadLocation)
                    {
                        case EnumMgr.UploadLocations.CompanyLogo:
                            imageUrl = string.Concat(imageUrl, "/", ConstantMgr.AMZ_COMPANY_FOLDER_NAME, "/", ImageName);
                            break;
                        case EnumMgr.UploadLocations.ClientLogo:
                            imageUrl = string.Concat(imageUrl, "/", ConstantMgr.AMZ_CLIENT_FOLDER_NAME, "/", ImageName);
                            break;
                        case EnumMgr.UploadLocations.ProductsLogo:
                            imageUrl = string.Concat(imageUrl, "/", ConstantMgr.AMZ_PRODUCT_FOLDER_NAME, "/", ImageName);
                            break;
                        case EnumMgr.UploadLocations.SpecialsLogo:
                            imageUrl = string.Concat(imageUrl, "/", ConstantMgr.AMZ_SPECIALS_FOLDER_NAME, "/", ImageName);
                            break;
                        case EnumMgr.UploadLocations.BarcodeLogo:
                            imageUrl = string.Concat(imageUrl, "/", ConstantMgr.AMZ_Barcode_FOLDER_NAME, "/", ImageName);
                            break;
                        case EnumMgr.UploadLocations.WeeklySpecialsLogo:
                            imageUrl = string.Concat(imageUrl, "/", ConstantMgr.AMZ_WEEKLYSPECIALS_FOLDER_NAME, "/", ImageName);
                            break;

                    }
                    break;
            }
            return imageUrl;
        }

        public string GetThumbNailLogo(string extension)
        {
            string imageUrl = string.Empty;

            switch (extension.ToUpper())
            {
                case ".GIF":
                case ".PNG":
                case ".JPEG":
                case ".TIFF":
                case ".TIF":
                    imageUrl = string.Empty;
                    break;
                case ".PDF":
                    imageUrl = string.Concat(ConstantMgr.SITE_IMAGES_FOLDER, ConstantMgr.PDF_LOGO);
                    break;
                case ".XLS":
                case ".XLSX":
                    imageUrl = string.Concat(ConstantMgr.SITE_IMAGES_FOLDER, ConstantMgr.EXCEL_LOGO);
                    break;
                case ".DOC":
                case ".DOCX":
                    imageUrl = string.Concat(ConstantMgr.SITE_IMAGES_FOLDER, ConstantMgr.WORD_LOGO);
                    break;
                case ".CAF":
                case ".AAC":
                case ".M4A":
                case ".MIDI":
                case ".IMA4":
                case ".TXT":
                case ".MOV":
                    imageUrl = string.Concat(ConstantMgr.SITE_IMAGES_FOLDER, ConstantMgr.UNKNOWN_FILETYPE);
                    break;
                case ".3GPP":
                case ".MP3":
                case ".WAV":
                case ".3GP":
                case ".3GA":
                    imageUrl = string.Concat(ConstantMgr.SITE_IMAGES_FOLDER, ConstantMgr.AUDIO_LOGO);
                    break;
                case ".MP4":
                    imageUrl = string.Concat(ConstantMgr.SITE_IMAGES_FOLDER,ConstantMgr.VIDEO_LOGO);
                    break;
                    
            }
            return imageUrl;
        }

        public string GetFileExtensionType(string FileName)
        {

            string fileExtentionType = string.Empty;
            string extensionType = string.Empty;
            try
            {
                extensionType = Path.GetExtension(FileName);
                switch (extensionType)
                {
                    case ".pdf":
                    case ".PDF":
                        fileExtentionType = "PDF";
                        break;
                    case ".jpg":
                    case ".JPG":
                        fileExtentionType = "JPG";
                        break;
                    case ".jpeg":
                    case ".JPEG":
                        fileExtentionType = "JPEG";
                        break;
                    case ".png":
                    case ".PNG":
                        fileExtentionType = "PNG";
                        break;
                    default:
                        fileExtentionType = "";
                        break;
                }
            }
            catch (Exception ex)
            {
                fileExtentionType = "";
            }

            return fileExtentionType;

        }
    }
}

