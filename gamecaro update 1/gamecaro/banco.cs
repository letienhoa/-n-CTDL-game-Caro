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
        private Stack<LuuStack> Bangluu;
        internal List<nguoichoi> DSNguoichoi { get => nguoichoi; set => nguoichoi = value; }
        public int Luotchoi { get => luotchoi; set => luotchoi = value; }
        public List<List<Button>> matranbt;
        private List<nguoichoi> nguoichoi;
        private int luotchoi;
        public int luotdau { get; set; }
        public int chedochoi { get; set; }
        #endregion
        #region Initialize
        public banco(Panel khungve)
        {
            this.khungve = khungve;
            this.nguoichoi = new List<nguoichoi>() {
                new nguoichoi("Lê Tiến Hòa",Image.FromFile(Application.StartupPath+ "\\anh\\Bird-yellow-icon.png")),
                new nguoichoi("Bạn",Image.FromFile(Application.StartupPath+"\\anh\\Angry-Birds-icon.png"))
            };
            luotdau = 0;
            Bangluu = new Stack<LuuStack>(); 
        }

        
        #endregion
        #region Tạo bàn cờ
        // tạo bàn cờ 
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
            if(luotchoi==1&&luotdau==0)
            {
                maychoi();
            }
        }
        private void H_Click(object sender, EventArgs e)
        {
            Button h = sender as Button;
            if (chedochoi == 1)
            {
                if (luotchoi == 0)
                {
                    nguoichoi1(h);

                }
                if (luotchoi == 1)
                {
                    maychoi();

                }
            }
            else
            {
                if (luotchoi == 0)
                {
                    nguoichoi1(h);

                }
                else if (luotchoi == 1)
                {
                    nguoichoi2(h);
                }
            }

        }
        public void maychoi()
        {
            if (luotdau == 0)
            {
                Point h2 = new Point();
                h2.X = 8;
                h2.Y = 7;
                LuuStack IFplay = new LuuStack(h2, 1);
                Bangluu.Push(IFplay);
                matranbt[h2.Y][h2.X].BackgroundImage = DSNguoichoi[1].Bieutuong;
                luotchoi = 0;
                luotdau = 1;
            }
            else
            {
                Point h2 = chonvitri();
                LuuStack IFplay = new LuuStack(h2, 1);
                Bangluu.Push(IFplay);
                matranbt[h2.Y][h2.X].BackgroundImage = DSNguoichoi[1].Bieutuong;
                luotchoi = 0;             
                if (kiemtrathang(h2.Y, h2.X) == 1)
                {
                    MessageBox.Show("YOU LOSE ");
                    luotchoi = 3;
                }
            }
        }
        public void nguoichoi1(Button h)
        {
            if (h.BackgroundImage == null)
            {
                h.BackgroundImage = DSNguoichoi[0].Bieutuong;
                Luotchoi = 1;
                luotdau = 1;
            }
            Point h1 = layvitri(h);
            LuuStack IFplay = new LuuStack(h1, 0);
            Bangluu.Push(IFplay);
            if (kiemtrathang(h1.Y, h1.X) == 1)
            {
                if (chedochoi == 1)
                {
                    MessageBox.Show("YOU WIN, CONGRATULATION !!!");
                    luotchoi = 3;
                }
                else
                {
                    MessageBox.Show("PLAYER 1 WIN, CONGRATULATION !!!");
                    luotchoi = 3;
                }
            }
        }
        public void nguoichoi2(Button h)
        {
            if (h.BackgroundImage == null)
            {
                h.BackgroundImage = DSNguoichoi[1].Bieutuong;
                Luotchoi = 0;
            }
            Point h1 = layvitri(h);
            LuuStack IFplay = new LuuStack(h1, 0);
            Bangluu.Push(IFplay);
            if (kiemtrathang(h1.Y, h1.X) == 1)
            {
                MessageBox.Show("PLAYER 2 WIN, CONGRATULATION !!!");
                luotchoi = 3;
            }
        }
        #endregion
        // kiểm tra thắng thua 
        private int kiemtrathang(int hang,int cot)
        {
            int dem = 1;
            int chan = 0;
            // kiểm tra ngang
            if (dem < 5)
            {
                for (int i = cot - 1; i >= 0; i--)
                {
                    if (matranbt[hang][i].BackgroundImage == matranbt[hang][cot].BackgroundImage)
                    { dem++; }
                    else if(matranbt[hang][i].BackgroundImage !=null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
                for (int i = cot + 1; i<kichthuocbien.chieudai-1; i++)
                {
                    if (matranbt[hang][i].BackgroundImage == matranbt[hang][cot].BackgroundImage)
                    { dem++; }
                    else if (matranbt[hang][i].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
            }
            //kiểm tra dọc
            if(dem<5)
            {
                chan = 0;
            dem = 1;
                for (int i = hang - 1; i >= 0; i--)
                {
                    if (matranbt[i][cot].BackgroundImage == matranbt[hang][cot].BackgroundImage)
                    { dem++; }
                    else if (matranbt[i][cot].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
                for (int i = hang + 1; i<kichthuocbien.chieurong; i++)
                {
                    if (matranbt[i][cot].BackgroundImage == matranbt[hang][cot].BackgroundImage)
                    { dem++; }
                    else if (matranbt[i][cot].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
            }
            //kiẻm tra chéo xuôi
            if (dem <5)
            {
                chan = 0;
                dem = 1;
                for (int i =1; hang - i >= 0 && cot - i >= 0 && i <=5; i++)
                {
                    if ( matranbt[hang-i][cot-i].BackgroundImage == matranbt[hang][cot].BackgroundImage )
                    { dem++; }
                    else if (matranbt[hang-i][cot-i].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
                for (int i = 1; cot + i < kichthuocbien.chieudai - 1 && hang + i < kichthuocbien.chieurong && i <= 5; i++)
                {
                    if ( matranbt[hang+i][cot+i].BackgroundImage == matranbt[hang][cot].BackgroundImage )
                    { dem++; }
                    else if (matranbt[hang + i][cot + i].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
            }
            //kiểm tra chéo ngược
            if (dem < 5)
            {
                chan = 0;
                dem = 1;
                for (int i = 1; hang - i >= 0 && cot + i < kichthuocbien.chieudai - 1 && i <= 5; i++)
                {
                    if (matranbt[hang-i][cot+i].BackgroundImage == matranbt[hang][cot].BackgroundImage )
                    { dem++; }
                    else if (matranbt[hang - i][cot + i].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
                for (int i = 1; hang + i < kichthuocbien.chieurong && cot - i >= 0 && i <= 5; i++)
                {
                    if (matranbt[hang+i][cot-i].BackgroundImage == matranbt[hang][cot].BackgroundImage )
                    { dem++; }
                    else if (matranbt[hang + i][cot- i].BackgroundImage != null)
                    {
                        chan++;
                        break;
                    }
                    else break;
                }
            }
            if (dem>= 5&&chan<2)
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
        public Point chonvitri()
        {
            long max = -999999;
            Point h = new Point(0, 0);
            for(int i=0;i<kichthuocbien.chieurong;i++)
            {
                for(int j=0;j<kichthuocbien.chieudai-1;j++)
                {
                    if(matranbt[i][j].BackgroundImage==null)
                    {
                        long diemtancong = duyetTCngang(i, j) + duyetTCdoc(i, j) + duyetTCcheoxuoi(i, j) + duyetTCcheonguoc(i, j);
                        long diemphongthu = duyetPTngang(i, j) + duyetPTdoc(i, j) + duyetPTcheoxuoi(i, j) + duyetPTcheonguoc(i, j);
                        long max1;
                        if (diemtancong > diemphongthu)
                        { max1 = diemtancong; }
                        else { max1 = diemphongthu; }
                        if(max1>=max)
                        {
                            max = max1;
                            h.X = j;
                            h.Y = i;
                        }
                    }
                }
            } return h;
        }

        public long[] MangDiemTanCong = new long[7] { 0,12, 36, 150, 1500, 12000, 98000 };
        public long[] MangDiemPhongNgu = new long[7] { 0, 4, 12, 36, 3600, 6000, 59000 };
        #region tancong
        public long duyetTCngang( int i,int j)
        {
            long diemtancong=0;
            int soluongcomay = 0;
            int soluongconguoi = 0;   
            //bên phải
            for (int dem = 1; j + dem < kichthuocbien.chieudai-1 && dem <= 5; dem++)
            {
                if ( matranbt[i][j+dem].BackgroundImage==DSNguoichoi[1].Bieutuong)
                { 
                    soluongcomay++;
                }
                else
                    if (matranbt[i][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; j - dem >= 0 && dem <= 5; dem++)
            {
                if  (matranbt[i][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                }
                else
                    if ( matranbt[i][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            if (soluongconguoi == 2)
                return 0;

            diemtancong -= MangDiemPhongNgu[soluongconguoi+1];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public long duyetTCdoc(int i,int j)
        {
            long diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoi = 0;
           
           
            //bên phải
            for (int dem = 1; i + dem < kichthuocbien.chieurong && dem <= 5; dem++)
            {
                if ( matranbt[i+dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                }
                else
                    if ( matranbt[i+dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; i - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i-dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {               
                    soluongcomay++;                   
                }
                else
                    if ( matranbt[i-dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            if (soluongconguoi== 2)
                return 0;

            diemtancong -= MangDiemPhongNgu[soluongconguoi+1];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public long duyetTCcheoxuoi(int i,int j)
        {
            long diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoi=0;
       
            
            //bên phải
            for (int dem = 1; i + dem < kichthuocbien.chieurong && j + dem < kichthuocbien.chieudai-1 && dem <= 5; dem++)
            {
                if (matranbt[i + dem][j+dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;              
                }
                else
                    if ( matranbt[i + dem][j+dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; i - dem >= 0 && j - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i - dem][j-dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;            
                }
                else
                    if ( matranbt[i - dem][j-dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            if (soluongconguoi==2)
                return 0;
            diemtancong -= MangDiemPhongNgu[soluongconguoi+1];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        public long duyetTCcheonguoc(int i,int j)
        {
            long diemtancong = 0;
            int soluongcomay = 0;
            int soluongconguoi= 0;
            
            //bên phải
            for (int dem = 1; i - dem >= 0 && j + dem < kichthuocbien.chieudai-1 && dem <= 5; dem++)
            {
                if (matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;                   
                }
                else
                    if ( matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; i + dem < kichthuocbien.chieurong && j - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i + dem][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;                   
                }
                else
                    if (matranbt[i + dem][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    break;
                }
                else break;
            }
            if (soluongconguoi ==2)
                return 0;
            diemtancong -= MangDiemPhongNgu[soluongconguoi+1];
            diemtancong += MangDiemTanCong[soluongcomay];
            return diemtancong;
        }
        #endregion

        #region phongthu
        public long duyetPTngang(int i, int j)
        {
            long diemphongthu = 0;
            int soluongcomay = 0;
            int soluongconguoi = 0;
           
            //bên phải
            for (int dem = 1; j + dem < kichthuocbien.chieudai-1 && dem <= 5; dem++)
            {
                if ( matranbt[i][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                }
                else
                    if (matranbt[i][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; j - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;   
                }
                else
                    if (matranbt[i][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            if (soluongcomay == 2)
                return 0;
            if (soluongcomay == 0 && soluongconguoi == 3)
            {
                diemphongthu += MangDiemPhongNgu[soluongconguoi + 1];
                return diemphongthu;
            }
            diemphongthu += MangDiemPhongNgu[soluongconguoi];
            return diemphongthu;
        }
        public long duyetPTdoc(int i, int j)
        {
            long diemphongthu = 0;
            int soluongcomay = 0;
            int soluongconguoi = 0;
            
            //bên phải
            for (int dem = 1; i + dem < kichthuocbien.chieurong && dem <= 5; dem++)
            {
                if ( matranbt[i + dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;   
                }
                else
                    if ( matranbt[i + dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; i - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i - dem][j].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;                    
                }
                else
                    if ( matranbt[i - dem][j].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            if (soluongcomay==2)
                return 0;
            if (soluongcomay == 0 && soluongconguoi == 3)
            {
                diemphongthu += MangDiemPhongNgu[soluongconguoi + 1];
                return diemphongthu;
            }
            diemphongthu += MangDiemPhongNgu[soluongconguoi];
            return diemphongthu;
        }
        public long duyetPTcheoxuoi(int i, int j)
        {

            long diemphongthu = 0;
            int soluongcomay = 0;
            int soluongconguoi = 0;
           
            //bên phải
            for (int dem = 1; i + dem < kichthuocbien.chieurong && j + dem < kichthuocbien.chieudai-1 && dem <= 5; dem++)
            {
                if ( matranbt[i + dem][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                { 
                    soluongconguoi++;
                    
                }
                else
                    if ( matranbt[i + dem][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; i - dem >= 0 && j - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i - dem][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                }
                else
                    if ( matranbt[i - dem][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            if (soluongcomay ==2)
                return 0;
            if (soluongcomay == 0 && soluongconguoi == 3)
            {
                diemphongthu += MangDiemPhongNgu[soluongconguoi + 1];
                return diemphongthu;
            }
            diemphongthu += MangDiemPhongNgu[soluongconguoi];
            return diemphongthu;
        }
        public long duyetPTcheonguoc(int i, int j)
        {
            long diemphongthu = 0;
            int soluongcomay = 0;
            int soluongconguoi = 0;
            
            //bên phải
            for (int dem = 1; i - dem >= 0 && j + dem < kichthuocbien.chieudai-1 && dem <= 5; dem++)
            {
                if ( matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;   
                }
                else
                    if ( matranbt[i - dem][j + dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            //bên trái
            for (int dem = 1; i + dem < kichthuocbien.chieurong && j - dem >= 0 && dem <= 5; dem++)
            {
                if ( matranbt[i + dem][j - dem].BackgroundImage == DSNguoichoi[0].Bieutuong)
                {
                    soluongconguoi++;
                    
                }
                else
                    if ( matranbt[i + dem][j - dem].BackgroundImage == DSNguoichoi[1].Bieutuong)
                {
                    soluongcomay++;
                    break;
                }
                else break;
            }
            if (soluongcomay ==2)
                return 0; 
            if(soluongcomay==0&&soluongconguoi==3)
            {
                diemphongthu += MangDiemPhongNgu[soluongconguoi+1];
                return diemphongthu;
            }
            diemphongthu += MangDiemPhongNgu[soluongconguoi];
            return diemphongthu;
        }
        #endregion

        public void Undo()
        {
            if (chedochoi == 1)
            {
                if (Bangluu.Count >= 2 && luotchoi != 3)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        LuuStack buocdadi = new LuuStack();
                        buocdadi = Bangluu.Pop();
                        matranbt[buocdadi.point.Y][buocdadi.point.X].BackgroundImage = null;
                        if (buocdadi.luuluotchoi == 1)
                        {
                            luotchoi = 0;
                        }

                    }
                }
            }
            else
            {
                if (Bangluu.Count >= 1 && luotchoi != 3)
                {
                   LuuStack buocdadi = new LuuStack();
                   buocdadi = Bangluu.Pop();
                   matranbt[buocdadi.point.Y][buocdadi.point.X].BackgroundImage = null;
                   if (buocdadi.luuluotchoi == 1)
                   {
                       luotchoi = 0;
                   }
                   else if(luotchoi==0)
                    {
                        luotchoi = 1;
                    }
                }
            }
        }
    }
}
