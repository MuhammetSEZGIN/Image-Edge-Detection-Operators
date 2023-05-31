using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _1306200042_giodev2
{
    
    internal class Operations
    {
        Bitmap _changedPicture;
        Bitmap _orginalPicture;
        public Bitmap ChangedPicture
        {
            get => _changedPicture;
            set => _changedPicture = value;
        }
        public Bitmap OrginalPicture
        {
            get => _orginalPicture;
            set => _orginalPicture = value;
        }
        public Operations(Bitmap changedPicture, Bitmap orginalPicture)
        {
            ChangedPicture = changedPicture;
            OrginalPicture = orginalPicture;
        }
       

        public static void Save(PictureBox p)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.DefaultExt = "sonuc.png";
            sf.Filter = "Bitmap Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                p.Image.Save(sf.FileName);
            }
        }
        public void Prewit()
        {
            int[,] Gx = { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            int[,] Gy = { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };

            for (int y = 1; y < OrginalPicture.Height - 1; y++)
            {
                for (int x = 1; x < OrginalPicture.Width - 1; x++)
                {
                    int pixelSumX = 0, pixelSumY = 0;

                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixelColor = OrginalPicture.GetPixel(x + i, y + j);
                            pixelSumX += Gx[i + 1, j + 1] * pixelColor.R;
                            pixelSumY += Gy[i + 1, j + 1] * pixelColor.R;
                        }
                    }

                    int edgePixel = (int)Math.Sqrt(pixelSumX * pixelSumX + pixelSumY * pixelSumY);
                    edgePixel = edgePixel > 255 ? 255 : edgePixel;
                    edgePixel = edgePixel < 0 ? 0 : edgePixel;

                    Color edgeColor = Color.FromArgb(edgePixel, edgePixel, edgePixel);
                    ChangedPicture.SetPixel(x, y, edgeColor);
                }
            }
        }

        public void Robert()
        {
            int[,] Gx = { { 1, 0 }, { 0, -1 } };
            int[,] Gy = { { 0, 1 }, { -1, 0 } };

            for (int y = 0; y < OrginalPicture.Height - 1; y++)
            {
                for (int x = 0; x < OrginalPicture.Width - 1; x++)
                {
                    int pixelSumX = 0, pixelSumY = 0;

                    for (int j = 0; j <= 1; j++)
                    {
                        for (int i = 0; i <= 1; i++)
                        {
                            Color pixelColor = OrginalPicture.GetPixel(x + i, y + j);
                            pixelSumX += Gx[i, j] * pixelColor.R;
                            pixelSumY += Gy[i, j] * pixelColor.R;
                        }
                    }

                    int edgePixel = (int)Math.Sqrt(pixelSumX * pixelSumX + pixelSumY * pixelSumY);
                    edgePixel = edgePixel > 255 ? 255 : edgePixel;
                    edgePixel = edgePixel < 0 ? 0 : edgePixel;

                    Color edgeColor = Color.FromArgb(edgePixel, edgePixel, edgePixel);
                    ChangedPicture.SetPixel(x, y, edgeColor);
                }
            }
        }

        public void Compass()
        {
            int[,] filter1 = { { -1, -1, -1 }, { 1, -2, 1 }, { 1, 1, 1 } };
            int[,] filter2 = { { -1, -1, 1 }, { -1, -2, 1 }, { 1, 1, 1 } };
            int[,] filter3 = { { -1, 1, 1 }, { -1, -2, 1 }, { -1, 1, 1 } };
            int[,] filter4 = { { 1, 1, 1 }, { -1, -2, -1 }, { -1, -1, 1 } };
            int[,] filter5 = { { 1, 1, 1 }, { 1, -2, 1 }, { -1, -1, -1 } };
            int[,] filter6 = { { 1, 1, 1 }, { 1, -2, -1 }, { 1, -1, -1 } };
            int[,] filter7 = { { 1, 1, -1 }, { 1, -2, -1 }, { 1, 1, -1 } };
            int[,] filter8 = { { 1, -1, -1 }, { 1, -2, -1 }, { 1, 1, 1 } };

            for (int y = 1; y < OrginalPicture.Height - 1; y++)
            {
                for (int x = 1; x < OrginalPicture.Width - 1; x++)
                {
                    int[] pixelSum = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int j = -1; j <= 1; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            Color pixelColor = OrginalPicture.GetPixel(x + i, y + j);

                            pixelSum[0] += filter1[i + 1, j + 1] * pixelColor.R;
                            pixelSum[1] += filter2[i + 1, j + 1] * pixelColor.R;
                            pixelSum[2] += filter3[i + 1, j + 1] * pixelColor.R;
                            pixelSum[3] += filter4[i + 1, j + 1] * pixelColor.R;
                            pixelSum[4] += filter5[i + 1, j + 1] * pixelColor.R;
                            pixelSum[5] += filter6[i + 1, j + 1] * pixelColor.R;
                            pixelSum[6] += filter7[i + 1, j + 1] * pixelColor.R;
                            pixelSum[7] += filter8[i + 1, j + 1] * pixelColor.R;
                        }
                    }


                    int edgePixel = pixelSum.Max();
                    edgePixel = edgePixel > 255 ? 255 : edgePixel;
                    edgePixel = edgePixel < 0 ? 0 : edgePixel;
                    ChangedPicture.SetPixel(x, y, Color.FromArgb(edgePixel, edgePixel, edgePixel));


                }
            }
        }
    }
}
