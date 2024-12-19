using System;
using System.Data;
using System.Windows.Forms;

namespace de_02
{
    public partial class Form1 : Form
    {
        DataTable dataTable; // Bảng dữ liệu sản phẩm

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo bảng dữ liệu
            dataTable = new DataTable();
            dataTable.Columns.Add("MaSP");
            dataTable.Columns.Add("TenSP");
            dataTable.Columns.Add("NgayNhap", typeof(DateTime));
            dataTable.Columns.Add("LoaiSP");

            // Gắn dữ liệu vào DataGridView
            dataGridView1.DataSource = dataTable;

            // Thêm các tùy chọn vào ComboBox
            cboLoaiSP.Items.Add("Bánh kẹo");
            cboLoaiSP.Items.Add("Giải khát");
            cboLoaiSP.Items.Add("Thực phẩm khác");
            cboLoaiSP.SelectedIndex = 0; // Mặc định chọn loại đầu tiên
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSP = txtMaSP.Text;
            string tenSP = txtTenSP.Text;
            DateTime ngayNhap = dtNgayNhap.Value;
            string loaiSP = cboLoaiSP.SelectedItem.ToString();

            if (string.IsNullOrEmpty(maSP) || string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Thêm sản phẩm vào bảng
            dataTable.Rows.Add(maSP, tenSP, ngayNhap, loaiSP);

            // Xóa các ô nhập liệu sau khi thêm
            txtMaSP.Clear();
            txtTenSP.Clear();
            cboLoaiSP.SelectedIndex = 0;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                row.Cells["MaSP"].Value = txtMaSP.Text;
                row.Cells["TenSP"].Value = txtTenSP.Text;
                row.Cells["NgayNhap"].Value = dtNgayNhap.Value;
                row.Cells["LoaiSP"].Value = cboLoaiSP.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dữ liệu đã được lưu thành công.");
        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            MessageBox.Show("Dữ liệu đã được khôi phục.");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtMaSP.Text = row.Cells["MaSP"].Value?.ToString();
                txtTenSP.Text = row.Cells["TenSP"].Value?.ToString();
                dtNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                cboLoaiSP.SelectedItem = row.Cells["LoaiSP"].Value?.ToString();
            }
        }

      
    }
}
