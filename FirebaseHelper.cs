using System;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using Firebase.Storage;

namespace CAS
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://casdatabase-215ee-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task AddRecord(string id, string name, string model)
        {
            await firebase
                .Child("CarSpec")
                .PostAsync(new CarSpecs() { ID = id, Name = name, Model = model});
        }

        public async Task<List<CarSpecs>> GetAllCASRecord()
        {
            return (await firebase
                .Child("CarSpec")
                .OnceAsync<CarSpecs>()).Select(item => new CarSpecs
                {
                    ID = item.Object.ID,
                    Name = item.Object.Name,
                    Model = item.Object.Model,
                    Favorite = item.Object.Favorite,
                    Image1 = item.Object.Image1,
                    Price = item.Object.Price,
                    Brand = item.Object.Brand,
                    BodyType = item.Object.BodyType,
                    Segment = item.Object.Segment,
                    Engine = item.Object.Engine,
                    Dimension = item.Object.Dimension,
                    Fueltank = item.Object.Fueltank,
                    TopSpeed = item.Object.TopSpeed,
                    Feature = item.Object.Feature,
                    ImageFront = item.Object.ImageFront,
                    ImageBack = item.Object.ImageBack,
                    ImageSide = item.Object.ImageSide,
                    Ytlink = item.Object.Ytlink,
                    Website = item.Object.Website
                }).ToList();
        }

        public async Task<List<CarSpecs2>> GetAllCASRecord2()
        {
            return (await firebase
                .Child("CarSpec")
                .OnceAsync<CarSpecs2>()).Select(item => new CarSpecs2
                {
                    ID = item.Object.ID,
                    Name = item.Object.Name,
                    Model = item.Object.Model,
                    Favorite = item.Object.Favorite,
                    Image1 = item.Object.Image1,
                    Price = item.Object.Price,
                    Brand = item.Object.Brand,
                    BodyType = item.Object.BodyType,
                    Segment = item.Object.Segment,
                    Engine = item.Object.Engine,
                    Dimension = item.Object.Dimension,
                    Fueltank = item.Object.Fueltank,
                    TopSpeed = item.Object.TopSpeed,
                    Feature = item.Object.Feature,
                    ImageFront = item.Object.ImageFront,
                    ImageBack = item.Object.ImageBack,
                    ImageSide = item.Object.ImageSide,
                    Ytlink = item.Object.Ytlink
                }).ToList();
        }



        public async Task<List<CarSpecs>> GetFindRecord(string bmistatus)
        {
            var allCASRecord = await GetAllCASRecord();
            await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs>();
            return allCASRecord.Where(a => a.Favorite == bmistatus).ToList();
        }

        public async Task<List<CarSpecs2>> GetFindRecordID2(string id)
        {
            var allCASRecord = await GetAllCASRecord2();
            await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs2>();
            return allCASRecord.Where(a => a.ID == id).ToList();

        }

        public async Task<List<CarSpecs>> GetFindRecordID(string id)
        {
            var allCASRecord = await GetAllCASRecord();
            await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs>();
            return allCASRecord.Where(a => a.ID == id).ToList();


        }

        public async Task<List<CarSpecs>> GetFindKeyword(string kw)
        {
            var allCASRecord = await GetAllCASRecord();
            await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs>();
            return allCASRecord.Where(a => a.Feature == kw).ToList();


        }

        public async Task<List<CarSpecs>> GetFindBrand(string kw)
        {
            var allCASRecord = await GetAllCASRecord();
            await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs>();
            return allCASRecord.Where(a => a.Brand == kw).ToList();


        }

        public async Task<List<CarSpecs>> GetFindBodyType(string kw)
        {
            var allCASRecord = await GetAllCASRecord();
            await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs>();
            return allCASRecord.Where(a => a.BodyType == kw).ToList();


        }


        public async Task UpdatePerson(string Id, string fav, string namereceive, string modelreceive, string pricereceive, string brandreceive, string bodytypereceive, string segmentreceive, string enginereceive, string dimensionreceive, string fueltankreceive, string topspeedreceive, string featurereceive, string imagefrontreceive, string imagebackreceive, string imagesidereceive, string imagereceive, string ytlinkreceive, string websitereceive)
        {
            var toUpdatePerson = (await firebase
              .Child("CarSpec")
              .OnceAsync<CarSpecs>()).Where(a => a.Object.ID == Id).FirstOrDefault();

            await firebase
              .Child("CarSpec")
              .Child(toUpdatePerson.Key)
              .PutAsync(new CarSpecs() { ID = Id, Favorite = fav, Name = namereceive, Model = modelreceive, Price = pricereceive, Brand=brandreceive, BodyType = bodytypereceive, Segment = segmentreceive, Engine = enginereceive, Dimension = dimensionreceive, Fueltank = fueltankreceive, TopSpeed = topspeedreceive, Feature = featurereceive, Image1 = imagereceive, ImageFront = imagefrontreceive , ImageBack = imagebackreceive, ImageSide = imagesidereceive, Ytlink = ytlinkreceive, Website = websitereceive });
        }
    }
}
