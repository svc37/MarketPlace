using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Repository
{
    public class SessionHelper
    {
        private static string _companyId;
        public static int CompanyId
        { 
            get
            {
                if (!string.IsNullOrEmpty(_companyId))
	            {
                    return int.Parse(_companyId);
	            }
                else
                {
                    return 0;
                }
            }
        }

        public static void SetCompanyId(int companyId)
        {
            _companyId = companyId.ToString();
        }

        private static string _projectId;
        public static int ProjectId
        {
            get
            {
                if (!string.IsNullOrEmpty(_projectId))
                {
                    return int.Parse(_projectId);
                }
                else
                {
                    return 0;
                }
            }
        }

        public static void SetProjectId(int projectId)
        {
            _projectId = projectId.ToString();
        }


        private static string _currentUser;
        public static string CurrentUser
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentUser))
                {
                    return _currentUser;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public static void SetCurrentUser(string userEmail)
        {
            _currentUser = userEmail;
        }

    }
}
