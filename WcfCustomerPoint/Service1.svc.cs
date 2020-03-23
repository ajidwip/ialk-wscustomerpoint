using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCustomerPoint
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataTable dt = new DataTable();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon4"].ConnectionString);
        cekcustomerkey cekcustomerkey1 = new cekcustomerkey();
        GetCustomerData GetCustomerData2 = new GetCustomerData();
        cekotp cekotp1 = new cekotp();
        cekisreg cekisreg1 = new cekisreg();
        cekpin cekpin1 = new cekpin();
        getpoinheader getpoinheader1 = new getpoinheader();
        Promo promo1 = new Promo();
        news news1 = new news();
        HistoryPoin history = new HistoryPoin();
        Katalog katalog = new Katalog();
        Inbox inbox = new Inbox();
        UpdateData updatedata = new UpdateData();
        CountInbox countinbox = new CountInbox();
        SetInbox setinbox = new SetInbox();
        redeemitem redeemitem1 = new redeemitem();
        redeemhis redeemhis1 = new redeemhis();
        redeemhisdetail redeemhisdetail1 = new redeemhisdetail();
        disclaimer1 disclaimer2 = new disclaimer1();
        ceknohp ceknohp1 = new ceknohp();
        public cekcustomerkey cekcustomerkey(string key)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from T_CPmsCustomerReg where MasterKey='" + key + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                cekcustomerkey1.cekcustomerkey1 = 1;
            }
            else {
                cekcustomerkey1.cekcustomerkey1 = 0;
            }
            con.Close();
            return cekcustomerkey1;
        }
       public void cancelredeem(string redeemnumber)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update [T_CPRedeemRequestTemp] set StatusRequest='10' where RedeemNumber='" + redeemnumber + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updatestatuspengiriman(string redeemnumber)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update [T_CPRedeemRequestTemp] set StatusRequest='9' where RedeemNumber='"+ redeemnumber + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Registercustomer(string nama, string nohp, string noktp, string kodepos, string alamat, string npwp, string notelptoko, string customerkey,string flag,string jenisusaha)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("[SP_CPRegisteUser] '" + nama + "','" + alamat + "','" + nohp + "','" + noktp + "','" + npwp + "','" + kodepos + "','" + notelptoko + "','" + customerkey + "','"+ flag + "','"+ jenisusaha + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public GetCustomerData GetCustomerData1(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select T_CPmsCustomerReg.*,Cust_Name,DimensionCode,T_MsCustomer.address as Alamatsekarang from T_CPmsCustomerReg inner join T_MsCustomer on T_MsCustomer.Cust_NO=T_CPmsCustomerReg.CustNo where T_CPmsCustomerReg.MasterKey = '" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            GetCustomerData2.GetCustomerData1 = dt;
            con.Close();
            return GetCustomerData2;
        }
        public void lupapin(string nohp, string otp, string pinbaru)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("[SP_CPUbahPin] '" + nohp + "','" + otp + "','" + pinbaru + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public cekotp cekotp(string MasterKey, string otp)
        {
            con.Open();

            SqlCommand cmd1 = new SqlCommand("[SP_CPCekOTP] '" + MasterKey + "','" + otp + "'", con);
            cmd1.CommandType = CommandType.Text;
            cmd1.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand("select isReg from [T_CPmsCustomerReg] where MasterKey='" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            string cek = dt.Rows[0][0].ToString();
            if (cek == "True")
            {
                cekotp1.cekotp1 = 1;
            }
            else 
            {
                cekotp1.cekotp1 = 0;
            }
            con.Close();

            return cekotp1;
        }
        public void  setuppin(string Masterkey, string pin)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update T_CPmsCustomerReg set PIN='"+pin+"' where MasterKey='"+Masterkey+"'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void redeem(string requestID, string LineNumber, string MasterKey, string RedeemItemCode, string RedeemQTY)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("[SP_CPRedeemRequest]'"+ requestID + "','"+ LineNumber + "','"+ MasterKey + "','"+ RedeemItemCode + "','"+ RedeemQTY + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
      public  void createotp(string nohp)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("[SP_CPcreateOTP]'" + nohp + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public ceknohp ceknohp(string nophp)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from [T_CPmsCustomerReg] where cellularnumber='" + nophp + "' and isReg=1", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            int cek = int.Parse(dt.Rows[0][0].ToString());
            if (cek > 0)
            {
                ceknohp1.ceknohpavail = 1;
            }
            else
            {
                ceknohp1.ceknohpavail = 0;
            }
            con.Close();

            return ceknohp1;

        }
        public cekisreg cekisregister(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select case when Total=0 then 0 else case when Total=1 then (select IsReg from [T_CPmsCustomerReg] where MasterKey='" + MasterKey + "') end end from(select count(*) Total from [T_CPmsCustomerReg] where MasterKey='" + MasterKey + "')a", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            dt = new DataTable("Paging");
            da.Fill(dt);
            string cek = dt.Rows[0][0].ToString();
            if (cek == "1")
            {
                cekisreg1.cekisregister = 1;
            }
            else
            {
                cekisreg1.cekisregister = 0;
            }
            con.Close();

            return cekisreg1;
        }
        public cekpin cekpin(string MasterKey, string pin)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Isnull(PIN,'') from [T_CPmsCustomerReg] where MasterKey='" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            string cek = dt.Rows[0][0].ToString();
            if (cek != "")
            {
                cekpin1.cekpin1 = dt.Rows[0][0].ToString();
            }
            else
            {
                cekpin1.cekpin1 = "";
            }
            con.Close();
            return cekpin1;
        }
        public redeemitem GetRedeemitem(string dimensi)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetRedeemItem]'"+ dimensi + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            redeemitem1.redeemitemtable = dt;

            con.Close();

            return redeemitem1;
        }
        public getpoinheader getpoinheader(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetPointHeader]'" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            getpoinheader1.poinheadertable = dt;

            con.Close();

            return getpoinheader1;
        }
        public Promo getpromonew()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select NamaPromo,GambarPromo,SyaratdanKetentuan,startdate,endDate from T_CPmsPromo  where convert(date,dateadd(HOUR, 7, getdate())) between convert(date,startdate) and convert(date,enddate)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            promo1.tablePromo = dt;


            con.Close();

            return promo1;
        }
        public Katalog GetKatalog()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select KatalogDesc1,KatalogDesc2,Gambar1,Gambar2,Katalog1,katalogdesc3 from T_CPMSKatalog", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            katalog.Katalogtable = dt;


            con.Close();

            return katalog;
        }
        public UpdateData GetUpdateData(string addtime, string tablename)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[CekUpdateData]" + addtime + ",'" + tablename + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            updatedata.UpdateDatatable = dt;


            con.Close();

            return updatedata;
        }
        public Inbox GetInbox(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetInbox]'" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            inbox.Inboxtable = dt;


            con.Close();

            return inbox;
        }
        public CountInbox GetCountInbox(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetInboxNotRead]'" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            countinbox.CountInboxtable = dt;


            con.Close();

            return countinbox;
        }
        public SetInbox SetInboxRead(string InboxID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[SetInboxRead]'" + InboxID + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            setinbox.SetInboxtable = dt;


            con.Close();

            return setinbox;
        }
        public news getnews()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select judulberita,isiberita,gambar1,tanggalmulai,tanggalberakhir from T_Cpmsnews  where convert(date,dateadd(HOUR, 7, getdate())) between convert(date,tanggalmulai) and convert(date,tanggalberakhir)", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            news1.tablenews = dt;


            con.Close();
            return news1;
        }
        public  void setotpexpired(string nohp)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update [T_OTPRequest] set IsExpired='1' where requestedID='" + nohp + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ubahpin(string oldpin, string newpin, string masterkey)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("update T_CPmsCustomerReg set PIN='" + newpin + "' where MasterKey='" + masterkey + "' and PIN='"+oldpin+"'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public HistoryPoin GetHistoryPoin(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetHistoryPoint] '"+MasterKey+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            history.HistoryPointable = dt;


            con.Close();
            return history;
        }
        public redeemhis GetRedeemhis(string MasterKey)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetHistoryRedeem] '" + MasterKey + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            redeemhis1.redeemhistable = dt;

            con.Close();
            return redeemhis1;
        }
        public redeemhisdetail GetRedeemhisdetail(string MasterKey, string redeemnumber)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("[GetHistoryRedeemdetail] '" + MasterKey + "','"+ redeemnumber + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            redeemhisdetail1.redeemhisdetailtable = dt;

            con.Close();
            return redeemhisdetail1;
        }
        public disclaimer1 getdisclaimer()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select Disclaimmer from [T_CPmsDisclaimmer]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dt = new DataTable("Paging");
            da.Fill(dt);
            disclaimer2.disclaimertable = dt;

            con.Close();
            return disclaimer2;
        }
    }
}
