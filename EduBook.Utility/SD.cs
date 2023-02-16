namespace EduBook.Utility
{
    public static class SD
    {
        // hằng số (proc, role, session, status)
        // proc
        public const string Proc_CoverType_Create = "usp_CreateCoverType";
        public const string Proc_CoverType_Get = "usp_GetCoverType";
        public const string Proc_CoverType_GetAll = "usp_GetCoverTypes";
        public const string Proc_CoverType_Update = "usp_UpdateCoverType";
        public const string Proc_CoverType_Delete = "usp_DeleteCoverType";
        // role
        public const string Role_User_Indi = "Individual Customer";
        public const string Role_User_Comp = "Company Customer";
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";
        // session
        public const string ssShoppingCart = "Shopping Cart Session";
        // status
        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProces = "Processing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefund = "Refund";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";

        //  trả về price dựa vào quantity
        public static double GetPriceBasedOnQuantity(double quantity, double price, double price50, double price100)
        {
            // nhỏ hơn 50 trả về price
            if (quantity < 50)
            {
                return price;
            }
            else
            {
                // nhỏ hơn 100 trả về price50
                if (quantity < 100)
                {
                    return price50;
                }
                // ngược lại trả về price100
                else
                {
                    return price100;
                }    
            }    
        }

        // định dạng description (RawHtml) 
        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;
            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}