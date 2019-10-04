using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamecaro
{
    public class banco
    {
         #region Properties
        private Panel khungve
        {
            get; set;
        }
        internal List<nguoichoi> DSNguoichoi { get => nguoichoi; set => nguoichoi = value; }
        public int Luotchoi { get => luotchoi; set => luotchoi = value; }
        public List<List<Button>> matranbt;
        private List<nguoichoi> nguoichoi;
        private int luotchoi;
        #endregion
        #region Initialize
        public banco(Panel khungve)
        {
            this.khungve = khungve;
            this.nguoichoi = new List<nguoichoi>() {
                new nguoichoi("Lê Tiến Hòa",Image.FromFile(Application.StartupPath+ "\\anh\\Bird-yellow-icon.png")),
                new nguoichoi("Bạn",Image.FromFile(Application.StartupPath+"\\anh\\Angry-Birds-icon.png"))
            };
            Luotchoi = 0;
        }
        #endregion
        #region Methodr



        // vẽ bàn cờ 
        public void vebanco()
        {
            khungve.Controls.Clear();
            matranbt = new List<List<Button>>(); 
            Button kc = new Button()
            {
                Width = 0,
                Height = 0,
                Location = new Point(0, 0)
            };
            int x = 0, y = 0;
            for (int i = 0; i < kichthuocbien.chieurong; i++)
            {
                matranbt.Add(new List<Button>());
                for (int j = 0; j < kichthuocbien.chieudai; j++)
                {
                    Button h = new Button()
                    {
                        Tag = i.ToString(),
                        Width = kichthuocbien.codai,
                        Height = kichthuocbien.corong,
                        Location = new Point(kc.Location.X + kc.Width, kc.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };                
                    khungve.Controls.Add(h);
                    matranbt[i].Add(h);
                    h.Click += H_Click;
                    kc = h;                   
                }
                kc.Location = new Point(0, kc.Location.Y + kichthuocbien.corong);
                kc.Width = 0;
                kc.Height = 0;
            }
        }
        private void H_Click(object sender, EventArgs e)
        {
            Button h = sender as Button;
            if (h.BackgroundImage == null)
            {
                h.BackgroundImage = DSNguoichoi[Luotchoi].Bieutuong;
                if (Luotchoi == 1)
                {
                    Luotchoi = 0;
                }
                else Luotchoi = 1;
            }
            if(kiemtrathang(h)==1)
            {
                MessageBox.Show("Ban da thang");
            }
        }
        #endregion




        // kiểm tra thắng thua 
        private int kiemtrathang(Button h)
        {
            int dem = 1;
            Point k = layvitri(h);
            // kiểm tra ngang
            if (dem < 5)
            {
                for (int i = k.X - 1; i >= 0; i--)
                {
                    if (matranbt[k.Y][i].BackgroundImage == h.BackgroundImage)
                    { dem++; }
                    else break;
                }
                for (int i = k.X + 1; i<kichthuocbien.chieudai; i++)
                {
                    if (matranbt[k.Y][i].BackgroundImage == h.BackgroundImage)
                    { dem++; }
                    else break;
                }
            }
            //kiểm tra dọc
            if(dem<5)
            {
            dem = 1;
                for (int i = k.Y - 1; i >= 0; i--)
                {
                    if (matranbt[i][k.X].BackgroundImage == h.BackgroundImage)
                    { dem++; }
                    else break;
                }
                for (int i = k.Y + 1; i<kichthuocbien.chieurong; i++)
                {
                    if (matranbt[i][k.X].BackgroundImage == h.BackgroundImage)
                    { dem++; }
                    else break;
                }
            }
            //kiẻm tra chéo xuôi
            if (dem <5)
            {
                dem = 1;
                for (int i =1;i<=5; i++)
                {
                    if ( k.X - i >= 0 && k.Y - i >= 0&&matranbt[k.Y-i][k.X-i].BackgroundImage == h.BackgroundImage )
                    { dem++; }
                    else break;
                }
                for (int i = 1; i <= 5; i++)
                {
                    if (k.X + i < kichthuocbien.chieudai && k.Y + i < kichthuocbien.chieurong && matranbt[k.Y+i][k.X+i].BackgroundImage == h.BackgroundImage )
                    { dem++; }
                    else break;
                }
            }
            //kiểm tra chéo ngược
            if (dem < 5)
            {
                dem = 1;
                for (int i = 1; i <= 5; i++)
                {
                    if ( k.Y - i >= 0 && k.X + i <kichthuocbien.chieudai && matranbt[k.Y-i][k.X+i].BackgroundImage == h.BackgroundImage )
                    { dem++; }
                    else break;
                }
                for (int i = 1; i <= 5; i++)
                {
                    if (k.Y + i <kichthuocbien.chieurong && k.X - i >= 0 && matranbt[k.Y+i][k.X-i].BackgroundImage == h.BackgroundImage )
                    { dem++; }
                    else break;
                }
            }
            if (dem>= 5)
            { return 1; }
            else return 0;
        }



        //lay toa do
        private Point layvitri(Button h)
        {
            Point n = new Point();
            int dong = Convert.ToInt32(h.Tag);
            int cot = matranbt[dong].IndexOf(h);
            n.X = cot;
            n.Y = dong;  
            return n;
        }




        public Point kiemtra()
        {
            for(int i=0;i<kichthuocbien.chieurong;i++)
            {
                for(int j=0;j<kichthuocbien.chieudai;j++)
                {
                    if(matranbt[i][j].BackgroundImage==null)
                    {

                    }
                }
            }
        }



        // 1 nguoi choi


        private void M_Click(object sender, EventArgs e)
        {
            Button h = sender as Button;
            if (luotchoi == 0)//neu luot choi la nguoi máy sẽ đứng yên:)))
            {
                if (h.BackgroundImage == null)
                {
                    h.BackgroundImage = DSNguoichoi[Luotchoi].Bieutuong;
                     Luotchoi = 1;
                }
                if (kiemtra(h) == 1)
                {
                    MessageBox.Show("Ban da thang");
                }
            }
            else if(luotchoi==1)
            {

            }
            if (kiemtra(h) == 1)
            {
                MessageBox.Show("Ban da thang");
            }
        }





        private int[] MangDiemTanCong = new int[7] { 0, 4, 25, 246, 7300, 6561, 59049 };
        private int[] MangDiemPhongNgu = new int[7] { 0, 3, 24, 243, 2197, 19773, 177957 };


        #region tancong
        public int duyetTCngang ( int i,int j)
        {
            int diemtancong=0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (j + dem < kichthuocbien.chieudai-4 && matranbt[i][j+dem].BackgroundImage==DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (j + dem < kichthuocbien.chieudai-4 && matranbt[i][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (j - dem > 4 && matranbt[i][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                       diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (j - dem >4 && matranbt[i][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public int duyetTCdoc(int i,int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i+ dem < kichthuocbien.chieurong - 4 && matranbt[i+dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i + dem < kichthuocbien.chieurong - 4 && matranbt[i+dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i - dem > 4 && matranbt[i-dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 4 && matranbt[i-dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }


        public int duyetTCcheoxuoi(int i,int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i + dem < kichthuocbien.chieurong && j + dem < kichthuocbien.chieudai && matranbt[i + dem][j+dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i + dem < kichthuocbien.chieurong && j + dem < kichthuocbien.chieudai && matranbt[i + dem][j+dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i - dem > 0 && j - dem > 0 && matranbt[i - dem][j-dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 0 && j - dem > 0 && matranbt[i - dem][j-dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }


        public int duyetTCcheonguoc(int i,int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i - dem >0 && j+ dem < kichthuocbien.chieudai && matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 0 && j + dem < kichthuocbien.chieudai && matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i + dem <kichthuocbien.chieurong && j - dem > 0 && matranbt[i + dem][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 0 && j - dem > 0 && matranbt[i - dem][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        #endregion

        #region phongthu


        public int duyetPTngang(int i, int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (j + dem < kichthuocbien.chieudai - 4 && matranbt[i][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (j + dem < kichthuocbien.chieudai - 4 && matranbt[i][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (j - dem > 4 && matranbt[i][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (j - dem > 4 && matranbt[i][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public int duyetPTdoc(int i, int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i + dem < kichthuocbien.chieurong - 4 && matranbt[i + dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i + dem < kichthuocbien.chieurong - 4 && matranbt[i + dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i - dem > 4 && matranbt[i - dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 4 && matranbt[i - dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public int duyetPTcheoxuoi(int i, int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i + dem < kichthuocbien.chieurong && j + dem < kichthuocbien.chieudai && matranbt[i + dem][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i + dem < kichthuocbien.chieurong && j + dem < kichthuocbien.chieudai && matranbt[i + dem][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i - dem > 0 && j - dem > 0 && matranbt[i - dem][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 0 && j - dem > 0 && matranbt[i - dem][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public int duyetPTcheonguoc(int i, int j)
        {
            int diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoitrai = 0;
            int soluongconguoiphai = 0;
            int khoangtrong = 0;
            //bên phải
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i - dem > 0 && j + dem < kichthuocbien.chieudai && matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 0 && j + dem < kichthuocbien.chieudai && matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoiphai++;
                    break;
                }
                else khoangtrong++;
            }
            //bên trái
            for (int dem = 1; dem <= 5; dem++)
            {
                if (i + dem < kichthuocbien.chieurong && j - dem > 0 && matranbt[i + dem][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    if (dem == 1)
                        diemtancong += 37;

                    soluongcomay++;
                    khoangtrong++;
                }
                else
                    if (i - dem > 0 && j - dem > 0 && matranbt[i - dem][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoitrai++;
                    break;
                }
                else khoangtrong++;
            }
            if (soluongconguoiphai > 0 && soluongconguoitrai > 0 && khoangtrong < 5)
                return 0;

            diemtancong -= MangDiemPhongNgu[2];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        #endregion
    }
}
