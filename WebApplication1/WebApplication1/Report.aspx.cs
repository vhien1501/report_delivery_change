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
        public static List<DeliveryChangeItem> ListItem() {
            List<DeliveryChangeItem> options = new List<DeliveryChangeItem>();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                string from = DateTime.Today.ToString("yyyy/MM/dd HH:mm:ss");
                string to = DateTime.Today.AddDays(1).AddSeconds(-1).ToString("yyyy/MM/dd HH:mm:ss");
                string sql = "SELECT id,job_no,new_delivery_date,reason_for_change,comments,customer_name,original_delivery_date,updated_by,created,user_login,user_name FROM ft_deliverychanges tbA LEFT JOIN ft_users tbB ON tbA.updated_by=tbB.user_id WHERE tbA.created between @from and @to";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@from", DateTime.Today);
                cmd.Parameters.AddWithValue("@to", DateTime.Today.AddDays(1).AddSeconds(-1));
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DeliveryChangeItem item = new DeliveryChangeItem();
                            item.ID =Convert.ToInt32(reader["id"]);
                            item.JobNo = reader["job_no"].ToString();
                            item.NewDeliveryDate = Convert.ToDateTime(reader["new_delivery_date"]);
                            item.ReasonForChange = reader["reason_for_change"].ToString();
                            item.Comments = reader["comments"].ToString();
                            item.CustomerName = reader["customer_name"].ToString();
                            item.OriginalDeliveryDate = Convert.ToDateTime(reader["original_delivery_date"]);
                            item.UpdatedBy = Convert.ToInt32(reader["updated_by"]);
                            item.Created = Convert.ToDateTime(reader["created"]);
                            item.UserLogin = reader["user_login"].ToString();
                            item.UserName = reader["user_name"].ToString();
                            options.Add(item);
                        }
                    }
                }
                
            }
            return options;
        }

        private void printItem() {
            List<DeliveryChangeItem> itemList = new List<DeliveryChangeItem>();
            itemList = ListItem();
            int number = 0;
            if (itemList.Count == 0)
            {
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                
                tr.InnerHtml += "<td colspan=\"12\" style=\"text-align:center;\">No result found</td>";
                tableResults.Controls.Add(tr);
            }
            else {
                foreach (DeliveryChangeItem obj in itemList) {
                    number++;
                    HtmlGenericControl tr = new HtmlGenericControl("tr");
                    tr.InnerHtml += "<td class=\"col-sm-1 text-right\">"+number+"</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.JobNo + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.OriginalDeliveryDate.ToString("dd/MM/yyyy") + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.NewDeliveryDate.ToString("dd/MM/yyyy") + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.ReasonForChange+ "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-2 text-left\">" + obj.Comments + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-3 text-left\">" + obj.CustomerName + "</td>";
                    //tr.InnerHtml += "<td style=\"text-align:center;\">" + obj.Updated_by + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.Created.ToString("dd/MM/yyyy") + "</td>";
                    //tr.InnerHtml += "<td style=\"text-align:center;\">" + obj.User_login + "</td>";
                    tr.InnerHtml += "<td class=\"col-sm-1 text-left\">" + obj.UserName + "</td>";
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