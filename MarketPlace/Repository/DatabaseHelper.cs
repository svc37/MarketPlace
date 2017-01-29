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
            conn = new SqlConnection(constr); //connection string not working. S

        }


        public bool CreateUser(UserViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("CreateUser", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            com.Parameters.AddWithValue("@StreetAddress", obj.StreetAddress);
            com.Parameters.AddWithValue("@StreetAddress2", obj.StreetAddress2);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Phone", obj.PhoneNumber);

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

        public bool EditUser(UserViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("UserEdit", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@Id", obj.Id);
            com.Parameters.AddWithValue("@StreetAddress", obj.StreetAddress);
            com.Parameters.AddWithValue("@StreetAddress2", obj.StreetAddress2);
            com.Parameters.AddWithValue("@CompanyName", obj.CompanyName);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@ZipCode", obj.ZipCode);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Phone", obj.PhoneNumber);
            com.Parameters.AddWithValue("@EditedBy", "Shaun Culler"); //TODO: Need to change this once we work out logging in. 

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

        public UserViewModel GetUser(int Id)
        {
            UserViewModel model = new UserViewModel();
            DbConnection();
            SqlCommand com = new SqlCommand("GetUser", conn);
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
                    model.Email = reader["Email"].ToString();
                }
            }
            return model;



        }

        public UserViewModel GetUserByEmail(string email)
        {
            UserViewModel model = new UserViewModel();
            DbConnection();
            SqlCommand com = new SqlCommand("GetUserByEmail", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@Email", email);
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
                    model.Email = reader["Email"].ToString();
                }
            }
            return model;

        }

        public bool CreateProject(ProjectViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("CreateProject", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@CompanyId", obj.CompanyId);
            com.Parameters.AddWithValue("@CreatedBy", "sculler"); //TODO: change this when i get log in set up.
            com.Parameters.AddWithValue("@MachineType", obj.MachineType);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@Material", obj.Material);
            com.Parameters.AddWithValue("@Size", obj.Size);
            com.Parameters.AddWithValue("@Dimensions", obj.Dimensions);
            com.Parameters.AddWithValue("@Tolerance", obj.Tolerance);
            com.Parameters.AddWithValue("@Volume", obj.Tolerance);

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
            com.Parameters.AddWithValue("@EditedBy", "Shaun Culler"); //TODO: Need to change this once we work out logging in. 
            com.Parameters.AddWithValue("@MachineType", obj.MachineType);
            com.Parameters.AddWithValue("@Quantity", obj.Quantity);
            com.Parameters.AddWithValue("@Material", obj.Material);
            com.Parameters.AddWithValue("@Size", obj.Size);
            com.Parameters.AddWithValue("@Dimensions", obj.Dimensions);
            com.Parameters.AddWithValue("@Tolerance", obj.Tolerance);
            com.Parameters.AddWithValue("@Volume", obj.Volume);

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
                    model.SupplierId = int.Parse(reader["SupplierId"].ToString());
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.EditedDate = (DateTime)reader["EditedDate"];
                    model.EditedBy = reader["EditedBy"].ToString();
                    model.MachineType = (MachineType)reader["MachineType"];
                    model.Quantity = reader["Quantity"].ToString();
                    model.Material = reader["Material"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Dimensions = reader["Dimensions"].ToString();
                    model.Tolerance = reader["Tolerance"].ToString();
                    model.Volume = reader["Volume"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = (DateTime)reader["AcceptedDate"];


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
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.EditedDate = reader["EditedDate"] == DBNull.Value ? (DateTime?) null : (DateTime)reader["EditedDate"];
                    model.EditedBy = reader["EditedBy"].ToString();
                    model.MachineType = (MachineType)reader["MachineType"];
                    model.Quantity = reader["Quantity"].ToString();
                    model.Material = reader["Material"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Dimensions = reader["Dimensions"].ToString();
                    model.Tolerance = reader["Tolerance"].ToString();
                    model.Volume = reader["Volume"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];

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
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.EditedDate = reader["EditedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["EditedDate"];
                    model.EditedBy = reader["EditedBy"].ToString();
                    model.MachineType = (MachineType)reader["MachineType"];
                    model.Quantity = reader["Quantity"].ToString();
                    model.Material = reader["Material"].ToString();
                    model.Size = reader["Size"].ToString();
                    model.Dimensions = reader["Dimensions"].ToString();
                    model.Tolerance = reader["Tolerance"].ToString();
                    model.Volume = reader["Volume"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];

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
            com.Parameters.AddWithValue("@QualityLevel", obj.QualityLevel);
            //com.Parameters.AddWithValue("@CreatedDate", obj.Size);
            com.Parameters.AddWithValue("@CreatedBy", "sculler"); //TODO: Get user worked out.  SessionHelper
            com.Parameters.AddWithValue("@AcceptedDate", obj.AcceptedDate);
            com.Parameters.AddWithValue("@AcceptedBy", obj.AcceptedBy);

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
                    model.QualityLevel = reader["QualityLevel"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];

                    modelList.Add(model);

                }
            }
            return modelList;



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
                    model.QualityLevel = reader["QualityLevel"].ToString();
                    model.CreatedDate = (DateTime)reader["CreatedDate"];
                    model.CreatedBy = reader["CreatedBy"].ToString();
                    model.AcceptedBy = reader["AcceptedBy"].ToString();
                    model.AcceptedDate = reader["AcceptedDate"] == DBNull.Value ? (DateTime?)null : (DateTime)reader["AcceptedDate"];

                    modelList.Add(model);
                }
            }
            return modelList;



        }

        public bool CreateLogIn(LogInViewModel obj)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("CreateLogIn", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;

            string password = Convert.ToBase64String(obj.PasswordByte);
            string salt = Convert.ToBase64String(obj.Salt);

            com.Parameters.AddWithValue("@CompanyId", obj.CompanyId);
            com.Parameters.AddWithValue("@UserName", obj.UserName);
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
                com.Parameters.AddWithValue("@UserName", model.UserName);
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

        public int GetPasswordCompanyId(string userName)
        {
            DbConnection();
            SqlCommand com = new SqlCommand("GetPasswordCompanyId", conn);
            com.CommandType = System.Data.CommandType.StoredProcedure;
            LogInViewModel model = new LogInViewModel();
            int companyId = 0;
            using (conn)
            {
                conn.Open();
                com.Parameters.AddWithValue("@UserName", userName);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    companyId = int.Parse(reader["UserId"].ToString());
                }
            }
            return companyId;
        }

    }
}