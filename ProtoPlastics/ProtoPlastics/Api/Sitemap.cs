using Microsoft.AspNetCore.Components;
using System.Reflection;
using System.Text;

namespace ProtoPlastics.Api
{
    public class Sitemap
    {
        public static async Task Generate(HttpContext context)
        {
            // Console.WriteLine("Generating Sitemap");
            var pages = Assembly.GetExecutingAssembly().ExportedTypes.Where(p =>
            p.IsSubclassOf(typeof(ComponentBase)) && p.Namespace == "ProtoPlastics.Pages");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("""<?xml version="1.0" encoding="utf-8"?>""");
            sb.AppendLine("""<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9">""");
            foreach (var page in pages)
            {
                string pageName = page.Name.ToLower();
                if (pageName == "home") pageName = "";
                sb.AppendLine("<url>");
                sb.AppendLine($"<loc>https://protoplastics.ca/{pageName}</loc>");
                sb.AppendLine("</url>");
            }
            sb.AppendLine("</urlset>");

            // Console.WriteLine(sb.ToString());

            await context.Response.WriteAsync(sb.ToString() + "\n");
        }
    }
}