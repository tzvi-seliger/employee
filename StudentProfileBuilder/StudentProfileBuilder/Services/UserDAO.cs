using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using StudentProfileBuilder.Models;
using Dapper;

namespace StudentProfileBuilder.Services
{
    public class UserDAO
    {
        private string _connectionString;

        public UserDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates a new user based on the criteria entered by the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CreateUser(User user)
        {
            if (!UserExists(user))
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO users (Username, Password, Salt, AcctType, Email, FirstName, LastName, HomePhone, CellPhone, Views, CohortID) VALUES(@username, @password, @salt, @accountType, @email, @firstName, @lastName, @homePhone, @cellPhone, 0, @cohortID)", conn);

                    //Assigns object values to the SqlCommand
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@salt", user.Salt);
                    cmd.Parameters.AddWithValue("@accountType", user.AcctType);
                    cmd.Parameters.AddWithValue("@email", user.Email);
                    cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", user.LastName);
                    cmd.Parameters.AddWithValue("@homePhone", user.HomePhone);
                    cmd.Parameters.AddWithValue("@cellPhone", user.CellPhone);
                    cmd.Parameters.AddWithValue("@cohortID", user.CohortID);

                    user.UserID = Convert.ToInt32(cmd.ExecuteScalar());
                }
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks if a user already exists in the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UserExists(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username", conn);

                cmd.Parameters.AddWithValue("@username", user.Username);
                return cmd.ExecuteScalar() != null;
            }
        }

        /// <summary>
        /// Returns a user based on a given username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUserByUsername(string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string cmd = $"SELECT * FROM users WHERE username = @username";
                    User user = conn.QuerySingle<User>(cmd, new { username = username });
                    return user;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Gets a list of users based on a search
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<User> GetUsersBySearch(string season, string location, string skillName)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string cmd = $"SELECT DISTINCT users.userID, users.Username FROM users " +
                        "JOIN Cohorts ON users.CohortID = cohorts.cohortID " +
                        "WHERE Season LIKE(@season) AND Location LIKE(@location)";
                    List<User> users = conn.Query<User>(cmd, new { season = season, location = location, skillName = skillName }).ToList();
                    return users;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Updates the user's authentication token
        /// </summary>
        /// <param name="user"></param>
        public void UpdateAuthToken(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE users SET AuthToken = @authToken WHERE Username = @username", conn);
                cmd.Parameters.AddWithValue("@authToken", user.AuthToken);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Collects all of a given user's projects
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Project> GetUserProjects(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string cmd = "SELECT users.Username, Projects.ProjectID, Projects.Name, Projects.Description FROM users " +
                        "JOIN ProjectUser ON users.userID = projectuser.userID " +
                        "JOIN Projects ON projectuser.ProjectID = Projects.ProjectID " +
                        "WHERE username = @username";
                    List<Project> projects = conn.Query<Project>(cmd, new { username = user.Username }).ToList();
                    return projects;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Collects all of a given user's companies and institutions
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Institution> GetUserInstitutions(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string cmd = "SELECT DISTINCT users.Username, CompaniesAndInstitutions.* FROM users " +
                        "JOIN CompanyInstUser ON users.userID = CompanyInstUser.userID " +
                        "JOIN CompaniesAndInstitutions ON CompaniesAndInstitutions.CompanyID = CompaniesAndInstitutions.CompanyID " +
                        "WHERE username = @username";
                    List<Institution> companies = conn.Query<Institution>(cmd, new { username = user.Username }).ToList();
                    return companies;
                }
            }
            catch
            {
                return null;
            }
        }

        public Cohort GetUserCohort(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string cmd = $"SELECT * FROM cohorts " +
                        $"JOIN users ON users.cohortID = cohorts.cohortID " +
                        $"WHERE username = @username";
                    Cohort cohort = conn.QuerySingle<Cohort>(cmd, new { username = user.Username });
                    return cohort;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list of all users from the database
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    string cmd = "SELECT * FROM users ORDER BY FirstName";
                    List<User> users = conn.Query<User>(cmd).ToList();
                    return users;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Updates the user's profile image file path in the database
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UpdateImagePath(string imagePath, string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"UPDATE users SET ImagePath = @imagePath WHERE Username = @username", conn);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteScalar();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the user's resume file path in the database
        /// </summary>
        /// <param name="imagePath"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UpdateResumePath(string resumePath, string username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"UPDATE users SET ResumePath = @resumePath WHERE Username = @username", conn);
                    cmd.Parameters.AddWithValue("@resumePath", resumePath);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteScalar();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users SET firstname=@firstname, lastname=@lastname, header=@header, description=@description WHERE username = @username", conn);

                cmd.Parameters.AddWithValue("@firstname", user.FirstName);
                cmd.Parameters.AddWithValue("@lastname", user.LastName);
                cmd.Parameters.AddWithValue("@header", user.Header);
                cmd.Parameters.AddWithValue("@description", user.Description);
                cmd.Parameters.AddWithValue("@username", user.Username);

                cmd.ExecuteScalar();
            }
        }
    }
}
