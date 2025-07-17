using Microsoft.AspNetCore.Mvc;
using DevToolKit.Models;
using DevToolKit.Services;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using NJsonSchema.CodeGeneration.CSharp;

namespace DevToolKit.Controllers
{
    public class ToolsController : Controller
    {
        // 1. JSON Formatter
        [HttpGet("/tools/json-formatter")]
        public IActionResult JsonFormatter() => View();
        [HttpPost("/tools/json-formatter")]
        public IActionResult JsonFormatter(JsonFormatterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                try
                {
                    var jsonElement = System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(model.Input);
                    model.Output = System.Text.Json.JsonSerializer.Serialize(jsonElement, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
                    model.IsValid = true;
                }
                catch
                {
                    model.Output = "Invalid JSON";
                    model.IsValid = false;
                }
            }
            return View(model);
        }

        // 2. Text Diff Checker
        [HttpGet("/tools/text-diff")]
        public IActionResult TextDiff() => View();
        [HttpPost("/tools/text-diff")]
        public IActionResult TextDiff(TextDiffViewModel model)
        {
            model.DiffResult = TextDiffService.GetDiff(model.Text1 ?? string.Empty, model.Text2 ?? string.Empty);
            return View(model);
        }

        // 3. UUID Generator
        [HttpGet("/tools/uuid-generator")]
        public IActionResult UuidGenerator() => View();
        [HttpPost("/tools/uuid-generator")]
        public IActionResult UuidGenerator(UuidGeneratorViewModel model)
        {
            int count = model.Count > 0 && model.Count <= 100 ? model.Count : 1;
            model.Uuids = Enumerable.Range(0, count).Select(_ => Guid.NewGuid().ToString()).ToList();
            return View(model);
        }

