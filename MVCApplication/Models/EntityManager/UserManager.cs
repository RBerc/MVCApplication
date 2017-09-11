using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCApplication.Models.DB;
using MVCApplication.Models.ViewModel;

namespace MVCApplication.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignupView user)
        {

            using (DemoDBEntities db = new DemoDBEntities())
            {

                SYSUser SU = new SYSUser();
                SU.LoginName = user.LoginName;
                SU.PasswordEncryptedText = user.Password;
                SU.RowCreatedSYSUserID = user.SysUserId > 0 ? user.SysUserId : 1;
                SU.RowModifiedSYSUserID = user.SysUserId > 0 ? user.SysUserId : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;

                db.SYSUsers.Add(SU);
                db.SaveChanges();

                SYSUserProfile SUP = new SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.FirstName = user.FirstName;
                SUP.LastName = user.LastName;
                SUP.Gender = user.Gender;
                SUP.RowCreatedSYSUserID = user.SysUserId > 0 ? user.SysUserId : 1;
                SUP.RowModifiedSYSUserID = user.SysUserId > 0 ? user.SysUserId : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;

                db.SYSUserProfiles.Add(SUP);
                db.SaveChanges();


                if (user.LOOKUPROleID > 0)
                {
                    SYSUserRole SUR = new SYSUserRole();
                    SUR.LOOKUPRoleID = user.LOOKUPROleID;
                    SUR.SYSUserID = user.SysUserId;
                    SUR.IsActive = true;
                    SUR.RowCreatedSYSUserID = user.SysUserId > 0 ? user.SysUserId : 1;
                    SUR.RowModifiedSYSUserID = user.SysUserId > 0 ? user.SysUserId : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;

                    db.SYSUserRoles.Add(SUR);
                    db.SaveChanges();
                }
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                return db.SYSUsers.Where(o => o.LoginName.Equals(loginName)).Any();
            }
        }
    }
}