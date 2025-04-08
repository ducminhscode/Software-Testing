using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TrungTamGiaSu_31_Minh
{
    public partial class Form1 : Form
    {
        //Tạo danh sách đối tượng học viên
        public List<Student_31_Minh> listStudents_31_Minh = new List<Student_31_Minh>();
        public Form1()
        {
            InitializeComponent();

            //Gọi hàm load dữ liệu vào DataGridView
            LoadData_31_Minh();

            //Gọi hàm hiểm thị danh sách học viên
            showList_31_Minh();
        }

        private void addStudent_31_Minh_Click(object sender, EventArgs e)
        {
            try
            {
                //Lấy Student ID từ textbox
                String ma_31_Minh = maHocVien_31_Minh.Text;

                //Lấy Fullname từ textbox
                String ten_31_Minh = tenHocVien_31_Minh.Text;

                //Lấy Hometown từ textbox
                String que_31_Minh = queQuan_31_Minh.Text;

                //Lấy Math Score từ textbox
                double toan_31_Minh = double.Parse(diemToan_31_Minh.Text);

                //Lấy Literature Score từ textbox
                double van_31_Minh = double.Parse(diemVan_31_Minh.Text);

                //Lấy English Score từ textbox
                double tiengAnh_31_Minh = double.Parse(diemTiengAnh_31_Minh.Text);

                //Tạo đối tượng học viên
                Student_31_Minh std_31_Minh = new Student_31_Minh(ma_31_Minh, ten_31_Minh, que_31_Minh, toan_31_Minh, van_31_Minh, tiengAnh_31_Minh);

                //Kiểm tra thông tin học viên
                if (std_31_Minh.isNotEmptyInfo_31_Minh() == true)
                {
                    //Kiểm tra tính hợp lệ của điểm
                    if (std_31_Minh.isValidScore_31_Minh() == true)
                    {
                        //Thêm vào danh sách học viên
                        listStudents_31_Minh.Add(std_31_Minh);

                        //Hiển thị danh sách học viên
                        showList_31_Minh();
                    }
                    else
                    {
                        MessageBox.Show("Điểm số không hợp lệ");
                    }
                }
                else
                {
                    MessageBox.Show("Chưa điền đủ thông tin");
                }
            }
            catch
            {
                MessageBox.Show("Điểm số không để trống");
            }
        }

        private void listScholarship_31_Minh_Click(object sender, EventArgs e)
        {
            //Lọc các học viên thỏa điều kiện nhận học bổng
            var scholarshipStudents_31_Minh = listStudents_31_Minh.Where(s => (s.isScholarship_31_Minh() == true)).ToList();
            dataGridView_31_Minh.DataSource = null;
            dataGridView_31_Minh.DataSource = scholarshipStudents_31_Minh;
        }

        private void listStudent_31_Minh_Click(object sender, EventArgs e)
        {
            showList_31_Minh();
        }

        //Hiển thị danh sách học viên
        public void showList_31_Minh()
        {
            dataGridView_31_Minh.DataSource = null;
            dataGridView_31_Minh.DataSource = listStudents_31_Minh;
        }

        //Kiểm tra trùng mã học viên
        public bool isStudentExists_31_Minh(string studentId)
        {
            return listStudents_31_Minh.Any(s => s.StudentId_31_Minh == studentId);
        }

        //Dữ liệu mẫu
        private void LoadData_31_Minh()
        {
            listStudents_31_Minh.Add(new Student_31_Minh("HV01", "Trần Nguyễn Đức Minh", "Hà Nội", 9.1, 8.5, 8.4));
            listStudents_31_Minh.Add(new Student_31_Minh("HV02", "Nguyễn Thị Thúy Hạnh", "TP. HCM", 7.8, 6.3, 8.7));
            listStudents_31_Minh.Add(new Student_31_Minh("HV03", "Lê Văn Hiền", "Đà Nẵng", 5.9, 5.2, 6.1));
            listStudents_31_Minh.Add(new Student_31_Minh("HV04", "Trần Xuân Hưng", "Cần Thơ", 8.6, 8.5, 9.7));
            listStudents_31_Minh.Add(new Student_31_Minh("HV05", "Ngô Tấn Tài", "Bình Dương", 3.6, 7.8, 6.6));
            listStudents_31_Minh.Add(new Student_31_Minh("HV06", "Huỳnh Quốc Ánh", "Nha Trang", 7.9, 7.0, 10));
            listStudents_31_Minh.Add(new Student_31_Minh("HV07", "Hứa Quang Sáng", "Nghệ An", 8.3, 9.4, 8.8));
            listStudents_31_Minh.Add(new Student_31_Minh("HV08", "Cao Anh Thơ", "Huế", 10, 8.0, 9.2));
        }
    }
}
