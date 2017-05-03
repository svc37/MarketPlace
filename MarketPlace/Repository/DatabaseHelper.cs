using MarketPlace.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MarketPlace.Repository
{
    public class DatabaseHelper
    {
        private SqlConnection conn;
        //To Handle connection related activities    
        private void DbConnection()
        {
            string constr = ConfigurationManager.ConnectionStrings["DbConn"].ToString();
            conn = new SqlConnection(constr); 

        }


        public int CreateCompany(CompanyViewModel obj)
        {
            DbConnection();
            int companyId = -1971;
            SqlCommand com = new SqlCommand("CreateCompany", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter outPutVal = new SqlParameter("@tableId", System.Data.SqlDbType.Int);

            outPutVal.Direction = System.Data.ParameterDirection.Output;
            com.Parameters.Add(outPutVal);
            com.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            com.Parameters.AddWithValue("@StreetAddress", obj.StreetAddress);
            com.Parameters.AddWithValue("@StreetAddress2", obj.StreetAddress2);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
            com.Parameters.AddWithValue("@Phone", obj.PhoneNumber);

            using (conn)
            {
                conn.Open();
                com.ExecuteNonQuery();
                if (outPutVal.Value != DBNull.Value)
                {
                    companyId = Convert.ToInt32(outPutVal.Value);
                    return companyId;

                }
                return 0;
                

            }

        }

        public bool EditCompany(CompanyViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("EditCompany", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@StreetAddress", obj.StreetAddress);
            com.Parameters.AddWithValue("@StreetAddress2", obj.StreetAddress2);
            com.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
            //com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Phone", obj.PhoneNumber);
            com.Parameters.AddWithValue("@EditedBy", SessionHelper.CurrentUser);

            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public CompanyViewModel GetCompany(int Id)
        {
            CompanyViewModel model = new CompanyViewModel();
            DbConnection();
            SqlCommand com = new SqlCommand("GetCompany", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@ID", Id);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model.Id = int.Parse(reader["ID"].ToString());
                    model.CompanyName = reader["CompanyName"].ToString();
                    model.StreetAddress = reader["StreetAddress"].ToString();
                    model.StreetAddress2 = reader["StreetAddress2"].ToString();
                    model.State = reader["State"].ToString();
                    model.City = reader["City"].ToString();
                    model.ZipCode = reader["ZipCode"].ToString();
                    model.PhoneNumber = reader["Phone"].ToString();
                    //model.Email = reader["Email"].ToString();
                }
            }
            return model;



        }

        //public CompanyViewModel GetUserByEmail(string email)
        //{
        //    CompanyViewModel model = new CompanyViewModel();
        //    DbConnection();
        //    SqlCommand com = new SqlCommand("GetUserByEmail", conn);
        //    com.CommandType = System.Data.CommandType.StoredProcedure;

        //    using (conn)
        //    {
        //        conn.Open();
        //        com.Parameters.AddWithValue("@Email", email);
        //        SqlDataReader reader = com.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            model.Id = int.Parse(reader["ID"].ToString());
        //            model.CompanyName = reader["CompanyName"].ToString();
        //            model.StreetAddress = reader["StreetAddress"].ToString();
        //            model.StreetAddress2 = reader["StreetAddress2"].ToString();
        //            model.State = reader["State"].ToString();
        //            model.City = reader["City"].ToString();
        //            model.ZipCode = reader["ZipCode"].ToString();
        //            model.PhoneNumber = reader["Phone"].ToString();
        //            model.Email = reader["Email"].ToString();
        //        }
        //    }
        //    return model;

        //}


        public bool CreateProject(ProjectViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("CreateProject", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CompanyId", obj.CompanyId);
            com.Parameters.AddWithValue("@CreatedBy", SessionHelper.CurrentUser); 
            com.Parameters.AddWithValue("@FileName", obj.FileName);
            com.Parameters.AddWithValue("@MachineType", obj.MachineType);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@Material", obj.Material);
            com.Parameters.AddWithValue("@Dimensions", obj.Dimensions);
            com.Parameters.AddWithValue("@ProjectName", obj.ProjectName);

            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public bool EditProject(ProjectViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("EditProject", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@EditedBy", SessionHelper.CurrentUser);
            com.Parameters.AddWithValue("@MachineType", obj.MachineType);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@Material", obj.Material);
            com.Parameters.AddWithValue("@Dimensions", obj.Dimensions);
            com.Parameters.AddWithValue("@ProjectName", obj.ProjectName);

            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public bool EditProjectBidder(ProjectViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("EditProject", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@AcceptedBy", "Shaun Culler");
            com.Parameters.AddWithValue("@SupplierId", obj.SupplierId);

            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public ProjectViewModel GetProjectByProjectId(int projectId)
        {
            ProjectViewModel model = new ProjectViewModel();
            DbConnection();
            SqlCommand com = new SqlCommand("GetProjectByProjectId", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@Id", projectId);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model.Id = int.Parse(reader["ID"].ToString());
                    model.CompanyId = int.Parse(reader["CompanyId"].ToString());
                    model.SupplierId = reader["SupplierId"] == DBNull.Value ? default(int) : int.Parse(reader["SupplierId"].ToString()); //this one is different becuase I had to make it a nullable int
                    model.FileName = reader["FileName"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.EditedDate = reader["EditedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["EditedDate"];
                    model.EditedBy = reader["EditedBy"].ToString();
                    model.MachineType = (EnumHelper.MachineType)reader["MachineType"];
                    model.Quantity = reader["Quantity"].ToString();
                    model.Material = (EnumHelper.Material)reader["Material"];
                    model.Dimensions = reader["Dimensions"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];
                    model.ProjectName = reader["ProjectName"].ToString();

                }
            }
            return model;



        }

        public List<ProjectViewModel> GetProjectsByCompanyId(int companyId)
        {
            List<ProjectViewModel> modelList = new List<ProjectViewModel>();
            ProjectViewModel model;

            DbConnection();
            SqlCommand com = new SqlCommand("GetProjectsByCompanyId", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@CompanyId", companyId);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model = new ProjectViewModel();

                    model.Id = int.Parse(reader["ID"].ToString());
                    model.CompanyId = int.Parse(reader["CompanyId"].ToString());
                    model.SupplierId = reader["SupplierId"] == DBNull.Value ? default(int) : int.Parse(reader["SupplierId"].ToString()); //this one is different becuase I had to make it a nullable int
                    model.FileName = reader["FileName"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.EditedDate = reader["EditedDate"] == DBNull.Value ? (DateTime?) null : (DateTime)reader["EditedDate"];
                    model.EditedBy = reader["EditedBy"].ToString();
                    model.MachineType = (EnumHelper.MachineType)reader["MachineType"];
                    model.Quantity = reader["Quantity"].ToString();
                    model.Material = (EnumHelper.Material)reader["Material"];
                    model.Dimensions = reader["Dimensions"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];
                    model.ProjectName = reader["ProjectName"].ToString();

                    modelList.Add(model);

                }
            }
            return modelList;



        }

        public List<ProjectViewModel> GetAllProjects()
        {
            List<ProjectViewModel> modelList = new List<ProjectViewModel>();
            ProjectViewModel model;

            DbConnection();
            SqlCommand com = new SqlCommand("GetAllProjects", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model = new ProjectViewModel();

                    model.Id = int.Parse(reader["ID"].ToString());
                    model.CompanyId = int.Parse(reader["CompanyId"].ToString());
                    model.SupplierId = reader["SupplierId"] == DBNull.Value ? default(int) : int.Parse(reader["SupplierId"].ToString()); //this one is different becuase I had to make it a nullable int
                    model.FileName = reader["FileName"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.EditedDate = reader["EditedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["EditedDate"];
                    model.EditedBy = reader["EditedBy"].ToString();
                    model.MachineType = (EnumHelper.MachineType)reader["MachineType"];
                    model.Quantity = reader["Quantity"].ToString();
                    model.Material = (EnumHelper.Material)reader["Material"];
                    model.Dimensions = reader["Dimensions"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];
                    model.ProjectName = reader["ProjectName"].ToString();

                    modelList.Add(model);

                }
            }
            return modelList;



        }


        public bool CreateBid(BidViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("CreateBid", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@ProjectId", obj.ProjectId);
            com.Parameters.AddWithValue("@SupplierId", obj.SupplierId);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Time", obj.Time);
            //com.Parameters.AddWithValue("@CreatedDate", obj.Size);
            com.Parameters.AddWithValue("@CreatedBy", SessionHelper.CurrentUser); 
            com.Parameters.AddWithValue("@AcceptedDate", obj.AcceptedDate);
            com.Parameters.AddWithValue("@AcceptedBy", obj.AcceptedBy);
            com.Parameters.AddWithValue("@Comments", obj.Comments);
            com.Parameters.AddWithValue("@DeclineReason", obj.DeclineReason);
            com.Parameters.AddWithValue("@Declined", obj.Declined);

            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public List<BidViewModel> GetBidsByCompanyId(int companyId)
        {
            List<BidViewModel> modelList = new List<BidViewModel>();
            BidViewModel model;

            DbConnection();
            SqlCommand com = new SqlCommand("GetBidsByCompanyId", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@CompanyId", companyId);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model = new BidViewModel();

                    model.Id = int.Parse(reader["ID"].ToString());
                    model.ProjectId = int.Parse(reader["ProjectId"].ToString());
                    model.SupplierId = int.Parse(reader["SupplierId"].ToString());
                    model.Price = (decimal)(reader["Price"]);
                    model.Time = reader["Time"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];
                    model.Comments = reader["Comments"].ToString();
                    model.DeclineReason = reader["DeclineReason"].ToString();
                    model.Declined = reader["Declined"] as bool? ?? false;

                    modelList.Add(model);

                }
            }
            return modelList;



        }

        public BidViewModel GetBidById(int bidId)
        {
            BidViewModel model = new BidViewModel();

            DbConnection();
            SqlCommand com = new SqlCommand("GetBidsById", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@BidId", bidId);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model.Id = int.Parse(reader["ID"].ToString());
                    model.ProjectId = int.Parse(reader["ProjectId"].ToString());
                    model.SupplierId = int.Parse(reader["SupplierId"].ToString());
                    model.Price = (decimal)(reader["Price"]);
                    model.Time = reader["Time"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];
                    model.Comments = reader["Comments"].ToString();
                    model.DeclineReason = reader["DeclineReason"].ToString();
                    model.Declined = reader["Declined"] as bool? ?? false;

                }
            }
            return model;

        }

        public bool EditBid(BidViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("EditBid", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@ProjectId", obj.ProjectId);
            com.Parameters.AddWithValue("@SupplierId", obj.SupplierId);
            com.Parameters.AddWithValue("@Price", obj.Price);
            com.Parameters.AddWithValue("@Time", obj.Time);
            //com.Parameters.AddWithValue("@CreatedDate", obj.Size);
            com.Parameters.AddWithValue("@CreatedBy", SessionHelper.CurrentUser); 
            com.Parameters.AddWithValue("@AcceptedDate", obj.AcceptedDate);
            com.Parameters.AddWithValue("@AcceptedBy", obj.AcceptedBy);
            com.Parameters.AddWithValue("@Comments", obj.Comments);
            com.Parameters.AddWithValue("@DeclineReason", obj.DeclineReason);
            com.Parameters.AddWithValue("@Declined", obj.Declined);


            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public List<BidViewModel> GetBidsByProjectId(int projectId)
        {
            List<BidViewModel> modelList = new List<BidViewModel>();
            BidViewModel model;
            DbConnection();
            SqlCommand com = new SqlCommand("GetBidsByProjectId", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@ProjectId", projectId);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    model = new BidViewModel();

                    model.Id = int.Parse(reader["ID"].ToString());
                    model.ProjectId = int.Parse(reader["ProjectId"].ToString());
                    model.SupplierId = int.Parse(reader["SupplierId"].ToString());
                    model.Price = (decimal)(reader["Price"]);
                    model.Time = reader["Time"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];
                    model.Comments = reader["Comments"].ToString();
                    model.DeclineReason = reader["DeclineReason"].ToString();
                    model.Declined = reader["Declined"] as bool? ?? false;

                    modelList.Add(model);
                }
            }
            return modelList;



        }

        public bool DeleteBid(int bidId)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("DeleteBid", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@Id", bidId);
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool CreateLogIn(LogInViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("CreateLogIn", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            string password = Convert.ToBase64String(obj.PasswordByte);
            string salt = Convert.ToBase64String(obj.Salt);

            com.Parameters.AddWithValue("@CompanyId", obj.CompanyId);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Password", password);
            com.Parameters.AddWithValue("@Salt", salt);

            using (conn)
            {
                conn.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public bool CheckPassword(LogInViewModel model)
        {
            //LogInViewModel model = new LogInViewModel();
            DbConnection();
            SqlCommand com = new SqlCommand("GetPasswordByUserName", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            string password = "";
            string salt = "";

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@Email", model.Email);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    password = reader["Password"].ToString();
                    salt = reader["Salt"].ToString();
                    
                }
            }

            //password that is saved in database converted to array
            byte[] passwordByteFromDb = Convert.FromBase64String(password);

            //salt saved in database converted to array
            byte[] saltByteFromDb = Convert.FromBase64String(salt);

            //password given from user converted to array
            byte[] passwordByteFromUser = Security.GenerateTextArray(model.PasswordText);

            //creating salted hash using know, saved salt and password given to us from user
            byte[] saltedPasswordToTest = Security.GenerateSaltedHash(passwordByteFromUser, saltByteFromDb);

            // check the salted user provided password against the password saved in the database.
            return Security.CompareByteArrays(passwordByteFromDb, saltedPasswordToTest);


            

        }

        public int GetPasswordCompanyId(string email)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("GetPasswordCompanyId", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            LogInViewModel model = new LogInViewModel();
            int companyId = 0;
            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    companyId = int.Parse(reader["CompanyId"].ToString());
                }
            }
            return companyId;
        }

    }
}