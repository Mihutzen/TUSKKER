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
    public partial class MyTeam : System.Web.UI.Page
    {
        static TcpClient tc = new TcpClient("IP", PORT);
        NetworkStream ns = tc.GetStream();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Refresh", "10");
            send_msg(tc, ns, "2");
            string recv_mess = recv_msg(ns);

            string[] groups = recv_mess.Split(new Char[] { ',',' ' });
            foreach (string s in groups)
            {
                if (s.Trim() != "")
                {
                    DropDownList1.Items.Add(s);
                }
            } 

            string x = Session["Data"].ToString();

            Label1.Text= Session["Data"].ToString() + "'s Tasks:";
            //DropDownList1.Items.Add(x);
            data();
            VerificareSelectare();

        }
        private void VerificareSelectare()
        {
            if (DropDownList1.SelectedItem.Text != "Active Users")
            {
                Session["Data"] = DropDownList1.SelectedItem.Text;
                Response.Redirect("MyTeam.aspx");
            }
        }
        private void data()
        {

            send_msg(tc, ns, "B"+ Session["Data"].ToString());
            string recv_mess = recv_msg(ns);
            if (recv_mess != "")
            {
                int counter = 1;

                string[] nr_task = recv_mess.Split(new Char[] { '~' });

                Label[] labels = new Label[33];

                for (int i = 0; i < nr_task.Length-1; i++)
                {
                    string[] words = nr_task[i].Split(new Char[] { '|' });

                    TableRow rw = new TableRow();

                    for (int cellNum = 0; cellNum < words.Length; cellNum++)
                    {
                        TableCell cel = new TableCell();

                        if (counter % 5 == 1)
                        {
                            cel.Text = words[0];
                        }
                        else if (counter % 5 == 2)
                        {
                            cel.Text = words[1];
                        }
                        else if (counter % 5 == 3)
                        {
                            cel.Text = words[2];
                        }
                        else if (counter % 5 == 4)
                        {
                            if (words[3] == "0")
                            {
                                cel.Text = "To do";
                                cel.BackColor = Color.Red;
                                cel.ForeColor = Color.White;
                                cel.Font.Bold = true;
                                //cel.HorizontalAlign = HorizontalAlign.Center;

                            }
                            else if (words[3] == "1")
                            {
                                cel.Text = "In Progress";
                                cel.BackColor = Color.Green;
                                cel.ForeColor = Color.White;
                                cel.Font.Bold = true;
                                //cel.HorizontalAlign = HorizontalAlign.Center;
                            }
                            else
                            {
                                cel.Text = "Holded";
                                cel.BackColor = Color.Orange;
                                cel.ForeColor = Color.White;
                                cel.Font.Bold = true;
                                //cel.HorizontalAlign = HorizontalAlign.Center;
                            }
                        }
                        else
                        {
                            int sec = Int32.Parse(words[4]); //secunde
                            if (sec < 1800 && sec > 600)
                            {
                                cel.BackColor = Color.Orange;
                                cel.ForeColor = Color.White;
                            }
                            else if (sec <= 600 && sec >= 0)
                            {
                                cel.BackColor = Color.Red;
                                cel.ForeColor = Color.White;
                            }
                            else if (sec < 0)
                            {
                                cel.BackColor = Color.DarkRed;
                                cel.ForeColor = Color.White;
                            }
                            else
                            {
                                cel.BackColor = Color.Green;
                                cel.ForeColor = Color.White;
                            }

                            bool k = true;
                            if (sec < 0)
                            {
                                k = false;
                                sec = sec - 2 * sec;
                            }
                            int minute = sec / 60;
                            int ore = minute / 60;
                            minute = minute % 60;
                            sec = sec % 60;

                            String str_sec = null;

                            if (sec < 10)
                            {
                                str_sec = "0" + sec;
                            }
                            else
                            {
                                str_sec = sec.ToString();
                            }

                            String str_min = null;



                            if (minute < 10)
                            {
                                str_min = "0" + minute;
                            }
                            else
                            {
                                str_min = minute.ToString();
                            }

                            labels[i * 3 + cellNum - 4] = new Label();
                            if (k)
                            {
                                labels[i * 3 + cellNum - 4].Text = ore.ToString() + ":" + str_min + ":" + str_sec;

                            }
                            else
                            {
                                labels[i * 3 + cellNum - 4].Text = "-" + ore.ToString() + ":" + str_min + ":" + str_sec;

                            }


                            cel.Controls.Add(labels[i * 3 + cellNum - 4]);
                        }

                        rw.Cells.Add(cel);
                        counter++;
                    }
                    Table1.Rows.Add(rw);
                    Table1.GridLines = GridLines.Both;
                    Table1.CellPadding = 4;
                    Table1.CellSpacing = 0;
                    Table1.Font.Size = 12;

                }
                string[] contact = nr_task[nr_task.Length - 1].Split(new Char[] { ';' });
                Label3.Text = contact[0];
                Label5.Text = contact[1];
                Label2.Font.Bold = true;
                Label3.Font.Bold = true;
                Label4.Font.Bold = true;
                Label5.Font.Bold = true;
            }
        }
        private void send_msg(TcpClient tc, NetworkStream ns, string message)
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
            while ((aux = (char)ns.ReadByte()) != (char)msg_delim)
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            send_msg(tc, ns, "C");
            Response.Redirect("Login.aspx");
        }
    }
}