using Microsoft.AspNetCore.Http;
using software.common.Controllers;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace software.common.Common
{
    public static class CaptCha
    {
        const string Letters = "1234567890";
        public static string GenerateCaptchaCode()
        {
            Random random = new Random();
            int maxRand = Letters.Length - 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(maxRand);
                sb.Append(Letters[index]);
            }
            var captchacode = sb.ToString();
            captchacode = captchacode.Trim().ToLower();
            return captchacode;
        }
        public static bool ValidateCaptchaCode(string userInputCaptcha, HttpContext context)
        {
            var isValid = userInputCaptcha == context.Session.GetString("CaptchaCode");
            context.Session.Remove("CaptchaCode");
            return isValid;
        }
        public static CaptChaResult GeneratrCaptchaImage(int width, int height, string captchaCode)
        {
            using (Bitmap baseMap = new Bitmap(width, height))
            using (Graphics graph = Graphics.FromImage(baseMap))
            {
                Random random = new Random();
                graph.Clear(GetRandomLightColor());
                DrawCaptchaCode();
                AdjustRippleEffect();
                MemoryStream ms = new MemoryStream();
                baseMap.Save(ms, ImageFormat.Png);
                return new CaptChaResult { CaptChaCode = captchaCode, CaptChaByte = ms.ToArray(), TimeStamp = DateTime.Now };


                int GetFontSize(int imageWidth, int captchaCodeCount)
                {
                    var averageSize = imageWidth / captchaCodeCount;
                    return Convert.ToInt32(averageSize);
                }
                Color GetRandomDeepColor()
                {
                    int redlow = 160, greenlow = 100, bluelow = 160;
                    return Color.FromArgb(random.Next(redlow), random.Next(greenlow), random.Next(bluelow));
                }
                Color GetRandomLightColor()
                {
                    int redlow = 160, greenlow = 100, bluelow = 160;
                    return Color.FromArgb(random.Next(redlow), random.Next(greenlow), random.Next(bluelow));
                }
                void DrawCaptchaCode()
                {
                    SolidBrush solidBrush = new SolidBrush(Color.Black);
                    int fontSize = GetFontSize(width, captchaCode.Length);
                    Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                    for (int i = 0; i < captchaCode.Length; i++)
                    {
                        solidBrush.Color = GetRandomDeepColor();
                        int shiftPx = fontSize / 6;
                        float x = i * fontSize + random.Next(-shiftPx, shiftPx) + random.Next(-shiftPx, shiftPx);
                        int maxY = height - fontSize;
                        if (maxY < 0) maxY = 0;
                        float y = random.Next(0, maxY);
                        graph.DrawString(captchaCode[i].ToString(), font, solidBrush, x, y);
                    }

                }
                void DrawDisorderLine()
                {
                    Pen linePen = new Pen(new SolidBrush(Color.Black), 3);
                    for (int i = 0; i < random.Next(3, 5); i++)
                    {
                        linePen.Color = GetRandomDeepColor();
                        Point startPoint = new Point(random.Next(0, width), random.Next(0, height));
                        Point endPoint = new Point(random.Next(0, width), random.Next(0, height));
                        graph.DrawLine(linePen, startPoint, endPoint);
                    }
                }
                void AdjustRippleEffect()
                {
                    short nWave = 6;
                    int nWidth = baseMap.Width;
                    int nHeight = baseMap.Height;
                    Point[,] pt = new Point[nWidth, nHeight];
                    for (int x = 0; x < nWidth; x++)
                    {
                        for (int y = 0; y < nHeight; y++)
                        {
                            var xo = nWave * Math.Sin(2.0 * 3.1415 * y / 128.0);
                            var yo = nWave * Math.Sin(2.0 * 3.1415 * y / 128.0);
                            var newX = x + xo;
                            var newY = y + yo;
                            if (newX > 0 && newY < nWidth)
                            {
                                pt[x, y].X = (int)newX;
                            }
                            else
                            {
                                pt[x, y].X = 0;
                            }
                            if (newX > 0 && newY < nHeight)
                            {
                                pt[x, y].Y = (int)newY;
                            }
                            else
                            {
                                pt[x, y].Y = 0;
                            }
                        }
                    }
                    Bitmap bSrc = (Bitmap)baseMap.Clone();

                    BitmapData bitmapData = baseMap.LockBits(new Rectangle(0, 0, baseMap.Width, baseMap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, baseMap.Width, baseMap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                    int scanLine = bitmapData.Stride;
                    IntPtr scan0 = bitmapData.Scan0;
                    IntPtr srcscan0 = bmSrc.Scan0;


                    baseMap.UnlockBits(bitmapData);
                    bSrc.UnlockBits(bmSrc);
                    bSrc.Dispose();

                }
            }
        }
    }
}