        // 4. Base64 to File
        [HttpGet("/tools/base64-to-file")]
        public IActionResult Base64ToFile() => View();
        [HttpPost("/tools/base64-to-file")]
        public IActionResult Base64ToFile(Base64ToFileViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Base64String))
            {
                try
                {
                    var fileBytes = Convert.FromBase64String(model.Base64String);
                    var fileName = string.IsNullOrWhiteSpace(model.FileName) ? "file.bin" : model.FileName;
                    model.DownloadFileName = fileName;
                    model.DownloadFileContent = fileBytes;
                    model.IsValid = true;
                }
                catch
                {
                    model.IsValid = false;
                }
            }
            return View(model);
        }

        // 5. File to Base64
        [HttpGet("/tools/file-to-base64")]
        public IActionResult FileToBase64() => View();
        [HttpPost("/tools/file-to-base64")]
        public IActionResult FileToBase64(FileToBase64ViewModel model)
        {
            if (model.UploadFile != null && model.UploadFile.Length > 0)
            {
                using var ms = new MemoryStream();
                model.UploadFile.CopyTo(ms);
                model.Base64String = Convert.ToBase64String(ms.ToArray());
            }
            return View(model);
        }

        // 6. Hash Generator
        [HttpGet("/tools/hash-generator")]
        public IActionResult HashGenerator() => View();
        [HttpPost("/tools/hash-generator")]
        public IActionResult HashGenerator(HashGeneratorViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input) && !string.IsNullOrWhiteSpace(model.Algorithm))
            {
                model.Hash = HashService.ComputeHash(model.Input, model.Algorithm);
            }
            return View(model);
        }

        // 7. Slug Generator
        [HttpGet("/tools/slug-generator")]
        public IActionResult SlugGenerator() => View();
        [HttpPost("/tools/slug-generator")]
        public IActionResult SlugGenerator(SlugGeneratorViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                model.Slug = SlugService.GenerateSlug(model.Input);
            }
            return View(model);
        }

        // 8. Case Converter
        [HttpGet("/tools/case-converter")]
        public IActionResult CaseConverter() => View();
        [HttpPost("/tools/case-converter")]
        public IActionResult CaseConverter(CaseConverterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                model.CamelCase = CaseConverterService.ToCamelCase(model.Input);
                model.PascalCase = CaseConverterService.ToPascalCase(model.Input);
                model.UpperCase = model.Input.ToUpperInvariant();
                model.LowerCase = model.Input.ToLowerInvariant();
                model.KebabCase = CaseConverterService.ToKebabCase(model.Input);
                model.SnakeCase = CaseConverterService.ToSnakeCase(model.Input);
            }
            return View(model);
        }

        // 9. Lorem Ipsum Generator
        [HttpGet("/tools/lorem-ipsum-generator")]
        public IActionResult LoremIpsumGenerator() => View();
        [HttpPost("/tools/lorem-ipsum-generator")]
        public IActionResult LoremIpsumGenerator(LoremIpsumGeneratorViewModel model)
        {
            int count = model.Paragraphs > 0 && model.Paragraphs <= 20 ? model.Paragraphs : 1;
            model.ParagraphResults = LoremIpsumService.Generate(count);
            return View(model);
        }

        // 10. XML Formatter
        [HttpGet("/tools/xml-formatter")]
        public IActionResult XmlFormatter() => View();
        [HttpPost("/tools/xml-formatter")]
        public IActionResult XmlFormatter(XmlFormatterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                model.Output = XmlFormatterService.Format(model.Input);
            }
            return View(model);
        }

        // 11. SQL Formatter
        [HttpGet("/tools/sql-formatter")]
        public IActionResult SqlFormatter() => View();
        [HttpPost("/tools/sql-formatter")]
        public IActionResult SqlFormatter(SqlFormatterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                model.Output = SqlFormatterService.Format(model.Input);
            }
            return View(model);
        }

        // 12. Text to Hex
        [HttpGet("/tools/text-to-hex")]
        public IActionResult TextToHex() => View();
        [HttpPost("/tools/text-to-hex")]
        public IActionResult TextToHex(TextToHexViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                model.Hex = TextToHexService.ToHex(model.Input);
            }
            return View(model);
        }

        // 13. Random String Generator
        [HttpGet("/tools/random-string-generator")]
        public IActionResult RandomStringGenerator() => View();
        [HttpPost("/tools/random-string-generator")]
        public IActionResult RandomStringGenerator(RandomStringGeneratorViewModel model)
        {
            if (!model.UseNumbers && !model.UseLower && !model.UseUpper)
            {
                model.UseLower = true;
                ViewBag.Warning = "At least one character set must be selected. Lowercase will be used by default.";
            }
            model.Result = RandomStringService.Generate(model.Length, model.UseNumbers, model.UseLower, model.UseUpper);
            return View(model);
        }

        // 14. Password Generator
        [HttpGet("/tools/password-generator")]
        public IActionResult PasswordGenerator() => View();
        [HttpPost("/tools/password-generator")]
        public IActionResult PasswordGenerator(PasswordGeneratorViewModel model)
        {
            model.Result = PasswordGeneratorService.Generate(model.Length, model.UseNumbers, model.UseLower, model.UseUpper, model.UseSymbols);
            return View(model);
        }

        // 15. URL Encoder/Decoder
        [HttpGet("/tools/url-encoder-decoder")]
        public IActionResult UrlEncoderDecoder() => View();
        [HttpPost("/tools/url-encoder-decoder")]
        public IActionResult UrlEncoderDecoder(UrlEncoderDecoderViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                if (model.Mode == "encode")
                    model.Output = System.Net.WebUtility.UrlEncode(model.Input);
                else
                    model.Output = System.Net.WebUtility.UrlDecode(model.Input);
            }
            return View(model);
        }

        // 16. Color Picker
        [HttpGet("/tools/color-picker")]
        public IActionResult ColorPicker() => View();
        [HttpPost("/tools/color-picker")]
        public IActionResult ColorPicker(ColorPickerViewModel model)
        {
            // Just echo the color for now
            return View(model);
        }

        // 17. QR Code Generator
        [HttpGet("/tools/qr-code-generator")]
        public IActionResult QrCodeGenerator() => View();
        [HttpPost("/tools/qr-code-generator")]
        public IActionResult QrCodeGenerator(QrCodeGeneratorViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                model.QrCodeDataUrl = QrCodeService.GenerateQrCode(model.Input);
            }
            return View(model);
        }

        // 18. JWT Decoder
        [HttpGet("/tools/jwt-decoder")]
        public IActionResult JwtDecoder() => View();
        [HttpPost("/tools/jwt-decoder")]
        public IActionResult JwtDecoder(JwtDecoderViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input))
            {
                try
                {
                    var parts = model.Input.Split('.');
                    if (parts.Length != 3)
                        throw new Exception("Invalid JWT format");
                    string Base64UrlDecode(string s)
                    {
                        s = s.Replace('-', '+').Replace('_', '/');
                        switch (s.Length % 4)
                        {
                            case 2: s += "=="; break;
                            case 3: s += "="; break;
                        }
                        return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(s));
                    }
                    model.HeaderJson = Base64UrlDecode(parts[0]);
                    model.PayloadJson = Base64UrlDecode(parts[1]);
                    var payload = System.Text.Json.JsonDocument.Parse(model.PayloadJson);
                    if (payload.RootElement.TryGetProperty("exp", out var exp))
                    {
                        var expVal = exp.GetInt64();
                        model.Expiration = DateTimeOffset.FromUnixTimeSeconds(expVal).UtcDateTime;
                    }
                }
                catch (Exception ex)
                {
                    model.Error = ex.Message;
                }
            }
            return View(model);
        }

        // 19. XML ↔ JSON Converter
        [HttpGet("/tools/xml-json-converter")]
        public IActionResult XmlJsonConverter() => View();
        [HttpPost("/tools/xml-json-converter")]
        public IActionResult XmlJsonConverter(XmlJsonConverterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Input) && !string.IsNullOrWhiteSpace(model.Mode))
            {
                try
                {
                    if (model.Mode == "xml2json")
                    {
                        var doc = System.Xml.Linq.XDocument.Parse(model.Input);
                        string json = JsonConvert.SerializeXNode(doc, Formatting.Indented, true);
                        model.Output = json;
                    }
                    else if (model.Mode == "json2xml")
                    {
                        var jsonObj = JsonConvert.DeserializeObject<JToken>(model.Input);
                        var xml = JsonConvert.DeserializeXNode(jsonObj.ToString(), "Root");
                        model.Output = xml.ToString();
                    }
                }
                catch (Exception ex)
                {
                    model.Error = ex.Message;
                }
            }
            return View(model);
        }

        // 20. Regex Tester
        [HttpGet("/tools/regex-tester")]
        public IActionResult RegexTester() => View();
        [HttpPost("/tools/regex-tester")]
        public IActionResult RegexTester(RegexTesterViewModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Pattern) && !string.IsNullOrWhiteSpace(model.TestString))
            {
                try
                {
                    var matches = System.Text.RegularExpressions.Regex.Matches(model.TestString, model.Pattern);
                    model.Matches = matches.Select(m => m.Value).ToList();
                    model.Groups = matches.SelectMany(m => m.Groups.Cast<System.Text.RegularExpressions.Group>().Skip(1).Select(g => g.Value)).Where(g => !string.IsNullOrEmpty(g)).ToList();
                }
                catch (Exception ex)
                {
                    model.Error = ex.Message;
                }
            }
            return View(model);
        }
    }
} 