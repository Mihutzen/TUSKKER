using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

using System.IO;
using System.Security.Cryptography;

namespace TuskKer
{
    public partial class Login : System.Web.UI.Page
    {
        //string message;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static string cript(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            TcpClient tc = new TcpClient("IP", PORT);
            NetworkStream ns = tc.GetStream();

            
            string mesaj_criptat = cript(TextBox2.Text);
            string mesage = "1" + TextBox1.Text + ":" + mesaj_criptat;

            send_msg(tc, ns, mesage);
            string recv_mess = recv_msg(ns);

            if (recv_mess == "1") Response.Redirect("TeamMember.aspx"); //e membru al unei echipe
            else if (recv_mess == "2") Response.Redirect("ViewTasks.aspx"); //e teamleader
            else if (recv_mess == "-1") Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please log out from any other users before logging in.');", true);
            else Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid username and password.');", true);
            

        }

        private void send_msg(TcpClient tc, NetworkStream ns,string message)
        {
            byte[] byteAr = new byte[message.Length + 1];
            byte minune = new byte();

            for (int i = 0; i < message.Length; i++)
            {
                minune = (byte)message[i];
                byteAr[i] = minune;
            }
            ns.Write(byteAr, 0, byteAr.Length);
        }

        private string recv_msg(NetworkStream ns)
        {
            byte msg_delim = (byte)'\0';
            string message = "";
            char aux;
            while((aux = (char)ns.ReadByte()) != (char)msg_delim)
            {
                message += aux;
            }

            return message;
        }

        private byte[] CreateDataPacket(byte[] data)
        {
            byte[] initialize = new byte[1];
            initialize[0] = 2;
            byte[] separator = new byte[1];
            separator[0] = 4;
            byte[] datalength = Encoding.UTF8.GetBytes(Convert.ToString(data.Length));
            MemoryStream ms = new MemoryStream();
            ms.Write(initialize, 0, initialize.Length);
            ms.Write(datalength, 0, datalength.Length);
            ms.Write(separator, 0, separator.Length);
            ms.Write(data, 0, data.Length);
            return ms.ToArray();
        }
    }
}