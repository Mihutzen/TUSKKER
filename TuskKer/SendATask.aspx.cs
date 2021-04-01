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
    public partial class SendATask : System.Web.UI.Page
    {
        static TcpClient tc = new TcpClient("IP", PORT);
        NetworkStream ns = tc.GetStream();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            send_msg(tc, ns, "2");
            string recv_mess = recv_msg(ns);

            if (recv_mess != "None")
            {
                string[] groups = recv_mess.Split(new Char[] { ',' });
                foreach (string s in groups)
                {
                    if (s.Trim() != "")
                    {
                        DropDownList12.Items.Add(s);
                    }
                }
            }

            VerificareSelectare();

            if (DropDownList1.Items.Count == 0)
            {

                DropDownList1.Items.Add(" ");

                send_msg(tc, ns, "3");
                recv_mess = recv_msg(ns);

                string[] groups = recv_mess.Split(new Char[] { ' ' });
                foreach (string s in groups)
                {
                    if (s.Trim() != "")
                    {
                        DropDownList1.Items.Add(s);
                    }
                }
            }
            
            
            if (DropDownList2.Items.Count == 0)
            {

                DropDownList2.Items.Add("1 - task requires <= 1 hour"); //60
                DropDownList2.Items.Add("2 - task requires <= 2 hours"); //120
                DropDownList2.Items.Add("3 - task requires <= 3 hours"); //180
                DropDownList2.Items.Add("4 - task requires <= 4 hours"); //240
                DropDownList2.Items.Add("5 - task requires <= 6 hours"); //360

                DropDownList3.Items.Add("1");
                DropDownList3.Items.Add("2");
                DropDownList3.Items.Add("3");
                DropDownList3.Items.Add("4");
                DropDownList3.Items.Add("5");

                DropDownList4.Items.Add("1");
                DropDownList4.Items.Add("2");
                DropDownList4.Items.Add("3");
                DropDownList4.Items.Add("4");
                DropDownList4.Items.Add("5");
                DropDownList4.Items.Add("6");
                DropDownList4.Items.Add("7");
                DropDownList4.Items.Add("8");
                DropDownList4.Items.Add("9");
                DropDownList4.Items.Add("10");

                DropDownList5.Items.Add("1");
                DropDownList5.Items.Add("2");
                DropDownList5.Items.Add("3");
                DropDownList5.Items.Add("4");
                DropDownList5.Items.Add("5");
                DropDownList5.Items.Add("6");
                DropDownList5.Items.Add("7");
                DropDownList5.Items.Add("8");
                DropDownList5.Items.Add("9");
                DropDownList5.Items.Add("10");

                DropDownList6.Items.Add("1");
                DropDownList6.Items.Add("2");
                DropDownList6.Items.Add("3");
                DropDownList6.Items.Add("4");
                DropDownList6.Items.Add("5");
                DropDownList6.Items.Add("6");
                DropDownList6.Items.Add("7");
                DropDownList6.Items.Add("8");
                DropDownList6.Items.Add("9");
                DropDownList6.Items.Add("10");

                DropDownList7.Items.Add("-");
                DropDownList7.Items.Add("Assembly");
                DropDownList7.Items.Add("BASH");
                DropDownList7.Items.Add("C");
                DropDownList7.Items.Add("C++");
                DropDownList7.Items.Add("C#");
                DropDownList7.Items.Add("CSS");
                DropDownList7.Items.Add("HTML");
                DropDownList7.Items.Add("Java");
                DropDownList7.Items.Add("JavaScript");
                DropDownList7.Items.Add("Python");
                DropDownList7.Items.Add("SQL");

                DropDownList8.Items.Add("-");
                DropDownList8.Items.Add("Assembly");
                DropDownList8.Items.Add("BASH");
                DropDownList8.Items.Add("C");
                DropDownList8.Items.Add("C++");
                DropDownList8.Items.Add("C#");
                DropDownList8.Items.Add("CSS");
                DropDownList8.Items.Add("HTML");
                DropDownList8.Items.Add("Java");
                DropDownList8.Items.Add("JavaScript");
                DropDownList8.Items.Add("Python");
                DropDownList8.Items.Add("SQL");

                DropDownList9.Items.Add("-");
                DropDownList9.Items.Add("Assembly");
                DropDownList9.Items.Add("BASH");
                DropDownList9.Items.Add("C");
                DropDownList9.Items.Add("C++");
                DropDownList9.Items.Add("C#");
                DropDownList9.Items.Add("CSS");
                DropDownList9.Items.Add("HTML");
                DropDownList9.Items.Add("Java");
                DropDownList9.Items.Add("JavaScript");
                DropDownList9.Items.Add("Python");
                DropDownList9.Items.Add("SQL");

                DropDownList10.Items.Add("0 hours");
                DropDownList10.Items.Add("1 hour");
                DropDownList10.Items.Add("2 hours");
                DropDownList10.Items.Add("3 hours");
                DropDownList10.Items.Add("4 hours");
                DropDownList10.Items.Add("5 hours");
                DropDownList10.Items.Add("6 hours");

                DropDownList11.Items.Add("0 minutes");
                DropDownList11.Items.Add("5 minutes");
                DropDownList11.Items.Add("10 minutes");
                DropDownList11.Items.Add("15 minutes");
                DropDownList11.Items.Add("20 minutes");
                DropDownList11.Items.Add("25 minutes");
                DropDownList11.Items.Add("30 minutes");
                DropDownList11.Items.Add("35 minutes");
                DropDownList11.Items.Add("40 minutes");
                DropDownList11.Items.Add("45 minutes");
                DropDownList11.Items.Add("50 minutes");
                DropDownList11.Items.Add("55 minutes");
            }
            
            
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string Pri=null;
            int EstimatedMin=0;

            if(DropDownList11.Text == "0 minutes")
            {
                EstimatedMin = 0;
            }
            else if(DropDownList11.Text == "5 minutes")
            {
                EstimatedMin = 5;
            }
            else if (DropDownList11.Text == "10 minutes")
            {
                EstimatedMin = 10;
            }
            else if (DropDownList11.Text == "15 minutes")
            {
                EstimatedMin = 15;
            }
            else if (DropDownList11.Text == "20 minutes")
            {
                EstimatedMin = 20;
            }
            else if (DropDownList11.Text == "25 minutes")
            {
                EstimatedMin = 25;
            }
            else if (DropDownList11.Text == "30 minutes")
            {
                EstimatedMin = 30;
            }
            else if (DropDownList11.Text == "35 minutes")
            {
                EstimatedMin = 35;
            }
            else if (DropDownList11.Text == "40 minutes")
            {
                EstimatedMin = 40;
            }
            else if (DropDownList11.Text == "45 minutes")
            {
                EstimatedMin = 45;
            }
            else if (DropDownList11.Text == "50 minutes")
            {
                EstimatedMin = 50;
            }
            else if (DropDownList11.Text == "55 minutes")
            {
                EstimatedMin = 55;
            }

            int EstimatedTime = (int)Char.GetNumericValue(DropDownList10.Text.ElementAt(0)) * 60 + EstimatedMin;

            if (DropDownList2.Text.Contains("1 - task requires <= 1 hour"))
            {
                Pri = "1";
            }
            else if(DropDownList2.Text.Contains("2 - task requires <= 2 hours"))
            {
                Pri = "2";
            }
            else if(DropDownList2.Text.Contains("3 - task requires <= 3 hours"))
            {
                Pri = "3";
            }
            else if(DropDownList2.Text.Contains("4 - task requires <= 4 hours"))
            {
                Pri = "4";
            }
            else if(DropDownList2.Text.Contains("5 - task requires <= 6 hours"))
            {
                Pri = "5";
            }

            string Dif = DropDownList3.SelectedValue;
            string skill1;
            string skill2;
            string skill3;

            if (DropDownList7.SelectedValue == "Assembly")
            {
                skill1 = "ASSEMBLY";
            }
            else if (DropDownList7.SelectedValue == "C++")
            {
                skill1 = "CPP";
            }
            else if (DropDownList7.SelectedValue == "C#")
            {
                skill1 = "CSHARP";
            }
            else if (DropDownList7.SelectedValue == "Java")
            {
                skill1 = "JAVA";
            }
            else if (DropDownList7.SelectedValue == "JavaScript")
            {
                skill1 = "JAVASCRIPT";
            }
            else if (DropDownList7.SelectedValue == "Python")
            {
                skill1 = "PYTHON";
            }
            else if (DropDownList7.SelectedValue == "SQL")
            {
                skill1 = "DB";
            }
            else
            {
                skill1 = DropDownList7.SelectedValue;
            }

            if (DropDownList8.SelectedValue == "Assembly")
            {
                skill2 = "ASSEMBLY";
            }
            else if (DropDownList8.SelectedValue == "C++")
            {
                skill2 = "CPP";
            }
            else if (DropDownList8.SelectedValue == "C#")
            {
                skill2 = "CSHARP";
            }
            else if (DropDownList8.SelectedValue == "Java")
            {
                skill2 = "JAVA";
            }
            else if (DropDownList8.SelectedValue == "JavaScript")
            {
                skill2 = "JAVASCRIPT";
            }
            else if (DropDownList8.SelectedValue == "Python")
            {
                skill2 = "PYTHON";
            }
            else if (DropDownList8.SelectedValue == "SQL")
            {
                skill2 = "DB";
            }
            else
            {
                skill2 = DropDownList8.SelectedValue;
            }

            if (DropDownList9.SelectedValue == "Assembly")
            {
                skill3 = "ASSEMBLY";
            }
            else if (DropDownList9.SelectedValue == "C++")
            {
                skill3 = "CPP";
            }
            else if (DropDownList9.SelectedValue == "C#")
            {
                skill3 = "CSHARP";
            }
            else if (DropDownList9.SelectedValue == "Java")
            {
                skill3 = "JAVA";
            }
            else if (DropDownList9.SelectedValue == "JavaScript")
            {
                skill3 = "JAVASCRIPT";
            }
            else if (DropDownList9.SelectedValue == "Python")
            {
                skill3 = "PYTHON";
            }
            else if (DropDownList9.SelectedValue == "SQL")
            {
                skill3 = "DB";
            }
            else
            {
                skill3 = DropDownList9.SelectedValue;
            }

            string skillr1 = DropDownList4.SelectedValue;
            string skillr2 = DropDownList5.SelectedValue;
            string skillr3 = DropDownList6.SelectedValue;

            if (DropDownList1.SelectedValue == " " || TextBox2.Text == "" || TextBox3.Text == "" )
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please fill all the textboxes with the right data.');", true);

            }
            else if (skill1.Contains("-") && skill2.Contains("-") && skill3.Contains("-"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please fill all the textboxes with the right data.');", true);
            }
            else if((Pri == "1" && EstimatedTime >= 60) || (Pri == "2" && EstimatedTime >= 120) || (Pri == "3" && EstimatedTime >= 180) || (Pri == "4" && EstimatedTime >= 240) || (Pri == "5" && EstimatedTime >= 360))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Estimated Time must corespond to Priority Level.');", true);
            }
            else
            {

                string mesage = "4" + DropDownList1.Text + "|" + TextBox2.Text + "|" + TextBox3.Text + "|" + Pri + "|" + Dif + "|" + EstimatedTime;
                int prim = 0;
                if (!skill1.Contains("-"))
                {
                    if(skillr1=="10")
                    {
                        skillr1 = "9";
                    }
                    mesage += "|" + skill1 + ":" + skillr1 + ";";
                    prim++;
                }
                if (!skill2.Contains("-"))
                {
                    if (skillr2 == "10")
                    {
                        skillr2 = "9";
                    }
                    if (prim != 0)
                    {
                        mesage += skill2 + ":" + skillr2 + ";";
                    }
                    if (prim == 0)
                    {
                        mesage += "|" + skill2 + ":" + skillr2 + ";";
                        prim++;
                    }
                }
                if (!skill3.Contains("-"))
                {
                    if (skillr3 == "10")
                    {
                        skillr3 = "9";
                    }
                    if (prim != 0)
                    {
                        mesage += skill3 + ":" + skillr3 + ";";
                    }
                    if (prim == 0)
                    {
                        mesage += "|" + skill3 + ":" + skillr3 + ";";
                    }
                }

                

                send_msg(tc, ns, mesage);
               
                string recv_mess = recv_msg(ns);

                string[] pop = recv_mess.Split(new Char[] { ':', ';' });

                if (pop[0][0] == '1')
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Task sent');", true);
                    DropDownList1.ClearSelection();
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    DropDownList2.ClearSelection();
                    DropDownList3.ClearSelection();
                    DropDownList4.ClearSelection();
                    DropDownList5.ClearSelection();
                    DropDownList6.ClearSelection();
                    DropDownList7.ClearSelection();
                    DropDownList8.ClearSelection();
                    DropDownList9.ClearSelection();
                    DropDownList10.ClearSelection();
                    DropDownList11.ClearSelection();
                    //Response.Redirect("SendATask.aspx");
                    Response.AppendHeader("Refresh", "1");
                }
                else
                {
                    string aux = pop[0];
                    aux = aux.Remove(0, 1);
                    pop[0] = aux;
                    string mesaj="";

                    for (int i=0; i<pop.Length; i++)
                    {
                        string s = pop[i];

                        if (s.Trim() != "")
                        {
                            if(s.Contains("0") || s.Contains("1") || s.Contains("2") || s.Contains("3") || s.Contains("4") || s.Contains("5") || s.Contains("6") || s.Contains("7") || s.Contains("8") || s.Contains("9") || s.Contains("10"))
                            {
                                mesaj += ": " + s + "; ";
                            }
                            else if(s.Contains("ASSEMBLY"))
                            {
                                mesaj += "Assembly";
                            }
                                else if(s.Contains("CPP"))
                            {
                                mesaj += "C++";
                            }
                                    else if(s.Contains("CSHARP"))
                            {
                                mesaj += "C#";
                            }
                                        else if(s.Contains("JAVA"))
                            {
                                mesaj += "Java";
                            }
                                            else if(s.Contains("JAVASCRIPT"))
                            {
                                mesaj += "JavaScript";
                            }
                                                else if(s.Contains("PYTHON"))
                            {
                                mesaj += "Python";
                            }
                                                    else if(s.Contains("DB"))
                            {
                                mesaj += "SQL";
                            }
                                                        else
                            {
                                mesaj += s;
                            }
                        }
                    }
                    string popup = "alert(' Closest skills are: "+mesaj+"');";
                    
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myalert", popup, true); //printez siru

                }
            }
        }
        private void VerificareSelectare()
        {
            if (DropDownList12.SelectedItem.Text != "Active Users")
            {
                Session["Data"] = DropDownList12.SelectedItem.Text;
                Response.Redirect("MyTeam.aspx");
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