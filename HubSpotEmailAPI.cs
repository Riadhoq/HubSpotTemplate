using System.Collections.Generic;

namespace FEE.CRM
{

    public static class HubSpotEmailAPI
    {
       
        public static string CreateDailyCampaign(string name, List<ArticleModel> articles)
        {
            var html = "";
            html+="{% module 'module_1521644111098100' module_id = '2740451' label = 'FEEDaily Header' %}";
            html += "{% widget_block rich_text 'my_rich_text_module' overrideable = True, label = 'Edit Content' %}{% widget_attribute 'html' %}";
            foreach (var article in articles)
            {
                html += string.Format("<tr mc:repeatable><td align='center' valign='top'><table border='0' cellspacing='0' cellpadding='0'><tr><td class='bodyContent' style='padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;'>");
                html += string.Format("<a href='{0}' mc:edit='body_image'><img src='{1}' border='0' style='margin: 0; padding: 0;margin: 0; padding: 0'></a><tr><td valign='top' class='bodyContent' mc:edit='body_content'>", article.Url, article.ImageUrl);
                html += string.Format("<a class='title' href=\'{0}\'>{1}</a>", article.Url, article.Header);
                if (!string.IsNullOrEmpty(article.Author))
                    html += string.Format("<p>by {0}</p>", article.Author);
                html += "" + article.Description + "";
                html += string.Format("<a class='cta-text' href=\'{0}\'>{1}</a>", article.Url,
                    !string.IsNullOrEmpty(article.Subtitle) ? article.Subtitle.ToUpper() : "READ MORE");
                html += "</td></tr></table></td></tr>";
            }
            html += "{% end_widget_attribute %}{% end_widget_block %}";
            html += "{% module 'module_1521644393417106' module_id='2740525' label='FEEEmail Footer' %}";

            HubSpotEmailTemplateAPI hubSpotEmailTemplateAPI = new HubSpotEmailTemplateAPI();
            var result = hubSpotEmailTemplateAPI.CreateHubspotDailyTemplate(html);

            return "https://app.hubspot.com/beta-design-manager/2689599/code/" + result;

        }

        public static string CreateWeeklyCampaign(string name, List<ArticleModel> articles)
        {

            var html = "";
            html += "{% module 'module_152164612295563' module_id='2740661' label='FEEWeekly Header' %}";
            html += "{% widget_block rich_text 'my_rich_text_module' overrideable = True, label = 'Edit Content' %}{% widget_attribute 'html' %}";

            foreach (var article in articles)
            {
                html += string.Format("<tr mc:repeatable><td align='center' valign='top'><table border='0' cellspacing='0' cellpadding='0'><tr><td class='bodyContent' style='padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;'>");
                html += string.Format("<a href='{0}' mc:edit='body_image'><img src='{1}' border='0' style='margin: 0; padding: 0;margin: 0; padding: 0'></a><tr><td valign='top' class='bodyContent' mc:edit='body_content'>", article.Url, article.ImageUrl);
                html += string.Format("<a class='title' href=\'{0}\'>{1}</a>", article.Url, article.Header);
                if (!string.IsNullOrEmpty(article.Author))
                    html += string.Format("<p>by {0}</p>", article.Author);
                html += "" + article.Description + "";
                html += string.Format("<a class='cta-text' href=\'{0}\'>{1}</a>", article.Url,
                    !string.IsNullOrEmpty(article.Subtitle) ? article.Subtitle.ToUpper() : "READ MORE");
                html += "</td></tr></table></td></tr>";
            }

            html += "{% end_widget_attribute %}{% end_widget_block %}";
            html += "{% module 'module_1521644393417106' module_id='2740525' label='FEEEmail Footer' %}";

            HubSpotEmailTemplateAPI hubSpotEmailTemplateAPI = new HubSpotEmailTemplateAPI();
            var result = hubSpotEmailTemplateAPI.CreateHubspotDailyTemplate(html);

            return "https://app.hubspot.com/beta-design-manager/2689599/code/" + result;
        }
    }
}
