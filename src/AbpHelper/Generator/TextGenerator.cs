﻿using System;
using System.IO;
using Scriban;

namespace AbpHelper.Generator
{
    public static class TextGenerator
    {
        public static string GenerateByTemplateName(string templateName, object model)
        {
            var appDir = AppDomain.CurrentDomain.BaseDirectory!;
            var templateFile = Path.Combine(appDir, "Templates", templateName + ".sbntxt");
            var templateText = File.ReadAllText(templateFile);
            return GenerateByTemplateText(templateText, model);
        }

        public static string GenerateByTemplateText(string templateText, object model)
        {
            var template = Template.Parse(templateText);
            var text = template.Render(model, member => member.Name).Replace("\r\n", Environment.NewLine);
            return text;
        }
    }
}