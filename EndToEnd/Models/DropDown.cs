using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class DropDown
    {
        public enum StatusOfPurchase
        {
            Pending = 1,
            Cancel,
            Unauthorized,
            Successful
        }
        public enum PurchaseType
        {
            BankDeposite = 1,
            OnlinePayment
        }
        public enum StatusType
        {
            Active = 1,
            Suspended,
            Dormant
        }
        public enum BankName
        {
            FirstBankNigeria = 1,
            AccessBank,
            GuarantyTrustBank,
            DiamondBank,
            WemaBank,
            EcobankNigeria,
            FidelityBankNigeria,
            HeritageBankPlc,
            KeystoneBankLimited,
            ProvidusBankPlc,
            SkyeBank,
            StanbicIBTC_BankNigeria,
            StandardCharteredBank,
            SterlingBank,
            SuntrustBankNigeriaLimited,
            UnionBankOfNigeria,
            UnitedBankForAfrica,
            UnityBankPlc,
            ZenithBank
        }
        public enum Services
        {
            SMS = 1,
            Facebook,
            Twitter,
            Whatsapp,
            Email,
            RoboCall
        }
        public enum State
        {
            Abia = 1,
            Adamawa,
            Akwaibom,
            Anambra,
            Bauchi,
            Benue,
            Cross_River,
            Delta,
            Bayelsa,
            Borno,
            Ebonyi,
            Enugu,
            Edo,
            Ekiti,
            Gombe,
            Imo,
            Jigawa,
            Kaduna,
            Kano,
            Katsina,
            Kebbi,
            Kogi,
            Kwara,
            Lagos,
            Nasarawa,
            Niger,
            Ogun,
            Ondo,
            Osun,
            Oyo,
            Plateau,
            Rivers,
            Sokoto,
            Taraba,
            Yobe,
            Zamfara,
            Territory,
            Federal_Capital_Territory_FCT,


        }
        public enum Gender
        {
            Male = 1,
            Female,
        }

        public enum Title
        {
            Mr = 1,
            Mrs,
            Master,
            Miss,
            Dr,
            Pro,
            Engr,
            Others,
        }

        public enum UserGroupList
        {

        }
    }
}