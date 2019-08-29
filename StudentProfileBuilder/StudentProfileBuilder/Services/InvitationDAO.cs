using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentProfileBuilder.Helpers;
using System.Data.SqlClient;
using StudentProfileBuilder.Models;
using System.Net.Mail;
using System.Net;

namespace StudentProfileBuilder.Services
{
    public class InvitationDAO
    {
        private string _connectionString;

        public InvitationDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates a code and inserts it into the database
        /// </summary>
        /// <returns></returns>
        public Invitation CreateCode(string email)
        {
            Invitation inv = new Invitation();
            inv.Email = email;

            string code = InvitationsHelper.CodeGenerator();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE Invitations WHERE email = @email; INSERT INTO Invitations VALUES(@email, @invKey)", conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@invKey", code);
                inv.InvID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            inv.InvKey = code;
            return inv;
        }

        /// <summary>
        /// Confirms that the code and email match the record in the database
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool CheckCode(string userEmail, string code)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Invitations WHERE email = @email AND invKey = @invKey", conn);
                cmd.Parameters.AddWithValue("@email", userEmail);
                cmd.Parameters.AddWithValue("@invKey", code);
                return cmd.ExecuteScalar() != null;
            }
        }

        /// <summary>
        /// Deletes a user's invite from the database once a user has been successfully created
        /// </summary>
        public bool DeleteInvite(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE Invitations WHERE email = @email", conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteScalar();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
