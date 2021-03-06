using _3lashanak.Data;
using _3lashanak.Models;
using System.Collections.Generic;
using System.Linq;

namespace _3lashanak.Seeds
{
    public static class SeedData
    {

        

        public static void Seed(ApplicationDbContext context)
        {
            FillData(context);
        }

        public static void FillData(ApplicationDbContext _context)
        {
            ////////fill Packages
            if (!_context.Packages.Any())
            {
                Packages package1 = new Packages
                {
                    Title = "الباقة الربع سنوية",
                    Description = "الخدمة الأولى",
                    Price = 200,
                    IsMajor = false,
                    UrlButton = "https://www.google.com"
                };
                Packages package2 = new Packages
                {
                    Title = "الباقة الربع سنوية",
                    Description = "الخدمة الثانية",
                    Price = 200,
                    IsMajor = false,
                    UrlButton = "https://www.google.com"
                };
                Packages package3 = new Packages
                {
                    Title = "الباقة الربع سنوية",
                    Description = "الخدمة الثالثة",
                    Price = 200,
                    IsMajor = true,
                    UrlButton = "https://www.google.com"
                };
                List<Packages> lstPackages = new List<Packages>();
                lstPackages.Add(package1);
                lstPackages.Add(package2);
                lstPackages.Add(package3);
                _context.Packages.AddRange(lstPackages);
            }

            ////////fill Partners
            if (!_context.Partners.Any())
            {
                List<Partners> lstPackages = new List<Partners>();
                Partners partner1 = new Partners
                {
                    Image = "/Index/images/totalLogo.png"
                };
                Partners partner2 = new Partners
                {
                    Image = "/Index/images/hankookLogo.png"
                };

                lstPackages.Add(partner1);
                lstPackages.Add(partner2);
                _context.Partners.AddRange(lstPackages);
            }
         
          

            ////////fill Services
            if (!_context.Services.Any())
            {
                List<Service> lstServices = new List<Service>();
                lstServices.Add(new Service
                {
                    Title = "تغيير الإطارات",
                    Description = "وصف عن الخدمة والتفاصيل التي تقدمها تحديداً بشكل موجز",
                    Icon = "/Index/images/service1.svg",
                });
                lstServices.Add(new Service
                {
                    Title = "تغيير الإطارات",
                    Description = "وصف عن الخدمة والتفاصيل التي تقدمها تحديداً بشكل موجز",
                    Icon = "\\Index\\images\\services2.svg",
                });
                lstServices.Add(new Service
                {
                    Title = "تغيير الإطارات",
                    Description = "وصف عن الخدمة والتفاصيل التي تقدمها تحديداً بشكل موجز",
                    Icon = "/Index/images/service3.svg",
                });
                lstServices.Add(new Service
                {
                    Title = "تغيير الإطارات",
                    Description = "وصف عن الخدمة والتفاصيل التي تقدمها تحديداً بشكل موجز",
                    Icon = "/Index/images/service4.svg",
                });
                _context.Services.AddRange(lstServices);
            }
           

            ////////fill Settings who are we
            if(!_context.Settings.Any(x => x.Key == "من نحن"))
            {
                List<Settings> lstSettings = new List<Settings>();
                lstSettings.Add(new Settings
                {
                    Key = "من نحن",
                    Name = "الشركة الأولى لتقديم خدمات الطريق في الوطن العربي",
                    Icon = "/Index/images/Cars.png",
                    Type = TypeSettings.Text,
                    Value = "على الرغم من تمتع كل من المؤسسات الخمس المؤلفة لمجموعة البنك الدولي بهيكل عضوية خاص بها بالنسبة للبلدان الأعضاء، ومجالس الإدارة، واتفاقيات التأسيس الخاصة بكل منها، لكنها تعمل كوحدة واحدة لخدمة البلدان الشريكة معها. ومن غير الممكن مواجهة التحديات الإنمائية اليوم من دون أن يكون القطاع الخاص جزءاً من الحل. لكن القطاع العام هو من يرسي الأساس لتمكين استثمارات القطاع الخاص والسماح له بالنمو والازدهار. وتعطي الأدوار التكاملية لمؤسسات مجموعة البنك الدولي قدرة فريدة للمجموعة لربط الموارد المالية العالمية باحتياجات البلدان النامية. يشكل البنك الدولي للإنشاء والتعمير والمؤسسة الدولية للتنمية معًا البنك الدولي وهما يقدمان التمويل والمشورة بشأن السياسات والمساعدة الفنية",
                });
                _context.Settings.AddRange(lstSettings);
            }
            

            ////////fill Settings Footer
            if(!_context.Settings.Any(x => x.Key == "زر الهيدر" || x.Key == "زر الهيرو" || x.Key == "الهيدر" || x.Key == "الوصف"))
            {
                List<Settings> lstSettingsFooter = new List<Settings>();
                lstSettingsFooter.Add(new Settings
                {
                    Key = "زر الهيدر",
                    Name = "حمل التطبيق الآن",
                    Type = TypeSettings.Button,
                    Value = "www.google.com"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "زر الهيرو",
                    Name = "حمل التطبيق الآن",
                    Icon = "/Index/images/mobile.png",
                    Type = TypeSettings.Button,
                    Value = "www.google.com"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "الهيدر",
                    Name = "لا تشيل هم الطريق، خلِه علينا",
                    Type = TypeSettings.Text,
                    Value = "علينا",
                    Icon = "/Index/images/Cars.png"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "الوصف",
                    Name = "تمتّع بخدمة أفضل الفنّيين لأعطال السيارات",

                    Type = TypeSettings.Text,
                    Value = "في أي وقت وأي مكان في ارجاء المملكة !"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "قوقل",
                    Name="جوجل",
                    Icon = "/Index/images/install GooglePaly.png",
                    Type = TypeSettings.Text,
                    Value = "www.google.com"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "ابل",
                    Name = "ابل",
                    Icon = "/Index/images/install IOS.png",
                    Type = TypeSettings.Text,
                    Value = "www.apple.com"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "صورة هاتف",
                    Name = "صورة هاتف",
                    Icon = "/Index/images/mobile.png",
                    Type = TypeSettings.Text,
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "لوغو1",
                    Name = "صورة لوغو سفلي1",
                    Icon = "/Index/images/mobile.png",
                    Type = TypeSettings.Text,
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "لوغو2",
                    Name = "صورة لوغو سفلي2",
                    Icon = "/Index/images/mobile.png",
                    Type = TypeSettings.Text,
                });
                _context.Settings.AddRange(lstSettingsFooter);
            }

            if (!_context.SocialMedia.Any())
            {
                SocialMedia social1 = new SocialMedia
                {
                    Logo = "/Index/images/linkedIn.png",
                    Title = ""
                };
                SocialMedia social2 = new SocialMedia
                {
                    Logo = "/Index/images/twitter.png",
                    Title = ""
                };
                SocialMedia social3 = new SocialMedia
                {
                    Logo = "/Index/images/Instegram.png",
                    Title = ""
                };
                SocialMedia social4 = new SocialMedia
                {
                    Logo = "/Index/images/facebook.png",
                    Title = ""
                };
                List<SocialMedia> lstSocialMedia = new List<SocialMedia>();
                lstSocialMedia.Add(social1);
                lstSocialMedia.Add(social2);
                lstSocialMedia.Add(social3);
                lstSocialMedia.Add(social4);
                _context.SocialMedia.AddRange(lstSocialMedia);
            }

            _context.SaveChanges();
        }
    }
}
