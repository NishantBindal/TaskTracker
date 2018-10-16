using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using TaskTracker.Auth.Models;
using TaskTracker.Enums.Enumerators;
using TaskTracker.UtilitiesDotNetStandard;

namespace TaskTracker.Auth.Dal
{
    public class TaskTrackerDalForAuth
    {
        private string _connectionString { get; set; }
        public TaskTrackerDalForAuth()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["TaskTracker"].ConnectionString;
        }
        public AuthClientConfig GetClientConfig(string baseUri)
        {
            string query = @"SELECT * 
                              FROM [TaskTracker].[dbo].[AuthClientConfigs]
                              WHERE BaseUri = @baseUri";
            AuthClientConfig config = null;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@baseUri", baseUri);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    config = new AuthClientConfig()
                    {
                        Id = (int)reader[0],
                        BaseUri = (string)reader[1],
                        Salt = (string)reader[2],
                        ConsumerKey = (string)reader[3],
                        ConsumerSecret = (string)reader[4],
                        Digest = (string)reader[5]
                    };
                    break;
                }
                reader.Close();
            }
            return config;
        }
        public bool CreateAuthClientConfig(string userName,string password, string baseUrl)
        {
            string query = @"INSERT INTO [dbo].[AuthClientConfigs]
                           ([UserName],[Salt],[Digest],[BaseUri])
                           VALUES (@userName,@salt,@digest,@baseUri)";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                PasswordWithSaltHasher passwordWithSaltHasher = new PasswordWithSaltHasher();
                var digestWithSalt = passwordWithSaltHasher.HashWithSalt(password, 64, HashAlgorithm.Create("SHA256"));
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@userName", SqlDbType.VarChar, 50).Value = userName;
                command.Parameters.Add("@salt", SqlDbType.VarChar, 200).Value = digestWithSalt.Salt;
                command.Parameters.Add("@digest", SqlDbType.VarChar, 200).Value = digestWithSalt.Digest;
                command.Parameters.Add("@baseUri", SqlDbType.VarChar,200).Value = baseUrl;
                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows > 0 ? true : false;
            }
        }
        public bool SaveUserSession(int authClientConfigId, Model.AccessTokenInfo accessTokenInfo)
        {
            string query = @"INSERT INTO [dbo].[UserSessions]
                           ([UserSessionId],[AccessToken],[AccessSecret],[AuthTypeId])
                           VALUES (@userSessionId,@accessToken,@accessSecret,@authTypeId)";
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@userSessionId", SqlDbType.Int).Value = authClientConfigId;
                command.Parameters.Add("@accessToken", SqlDbType.VarChar, 200).Value = accessTokenInfo.AccessToken;
                command.Parameters.Add("@accessSecret", SqlDbType.VarChar, 200).Value = accessTokenInfo.AccessTokenSecret;
                command.Parameters.Add("@authTypeId", SqlDbType.Int).Value = AuthType.Oauth1;
                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows > 0 ? true : false;
            }
        }
        public bool SaveUserSession(int authClientConfigId)
        {
            string query = @"INSERT INTO [dbo].[UserSessions]
                           ([UserSessionId],[AuthTypeId])
                           VALUES (@userSessionId,@authTypeId)";
            Model.AuthClientConfig config = null;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@userSessionId", SqlDbType.Int).Value = authClientConfigId;
                command.Parameters.Add("@authTypeId", SqlDbType.Int).Value = AuthType.Basic;
                sqlConnection.Open();
                int affectedRows = command.ExecuteNonQuery();
                return affectedRows > 0 ? true : false;
            }
        }
    }
}
