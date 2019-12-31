using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;

namespace TDHe5blendingprj
{
    public partial class Mainfrm_TDHe5blending : Form
    {
        public Mainfrm_TDHe5blending()
        {
            InitializeComponent();
            //Start the new position of the Mainform
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(-7, 0);
            //this.TopMost = false;


        }
        
        //Code tạo thanh progress bar thẳng đứng cho tiến trình xuất hàng
        public class VerticalProgressBar : ProgressBar
        {
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams cp = base.CreateParams;
                    cp.Style |= 0x04;
                    return cp;
                }
            }
        }

        private void Mainfrm_TDHe5blending_Resize(object sender, EventArgs e)
        {
            
        }

        private void btn_TaoML_Click(object sender, EventArgs e)
        {
            //this code is to show Main form after hide
            /*
            this.Hide();
            using (frm_pending Frm_pending = new frm_pending())
                Frm_pending.ShowDialog();
            this.Show();
             */
            this.TopMost = false;
            this.btn_TaoML.Visible = false;
            frm_pending Frm_pending = new frm_pending();
            Frm_pending.ShowDialog();
            this.btn_TaoML.Visible = true;
            this.TopMost = true;
        }

        private void timer_Main_Tick(object sender, EventArgs e)
        {
            //Hiển thị thời gian hiện tại
            lbl_timenow.Text = DateTime.Now.ToString(); 

            //Mở giao thức kết nối với EDI bằng modbus
            //Đọc giá trị từ các thanh ghi của Controller và Terminal qua EDI bằng giao thức Modbus sử dụng EasyModbus
            //Đóng giao thức kết nối Modbus

            //Tính toán các giá trị cần thiết từ các thanh ghi

            //Mở kết nối đến CSDL
            //Ghi giá trị đọc được ở trên vào online database
            //Đóng kết nối đến CSDL
        }

        private void timer_graphic_update_Tick(object sender, EventArgs e)
        {
            //Cập nhật giá trị cho các hiển thị trên graphics
            //Bằng cách đọc từ online database và ghi lại vào các Textbox

        }

        private void btn_capnhattytrongE_Click(object sender, EventArgs e)
        {
            Int16 val1 = 0;
            Int16 val2 = 0;
            Int16 val3 = 30000;
            Int16 val4 = 16637;
            
            var byteval1 = BitConverter.GetBytes(val1);
            var byteval2 = BitConverter.GetBytes(val2);
            var byteval3 = BitConverter.GetBytes(val3);
            var byteval4 = BitConverter.GetBytes(val4);

            byte[] temp2 = new byte[8];
            temp2[0] = byteval1[0];
            temp2[1] = byteval1[1];
            temp2[2] = byteval2[0];
            temp2[3] = byteval2[1];

            temp2[4] = byteval3[0];
            temp2[5] = byteval3[1];
            temp2[6] = byteval4[0];
            temp2[7] = byteval4[1];

            this.TopMost = false;
            double mydouble = BitConverter.ToDouble(temp2,0);
            this.txt_tytrongE.Text = mydouble.ToString();
        }

        private void btn_resetsotongE_Click(object sender, EventArgs e)
        {
            
        }

    }
}
