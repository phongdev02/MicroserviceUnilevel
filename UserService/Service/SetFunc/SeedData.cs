using Microsoft.EntityFrameworkCore;
using MimeKit;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System.Collections.Generic;
using System.Reflection;
using UserService.Context;
using UserService.Models;
using UserService.Models.Dto;

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

        public async void Initialize()
        {
            using (var scope = services.CreateScope())
            {
                //setting database
                var serviceProvider = scope.ServiceProvider;
                var _context = serviceProvider.GetRequiredService<AppDBContext>();

                // Lấy tất cả các trường của class UserRoles
                FieldInfo[] lsRole = typeof(Auth).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
                FieldInfo[] lsRoleGroup = typeof(AuthGroup).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                //check group role

                try
                {
                    /*var roleGroup = _context.RoleGroups.ToList();

                    FieldInfo[] lsRoleGroupT = typeof(AuthGroup).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                    foreach (var item in lsRoleGroupT)
                    {
                        if(!roleGroup.Any(t => t.rolegroupName.Equals(item.GetValue(null).ToString(), StringComparison.OrdinalIgnoreCase)))
                        {
                            var itemRoleG = new RoleGroup() { rolegroupName = item.GetValue(null).ToString(),};
                            await _context.RoleGroups.AddAsync(itemRoleG);
                            await _context.SaveChangesAsync();
                        }
                    }

                    await transaction.CommitAsync();*/

                    //list role group user create
                    FieldInfo[] lsRoleGroupT = typeof(AuthGroup).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

                    //list role group in database
                    var roleGroup = _context.RoleGroups;

                    //list role in database
                    var roledb = _context.Roles;

                    await SetValueRoleCMS(_context, roleGroup, roledb);

                }
                catch (Exception ex)
                {
                    throw;
                }

            }
        }

        private async Task<bool> SetValueRoleCMS(AppDBContext _context, IEnumerable<RoleGroup?> roleGroup, IEnumerable<Role?> roledb)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var itemRoleG = roleGroup.FirstOrDefault(rg => rg.rolegroupName.Equals(AuthGroup.CMS));

                    int rolegroupId = 0;

                    if (itemRoleG != null)
                    {
                        rolegroupId = itemRoleG.rolegroupID;
                    }
                    else
                    {
                        var newRoleG = new RoleGroup() { rolegroupName = AuthGroup.CMS };

                        await _context.RoleGroups.AddAsync(newRoleG);
                        await _context.SaveChangesAsync();

                        rolegroupId = newRoleG.rolegroupID;
                    }

                    List<Role> roles = new()
                                {
                                    new Role(){roleName = Auth.CreateNewArticle, rolegroupID = itemRoleG.rolegroupID},
                                    new Role(){roleName = Auth.UpdateArticleDetail, rolegroupID = itemRoleG.rolegroupID},
                                    new Role(){roleName = Auth.PublishExistingArticle, rolegroupID = itemRoleG.rolegroupID},
                                    new Role(){roleName = Auth.RemoveUnpublishArticles, rolegroupID = itemRoleG.rolegroupID}
                                };

                    foreach (var role in roles)
                    {
                        if (!CheckAvailableRole(role, roledb))
                        {
                            await _context.Roles.AddAsync(role);

                            await _context.SaveChangesAsync();
                        }
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return false;
                    throw;
                }
            }
        }
        private async Task<List<Role>> GetValueTest(List<Role> roles, int rolegroupId, List<Role> roledb)
        {
            List<Role> lstam = new List<Role>();

            foreach (var role in roles)
            {
                if (!CheckAvailableRole(role, roledb))
                {
                    lstam.Add(role);
                }
            }

            return lstam;
        }
         
        private bool CheckAvailableRole(Role model, IEnumerable<Role> Models)
        {
            if (Models.Any(item => item.roleId == model.roleId)) {
                return true;
            }
            else
            {
                return false;
            }
        }
/*
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
        }*/
    }
}
