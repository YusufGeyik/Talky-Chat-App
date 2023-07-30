using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myfunctions
{
    class MyFunction
    {

       public panel CreateChatBox(string tagname)
       {
            Panel chatdivider = new Panel();// her chat için bir panel oluştur.
                chatdivider.Location = new Point(50, 55 * aktifchatsayisi + 10);
                chatdivider.Height = 50;
                chatdivider.Width = 400;
                chatdivider.Padding = new System.Windows.Forms.Padding(1);
                chatdivider.BorderStyle = BorderStyle.Fixed3D;
                chatdivider.Tag =tragname;
                chatdivider.Click += new EventHandler(chatdivider_click);

                


                Label LabelMessage = new Label();//Mesaj Labelini oluştur.
                LabelMessage.Text = "Yusuf Merhaba, nasılsın? Umarım iyisindir";
                LabelMessage.Location = new Point(0, 20);
                LabelMessage.Font = new Font("Microsoft Sans Serif", 10);
                LabelMessage.Width = 300;
                LabelMessage.Height = 30;
                LabelMessage.AutoSize = true;
                LabelMessage.Tag=tagname
                chatdivider.Controls.Add(LabelMessage);  //labelı ilgili panele ekle



                Label LabelContactName = new Label();//kişi ismi için label oluştur.
                LabelContactName.Text = "Yakup";  // kişi ismi değişkenle atanacak****.
                LabelContactName.Width = 50;
                LabelContactName.Height = 30;
                LabelContactName.Location = new Point(0, 0);
                LabelContactName.Font = new Font("Microsoft Sans Serif", 8);
                LabelContactName.Tag=tagname;
                chatdivider.Controls.Add(LabelContactName);



                string johnsmithPath = @"C:\Users\YUSUF\WindowsFormsApp1\blue.png"; // standart icon ekleme
                PictureBox johnsmith = new PictureBox();
                johnsmith.Image = Image.FromFile(johnsmithPath);
                johnsmith.SizeMode = PictureBoxSizeMode.StretchImage;
                johnsmith.Width = 40;
                johnsmith.Height = 40;
                johnsmith.Location = new Point(0, 55 * aktifchatsayisi + 10);
                johnsmith.Tag=tagname;
                pnlChats.Controls.Add(johnsmith);


                string binPath = @"C:\Users\YUSUF\WindowsFormsApp1\bin.jpg"; //çöp kutusu iconu
                PictureBox Pctbin = new PictureBox();
                Pctbin.Image = Image.FromFile(binPath);
                Pctbin.SizeMode = PictureBoxSizeMode.StretchImage;
                Pctbin.Width = 40;
                Pctbin.Height = 40;
                Pctbin.Location = new Point(500, 55 * aktifchatsayisi + 10);
                Pctbin.BorderStyle = BorderStyle.Fixed3D;
                Pctbin.Click += new EventHandler(Pctbin_click);
                pnlChats.Controls.Add(Pctbin);




                CheckBox chckbxSil = new CheckBox();
                chckbxSil.Location = new Point(420, 0);
                chckbxSil.Tag = tagname
                pnlChats.Controls.Add(chckbxSil);


                pnlChats.Controls.Add(chatdivider);



       }


    }
}
