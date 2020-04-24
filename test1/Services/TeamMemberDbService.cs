using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using test1.DTOs.Responses;

namespace test1.Services
{
    public class TeamMemberDbService : IDbService
    {

        private readonly string connectionString = "Data Source=db-mssql;Initial Catalog=s18289;Integrated Security=True";


        public List<GetTeamMemberResponse> GetTeamMember(int id)
        {
            var teamMembers = new List<GetTeamMemberResponse>();
            using (var con = new SqlConnection(connectionString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT t.name, t.description, t.deadline, p.name, tt.name, tm.idteammember, tm.firstname, tm.lastname, tm.email FROM TeamMember tm, Task t " +
                                  "JOIN Project p ON t.idteam = p.idteam " +
                                  "JOIN TaskType tt ON t.idtasktype = tt.idtasktype " +
                                  "ORDER BY t.deadline DESC";
                con.Open();
                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var response = new GetTeamMemberResponse();
                    response.IdTeamMember = (int)dr["IdTeamMember"];
                    response.FirstName = dr["FirstName"].ToString();
                    response.LastName = dr["LastName"].ToString();
                    response.Email = dr["Email"].ToString();
                    response.TaskName = dr["Name"].ToString();
                    response.TaskDescription = dr["Description"].ToString();
                    response.TaskDeadline = (DateTime)dr["Deadline"];
                    response.ProjectName = dr["Name"].ToString();
                    response.TaskType = dr["Name"].ToString();
                    teamMembers.Add(response);
                }
            }
            return teamMembers;
        }

        public IActionResult DeleteProject(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "SELECT * FROM Project WHERE idProject=@id";
                com.Parameters.AddWithValue("id", id);
                con.Open();

                var transaction = con.BeginTransaction();
                com.Transaction = transaction;

                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    com.CommandText = "DELETE FROM Task WHERE idProject=@id;";

                    try
                    {
                        com.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        return BadRequest("Project with such id does not exist");
                    }
                }
            }
        }
    }
}