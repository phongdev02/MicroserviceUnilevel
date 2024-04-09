using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Models;

namespace UserService.Service.SetFunc
{
    public class SeedData
    {
        private IServiceProvider services;

        public SeedData(IServiceProvider services)
        {
            this.services = services;
            Initialize();
        }

        public void Initialize()
        {
            using (var scope = services.CreateScope())
            {
                //setting database
                var serviceProvider = scope.ServiceProvider;
                var _context = serviceProvider.GetRequiredService<AppDBContext>();

                var _quyen = _context.quyens.Any();
                var _nhomquyen = _context.nhomQuyenTruyCap.Any();
                var _quyentruycap = _context.quyenTruyCaps.Any();

                if (!_quyen)
                {
                    _context.quyens.AddRange(createQuyens());
                    _context.SaveChanges();
                }

                if (!_nhomquyen)
                {
                    _context.nhomQuyenTruyCap.AddRangeAsync(createNhomquyenTruycaps());
                    _context.SaveChanges();
                }

                if (!_quyentruycap)
                {
                    _context.quyenTruyCaps.AddRangeAsync(createQuyenTruyCaps());
                    _context.SaveChanges();
                }
            }
        }

        public List<NhomQuyenTruyCap> createNhomquyenTruycaps()
        {
            var listOfObjects = new List<NhomQuyenTruyCap>
            {
                new NhomQuyenTruyCap
                {
                    TenNq = "System configuration"
                },
                new NhomQuyenTruyCap
                {
                    TenNq = "Distributors"
                },
                new NhomQuyenTruyCap
                {
                    TenNq = "Areos"
                },
                new NhomQuyenTruyCap
                {
                    TenNq = "CMS"
                },
                new NhomQuyenTruyCap
                {
                    TenNq = "Survey"
                },
                new NhomQuyenTruyCap
                {
                    TenNq = "Notifications"
                }
            };
            return listOfObjects;
        }
        public List<Quyen> createQuyens()
        {
            var listOfObjects = new List<Quyen>
            {
                new Quyen
                {
                    //add
                    TenQuyen = "POST"
                },
                new Quyen
                {
                    //edit
                    TenQuyen = "PUT"
                },
                new Quyen
                {
                    //delete
                    TenQuyen = "DELETE"
                },
                new Quyen
                {
                    //get
                    TenQuyen = "GET"
                },
                new Quyen
                {
                    //get
                    TenQuyen = "PUBLISH"
                }
            };
            return listOfObjects;
        }
        public List<QuyenTruyCap> createQuyenTruyCaps()
        {
            var listOfObjects = new List<QuyenTruyCap>
            {
                // configuration
                new QuyenTruyCap
                {
                    TenQuyenTc = "Edit system configuration",
                    QuyenId = 2,
                    NhomQuyenId = 1,
                },
                //distributor
                new QuyenTruyCap
                {
                    TenQuyenTc = "Create new distributor",
                    QuyenId = 1,
                    NhomQuyenId = 2,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Update detail distributor",
                    QuyenId = 2,
                    NhomQuyenId = 2,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Delete distributor",
                    QuyenId = 3,
                    NhomQuyenId = 2,
                },
                //Areas
                new QuyenTruyCap
                {
                    TenQuyenTc = "Create new Areas",
                    QuyenId = 1,
                    NhomQuyenId = 3,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Update area detail",
                    QuyenId = 2,
                    NhomQuyenId = 3,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Delete area",
                    QuyenId = 3,
                    NhomQuyenId = 3,
                },
                //CMS
                new QuyenTruyCap
                {
                    TenQuyenTc = "Create new CMS",
                    QuyenId = 1,
                    NhomQuyenId = 4,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Update acticle detail",
                    QuyenId = 2,
                    NhomQuyenId = 4,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Remove unpublish article",
                    QuyenId = 3,
                    NhomQuyenId = 4,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Edit system configuration",
                    QuyenId = 4,
                    NhomQuyenId = 4,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Publist existing article",
                    QuyenId = 5,
                    NhomQuyenId = 4,
                },
                //Survey
                new QuyenTruyCap
                {
                    TenQuyenTc = "Create new survey",
                    QuyenId = 1,
                    NhomQuyenId = 5,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Send survey request",
                    QuyenId = 1,
                    NhomQuyenId = 5,
                },
                new QuyenTruyCap
                {
                    TenQuyenTc = "Send survey request",
                    QuyenId = 4,
                    NhomQuyenId = 5,
                },
                //notifications
                new QuyenTruyCap
                {
                    TenQuyenTc = "Create Notification",
                    QuyenId = 1,
                    NhomQuyenId = 6,
                },
            };
            return listOfObjects;
        }
    }
}
