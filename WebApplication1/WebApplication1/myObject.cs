using System;

namespace WebApplication1
{
    public class myObject
    {
        private int id;
        private string job_no;
        private DateTime new_delivery_date;
        private string reason_for_change;
        private string comments;
        private string customer_name;
        private DateTime original_delivery_date;
        private int updated_by;
        private DateTime created;
        private string user_login;
        private string user_name;
        private int stt;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
                
            }
        }

        public string Job_no
        {
            get
            {
                return job_no;
            }

            set
            {
                job_no = value;
            }
        }

        public DateTime New_delivery_date
        {
            get
            {
                return new_delivery_date;
            }

            set
            {
                new_delivery_date = value;
            }
        }

        public string Reason_for_change
        {
            get
            {
                return reason_for_change;
            }

            set
            {
                reason_for_change = value;
            }
        }

        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

        public string Customer_name
        {
            get
            {
                return customer_name;
            }

            set
            {
                customer_name = value;
            }
        }

        public DateTime Original_delivery_date
        {
            get
            {
                return original_delivery_date;
            }

            set
            {
                original_delivery_date = value;
            }
        }

        public int Updated_by
        {
            get
            {
                return updated_by;
            }

            set
            {
                updated_by = value;
            }
        }

        public DateTime Created
        {
            get
            {
                return created;
            }

            set
            {
                created = value;
            }
        }

        public string User_login
        {
            get
            {
                return user_login;
            }

            set
            {
                user_login = value;
            }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                user_name = value;
            }
        }
    }
}