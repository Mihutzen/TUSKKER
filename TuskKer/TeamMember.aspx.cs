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
    public partial class TeamMember : System.Web.UI.Page
    {

        static TcpClient tc = new TcpClient("IP", PORT);
        NetworkStream ns = tc.GetStream();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Refresh", "10");
            data();
        }
        private void start(Object sender, EventArgs e, String task_name)
        {
            send_msg(tc, ns, "5" + task_name);
            string recv_mess = recv_msg(ns);
            if (recv_mess == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Task already started.');", true);
            }
            else
            {
                Response.Redirect("TeamMember.aspx");
            }
        }

        private void stop(Object sender, EventArgs e, String task_name)
        {
            send_msg(tc, ns, "8" + task_name);
            string recv_mess = recv_msg(ns);
            if (recv_mess == "0")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Task has to be started in order for it to be stopped.');", true);
            }
            else
            {
                Response.Redirect("TeamMember.aspx");
            }
        }

        private void hold_unhold(Object sender, EventArgs e, String task_name)
        {
            Button b = (Button)sender;
            if (b.Text == "Hold")
            {
                send_msg(tc, ns, "6" + task_name);
                string recv_mess = recv_msg(ns);
                if (recv_mess == "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Task has to be started in order for it to be holded.');", true);
                }
                else
                {
                    b.Text = "Unhold";
                    Response.Redirect("TeamMember.aspx");
                }

            }
            else
            {
                send_msg(tc, ns, "7" + task_name);
                string recv_mess = recv_msg(ns);
                b.Text = "Hold";
                Response.Redirect("TeamMember.aspx");
            }
        }

        private void data()
        {

            send_msg(tc, ns, "9");
            string recv_mess = recv_msg(ns); //"A|B|C|D|1920~A|B|C|D|123~A|B|C|D|1400"; // recv_msg(ns);
            if (recv_mess != "")
            {
                int counter = 1;

                string[] nr_task = recv_mess.Split(new Char[] { '~' });

                Button[] buttons = new Button[99];
                Label[] labels = new Label[33];

                for (int i = 0; i < nr_task.Length; i++)
                {
                    string[] words = nr_task[i].Split(new Char[] { '|' });

                    TableRow rw = new TableRow();

                    for (int cellNum = 0; cellNum < words.Length + 3; cellNum++)
                    {
                        TableCell cel = new TableCell();

                        if (counter % 8 == 1)
                        {
                            cel.Text = words[0];
                        }
                        else if (counter % 8 == 2)
                        {
                            cel.Text = words[1];
                        }
                        else if (counter % 8 == 3)
                        {
                            cel.Text = words[2];
                        }
                        else if (counter % 8 == 4)
                        {
                            buttons[i * 3 + cellNum - 3] = new Button();
                            buttons[i * 3 + cellNum - 3].Text = "Start";
                            buttons[i * 3 + cellNum - 3].ForeColor = Color.FromArgb(1, 63, 127, 191);
                            buttons[i * 3 + cellNum - 3].Width = 100;
                            buttons[i * 3 + cellNum - 3].Font.Bold = true;
                            buttons[i * 3 + cellNum - 3].Click += delegate (object sender, EventArgs e) { start(sender, e, words[0]); };

                            cel.Controls.Add(buttons[i * 3 + cellNum - 3]);
                        }
                        else if (counter % 8 == 5)
                        {
                            buttons[i * 3 + cellNum - 3] = new Button();
                            if (words[3] == "1" || words[3] == "0")
                            {
                                buttons[i * 3 + cellNum - 3].Text = "Hold";
                            }
                            else
                            {
                                buttons[i * 3 + cellNum - 3].Text = "Unhold";
                            }
                            buttons[i * 3 + cellNum - 3].ForeColor = Color.FromArgb(1, 63, 127, 191);
                            buttons[i * 3 + cellNum - 3].Width = 100;
                            buttons[i * 3 + cellNum - 3].Font.Bold = true;

                            buttons[i * 3 + cellNum - 3].Click += delegate (object sender, EventArgs e) { hold_unhold(sender, e, words[0]); };

                            cel.Controls.Add(buttons[i * 3 + cellNum - 3]);
                        }
                        else if (counter % 8 == 6)
                        {
                            buttons[i * 3 + cellNum - 3] = new Button();
                            buttons[i * 3 + cellNum - 3].Text = "Stop";
                            buttons[i * 3 + cellNum - 3].ForeColor = Color.FromArgb(1, 63, 127, 191);
                            buttons[i * 3 + cellNum - 3].Width = 100;
                            buttons[i * 3 + cellNum - 3].Font.Bold = true;

                            buttons[i * 3 + cellNum - 3].Click += delegate (object sender, EventArgs e) { stop(sender, e, words[0]); };

                            cel.Controls.Add(buttons[i * 3 + cellNum - 3]);
                        }
                        else if (counter % 8 == 7)
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
                        else if (counter % 8 == 0)
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

                            labels[i * 3 + cellNum - 7] = new Label();
                            if (k)
                            {
                                labels[i * 3 + cellNum - 7].Text = ore.ToString() + ":" + str_min + ":" + str_sec;

                            }
                            else
                            {
                                labels[i * 3 + cellNum - 7].Text = "-" + ore.ToString() + ":" + str_min + ":" + str_sec;

                            }


                            cel.Controls.Add(labels[i * 3 + cellNum - 7]);

                        }

                        // index_of_button/3 => task number aka linia
                        rw.Cells.Add(cel);
                        counter++;
                    }
                    Table1.Rows.Add(rw);
                    Table1.GridLines = GridLines.Both;
                    Table1.CellPadding = 4;
                    Table1.CellSpacing = 0;
                    Table1.Font.Size = 12;

                }
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