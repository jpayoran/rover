using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RoverAppWeb.Models;
using RoverAppWeb.Classes;
using System.Text;
using System.Text.RegularExpressions;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private string GetImages(DateTime queryDate)
    {
        try
        {
            RoverObject rover;
            rover = new RoverClass().QueryRoverObject(queryDate);
            StringBuilder sb = new StringBuilder();
            string img;

            sb.AppendLine("<table border = '1'>");

            foreach (Photo item in rover.photos)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td>Date</td>");
                sb.AppendLine(string.Format("<td>{0}</td>", item.earth_date));
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>ID</td>");
                sb.AppendLine(string.Format("<td>{0}</td>", item.id));
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>Rover</td>");
                sb.AppendLine(string.Format("<td>{0}</td>", item.rover.name));
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>Camera</td>");
                sb.AppendLine(string.Format("<td>{0}</td>", item.camera.full_name));
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                img = "<img src = '{0}' alt = '{1}' style = 'max-width:500px;' />";
                img = string.Format(img, item.img_src, item.earth_date);
                sb.AppendLine(string.Format("<td valign = 'top'>Image</td><td>{0}</td>", img));
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table>");
            return sb.ToString();
        }
        catch(Exception ex)
        {
            return string.Format("An error has been encountered: {0}", ex.Message);
        }
    }

    protected void cmdLoad_Click(object sender, EventArgs e)
    {
        string input = txtDates.Text;
        DateTime queryDate;
        StringBuilder sb = new StringBuilder();

        string[] elements = Regex.Split(input,"\r\n");

        divMessage.InnerHtml = "";
        divInfo.InnerHtml = "";

        foreach (string item in elements)
        {
            if (DateTime.TryParse(item, out queryDate))
            {
                divMessage.InnerHtml += string.Format("{0} - Valid Date</br>", item);
                sb.AppendLine(GetImages(queryDate));
            }
            else
            {
                divMessage.InnerHtml += string.Format("{0} - Invalid Date</br>", item);
            }
        }
        divInfo.InnerHtml = sb.ToString();
    }
}