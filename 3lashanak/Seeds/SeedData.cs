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
                Packages packages = new Packages
                {
                    Title = "الباقة الربع سنوية",
                    Description = "الخدمة الأولى",
                    Price = 200,
                    IsMajor = true,
                };
                List<Packages> lstPackages = new List<Packages>();
                lstPackages.Add(packages);
                lstPackages.Add(packages);
                lstPackages.Add(packages);
                _context.Packages.AddRange(lstPackages);
            }

            ////////fill Partners
            if (_context.Partners.Any())
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
                    Icon = "/Index/images/service2.svg",
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
            if(!_context.Settings.Any(x => x.Key == "who"))
            {
                List<Settings> lstSettings = new List<Settings>();
                lstSettings.Add(new Settings
                {
                    Key = "who",
                    Name = "من نحن",
                    Icon = "/Index/images/Cars.png",
                    Type = TypeSettings.Text,
                    Value = "على الرغم من تمتع كل من المؤسسات الخمس المؤلفة لمجموعة البنك الدولي بهيكل عضوية خاص بها بالنسبة للبلدان الأعضاء، ومجالس الإدارة، واتفاقيات التأسيس الخاصة بكل منها، لكنها تعمل كوحدة واحدة لخدمة البلدان الشريكة معها. ومن غير الممكن مواجهة التحديات الإنمائية اليوم من دون أن يكون القطاع الخاص جزءاً من الحل. لكن القطاع العام هو من يرسي الأساس لتمكين استثمارات القطاع الخاص والسماح له بالنمو والازدهار. وتعطي الأدوار التكاملية لمؤسسات مجموعة البنك الدولي قدرة فريدة للمجموعة لربط الموارد المالية العالمية باحتياجات البلدان النامية. يشكل البنك الدولي للإنشاء والتعمير والمؤسسة الدولية للتنمية معًا البنك الدولي وهما يقدمان التمويل والمشورة بشأن السياسات والمساعدة الفنية",
                });
                _context.Settings.AddRange(lstSettings);
            }
            

            ////////fill Settings Footer
            if(!_context.Settings.Any(x => x.Key == "TitleFooter1"&& x.Key == "TitleFooter2" && x.Key== "TitleFooter3"))
            {
                List<Settings> lstSettingsFooter = new List<Settings>();
                lstSettingsFooter.Add(new Settings
                {
                    Key = "TitleFooter1",
                    Name = "العنوان الأول ",
                    Type = TypeSettings.Text,
                    Value = "حمل التطبيق الان"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "TitleFooter1",
                    Name = "العنوان الأول ",
                    Icon = "/Index//images/mobile.png",
                    Type = TypeSettings.Text,
                    Value = "حمل التطبيق الان"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "TitleFooter2",
                    Name = "العنوان الثاني ",
                    Type = TypeSettings.Text,
                    Value = "تمتع بخدمات الطريق أينما كنت"
                });
                lstSettingsFooter.Add(new Settings
                {
                    Key = "TitleFooter3",
                    Name = "العنوان الثالث ",

                    Type = TypeSettings.Text,
                    Value = "سعر واحد طيلة العام"
                });
                _context.Settings.AddRange(lstSettingsFooter);
            }
           


            _context.SaveChanges();
        }
    }
}
