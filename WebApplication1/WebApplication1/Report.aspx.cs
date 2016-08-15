using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

//水木 Nguyen

namespace WebApplication1
{
    public partial class Report : System.Web.UI.Page
    {
        static string connectionString = "Data Source=hq03; Initial Catalog=EmplasPortal; User ID='dbdev'; Password='Hqgaming123'";
        public static List<myObject> ListItem() {
            List<myObject> options = new List<myObject>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                string from = DateTime.Today.ToString("yyyy/MM/dd HH:mm:ss");
                string to = DateTime.Today.AddDays(1).AddSeconds(-1).ToString("yyyy/MM/dd HH:mm:ss");
                string sql = "SELECT id,job_no,new_delivery_date,reason_for_change,comments,customer_name,original_delivery_date,updated_by,created,user_login,user_name FROM ft_deliverychanges tbA LEFT JOIN ft_users tbB ON tbA.updated_by=tbB.user_id WHERE tbA.created between '"+from+"' and '"+to+"'";
                Console.WriteLine(from + to);
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            myObject item = new myObject();
                            item.Id =Convert.ToInt32(reader["id"]);
                            item.Job_no = reader["job_no"].ToString();
                            item.New_delivery_date = Convert.ToDateTime(reader["new_delivery_date"]);
                            item.Reason_for_change = reader["reason_for_change"].ToString();
                            item.Comments = reader["comments"].ToString();
                            item.Customer_name = reader["customer_name"].ToString();
                            item.Original_delivery_date = Convert.ToDateTime(reader["original_delivery_date"]);
                            item.Updated_by = Convert.ToInt32(reader["updated_by"]);
                            item.Created = Convert.ToDateTime(reader["created"]);
                            item.User_login = reader["user_login"].ToString();
                            item.User_name = reader["user_name"].ToString();
                            options.Add(item);
                        }
                    }
                }
                
            }
            return options;
        }

        private void printItem() {
            List<myObject> itemList = new List<myObject>();
            itemList = ListItem();
            int number = 0;
            if (itemList.Count == 0)
            {
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                
                tr.InnerHtml += "<td colspan=\"12\" style=\"text-align:center;\">No result found</td>";
                tableResults.Controls.Add(tr);
            }
            else {
                foreach (myObject obj in itemList) {
                    number++;
                    HtmlGenericControl tr = new HtmlGenericControl("tr");
                    tr.InnerHtml += "<td class=\"col-sm-1 text-right\">"+number+"</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.Job_no + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.Original_delivery_date.ToString("dd/MM/yyyy") + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.New_delivery_date.ToString("dd/MM/yyyy") + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.Reason_for_change+ "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-2 text-left\">" + obj.Comments + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-3 text-left\">" + obj.Customer_name + "</td>";
                    //tr.InnerHtml += "<td style=\"text-align:center;\">" + obj.Updated_by + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.Created.ToString("dd/MM/yyyy") + "</td>";
                    //tr.InnerHtml += "<td style=\"text-align:center;\">" + obj.User_login + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.User_name + "</td>";
                    tableResults.Controls.Add(tr);
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            printItem();
        }
    }
}