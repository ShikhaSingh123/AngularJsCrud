﻿using AngularJsCrud.Contract;
using AngularJsCrud.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using System.Linq;
using System.Web;

namespace AngularJsCrud.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public LoginInfo OnLogin(LoginInfo loginInfo)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }

            try
            {
                cmd.CommandText = "check_login_new";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@userName", loginInfo.userName);
                cmd.Parameters.AddWithValue("@password", Utility.CheckPassword(loginInfo.password, selectEncryptPassword(loginInfo.userName)));
                cmd.Parameters.AddWithValue("@msg", loginInfo.msg);
                cmd.Parameters["@msg"].Direction = ParameterDirection.Output;
                cmd.Parameters["@msg"].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters["@msg"].Size = 100;
                cmd.Parameters.AddWithValue("@userid", loginInfo.userId);
                cmd.Parameters["@userid"].Direction = ParameterDirection.Output;
                cmd.Parameters["@userid"].SqlDbType = SqlDbType.Int;
                cmd.Parameters["@userid"].Size = 100;
                cmd.Parameters.AddWithValue("@status", loginInfo.userId);
                cmd.Parameters["@status"].Direction = ParameterDirection.Output;
                cmd.Parameters["@status"].SqlDbType = SqlDbType.Int;
                cmd.Parameters["@status"].Size = 100;
                 cmd.ExecuteScalar();
                loginInfo.msg = cmd.Parameters["@msg"].Value.ToString();
                loginInfo.userId = Convert.ToInt32(cmd.Parameters["@userid"].Value);
                loginInfo.status = Convert.ToInt32(cmd.Parameters["@status"].Value);
            }
            catch (Exception ex)
            {
                loginInfo.msg = ex.Message;
                loginInfo.status = 0;
            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return loginInfo;
        }

        public string selectEncryptPassword(string username)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            string pswrd="";
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }

            try
            {
                cmd.CommandText = "select_encryt_pswrd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@password", pswrd);
                cmd.Parameters["@password"].Direction = ParameterDirection.Output;
                cmd.Parameters["@password"].SqlDbType = SqlDbType.VarChar;
                cmd.Parameters["@password"].Size = 100;
                cmd.ExecuteScalar();
                pswrd = cmd.Parameters["@password"].Value.ToString(); ;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return pswrd;
        }

        public bool CreateUser(createUser createUser)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            int noOfRows = 0;
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "sign_up_insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@firstName", createUser.firstName);
                cmd.Parameters.AddWithValue("@lastName", createUser.lastName);
                cmd.Parameters.AddWithValue("@password", Utility.Encryptpassword(createUser.password));
                cmd.Parameters.AddWithValue("@emailId", createUser.emailId);
                cmd.Parameters.AddWithValue("@phoneNo", createUser.phoneNo);
                cmd.Parameters.AddWithValue("@isAdmin", createUser.isAdmin==true?1:0);
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return noOfRows > 0 ? true : false;
        }
        public List<EmployeeInfo> GetEmployeeById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            List<EmployeeInfo> empList = new List<EmployeeInfo>();
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "select_employee_info";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EmployeeInfo emp = new EmployeeInfo
                    {
                        id = (int)dr[0],
                        Empname = dr[1].ToString(),
                        Designation = dr[2].ToString(),
                        Location = dr[3].ToString(),
                        Userid = (int)dr[4],
                        Basic = (int)dr[8],
                        Hra = (int)dr[9],
                        Ta = (int)dr[10],
                        Sa = (int)dr[11],
                        Salary = (int)dr[12],
                    };
                    empList.Add(emp);
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            } 
            return empList;
        }
        public bool CreateEmployee(EmployeeInfo employeeInfo)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            int noOfRows = 0;
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "emp_info_insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@userName", employeeInfo.Empname);
                cmd.Parameters.AddWithValue("@designation", employeeInfo.Designation);
                cmd.Parameters.AddWithValue("@location", employeeInfo.Location);
                cmd.Parameters.AddWithValue("@basic", employeeInfo.Basic);
                cmd.Parameters.AddWithValue("@hra", employeeInfo.Hra);
                cmd.Parameters.AddWithValue("@ta", employeeInfo.Ta);
                cmd.Parameters.AddWithValue("@sa", employeeInfo.Sa);
                cmd.Parameters.AddWithValue("@salary", employeeInfo.Salary);
                cmd.Parameters.AddWithValue("@userId", employeeInfo.Userid);
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return noOfRows > 0 ? true : false;
        }
        public bool UpdateEmployee(EmployeeInfo employeeInfo)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            int noOfRows = 0;
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "emp_info_update";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@id", employeeInfo.id);
                cmd.Parameters.AddWithValue("@userName", employeeInfo.Empname);
                cmd.Parameters.AddWithValue("@designation", employeeInfo.Designation);
                cmd.Parameters.AddWithValue("@location", employeeInfo.Location);
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return noOfRows > 0 ? true : false;
        }
        public EmpSal GetSalaryById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            EmpSal emp = new EmpSal();
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "select_sal_info";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.Id = (int)dr[0];
                    emp.Basic = (int)dr[1];
                    emp.Hra = (int)dr[2]; 
                    emp.Ta = (int)dr[3];
                    emp.Sa = (int)dr[4];
                    emp.Salary = (int)dr[5];
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return emp;
        }
        public bool UpdateSalary(EmpSal empSal)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            int noOfRows = 0;
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "update_sal_info";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@id", empSal.Id);
                cmd.Parameters.AddWithValue("@basic", empSal.Basic);
                cmd.Parameters.AddWithValue("@hra", empSal.Hra);
                cmd.Parameters.AddWithValue("@ta", empSal.Ta);
                cmd.Parameters.AddWithValue("@sa", empSal.Sa);
                cmd.Parameters.AddWithValue("@total", empSal.Salary);
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return noOfRows > 0 ? true : false;
        }
        public bool DeleteEmployee(int id)
        {
            SqlCommand cmd = new SqlCommand();
            sqlConnection obj_con = new sqlConnection();
            int noOfRows = 0;
            if (obj_con.con.State == ConnectionState.Closed)
            {
                obj_con.con.Open();
            }
            try
            {
                cmd.CommandText = "delete_emp_info";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = obj_con.con;
                cmd.Parameters.AddWithValue("@id",id);
                noOfRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cmd.Dispose();
                obj_con.con.Close();
                obj_con.con.Dispose();
            }
            return noOfRows > 0 ? true : false;
        }
    }
}