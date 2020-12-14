using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMServices
{
    public class Constants
    {
        public static long allId = 1;
        public static long placedId = 2;
        public static long approvedId = 3;
        public static long cancelledId = 4;
        public static long inDeliveryId = 5;
        public static long completedId = 6;

        public static string OrderPlaced = "Your order has been placed successfully and amount to be paid = ";

        public static string ALL = "ALL";
        public static string placed = "PLACED";
        public static string approved = "APPROVED";
        public static string cancelled = "CANCELLED";
        public static string inDelivery = "INDELIVERY";
        public static string completed = "COMPLETED";
        internal static string successData = "order has been updated and currrent status is ";
    }
}