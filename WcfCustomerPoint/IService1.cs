using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCustomerPoint
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void updatestatuspengiriman(string redeemnumber);

        [OperationContract]
        void createotp(string nohp);

        [OperationContract]
        void lupapin(string nohp,string otp,string pinbaru);

        [OperationContract]
        void cancelredeem(string redeemnumber);

        [OperationContract]
        cekcustomerkey cekcustomerkey(string key);

        [OperationContract]
        void Registercustomer(string nama,string nohp,string noktp,string kodepos, string alamat,string npwp,string notelptoko, string customerkey,string flag, string jenisusaha);
        [OperationContract]
        GetCustomerData GetCustomerData1(string MasterKey);

        [OperationContract]
        cekotp cekotp(string MasterKey,string otp);

        [OperationContract]
        void redeem(string requestID, string LineNumber,string MasterKey, string RedeemItemCode,string RedeemQTY);

        [OperationContract]
        void setuppin(string Masterkey, string pin);

        [OperationContract]
        cekisreg cekisregister(string MasterKey);

        [OperationContract]
        cekpin cekpin(string MasterKey,string pin);

        [OperationContract]
        getpoinheader getpoinheader(string MasterKey);

        [OperationContract]
        Promo getpromonew();

        [OperationContract]
        news getnews();

        [OperationContract]
        void ubahpin(string oldpin,string newpin,string masterkey);

        [OperationContract]
        HistoryPoin GetHistoryPoin(string MasterKey);

        [OperationContract]
        Katalog GetKatalog();

        [OperationContract]
        UpdateData GetUpdateData(string addtime, string tablename);

        [OperationContract]
        Inbox GetInbox(string MasterKey);

        [OperationContract]
        CountInbox GetCountInbox(string MasterKey);

        [OperationContract]
        SetInbox SetInboxRead(string InboxID);

        [OperationContract]
        redeemitem GetRedeemitem(string dimensi);
        [OperationContract]
        redeemhis GetRedeemhis(string MasterKey);

        [OperationContract]
        redeemhisdetail GetRedeemhisdetail(string MasterKey,string redeemnumber);

        [OperationContract]
        void setotpexpired(string nohp);

        [OperationContract]
        disclaimer1 getdisclaimer();

        [OperationContract]
        ceknohp ceknohp(string nohp);
        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class cekcustomerkey
    {
        [DataMember]
        public int cekcustomerkey1
        {
            get;
            set;
        }

    }
    [DataContract]
    public class GetCustomerData
    {
        [DataMember]
        public DataTable GetCustomerData1
        {
            get;
            set;
        }

    }


    [DataContract]
    public class cekotp
    {
        [DataMember]
        public int cekotp1
        {
            get;
            set;
        }

    }


    [DataContract]
    public class cekisreg
    {
        [DataMember]
        public int cekisregister
        {
            get;
            set;
        }

    }
    [DataContract]
    public class ceknohp
    {
        [DataMember]
        public int ceknohpavail
        {
            get;
            set;
        }

    }
    [DataContract]
    public class cekpin
    {
        [DataMember]
        public string cekpin1
        {
            get;
            set;
        }

    }
    [DataContract]
    public class getpoinheader
    {
        [DataMember]
        public DataTable poinheadertable
        {
            get;
            set;
        }

    }
    [DataContract]
    public class Promo
    {
        [DataMember]
        public DataTable tablePromo
        {
            get;
            set;
        }
    }
    [DataContract]
    public class news
    {
        [DataMember]
        public DataTable tablenews
        {
            get;
            set;
        }
    }
    [DataContract]
    public class HistoryPoin
    {
        [DataMember]
        public DataTable HistoryPointable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class Katalog
    {
        [DataMember]
        public DataTable Katalogtable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class Inbox
    {
        [DataMember]
        public DataTable Inboxtable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class UpdateData
    {
        [DataMember]
        public DataTable UpdateDatatable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class CountInbox
    {
        [DataMember]
        public DataTable CountInboxtable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class SetInbox
    {
        [DataMember]
        public DataTable SetInboxtable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class redeemitem
    {
        [DataMember]
        public DataTable redeemitemtable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class redeemhis
    {
        [DataMember]
        public DataTable redeemhistable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class redeemhisdetail
    {
        [DataMember]
        public DataTable redeemhisdetailtable
        {
            get;
            set;
        }
    }
    [DataContract]
    public class disclaimer1
    {
        [DataMember]
        public DataTable disclaimertable
        {
            get;
            set;
        }
    }
}
