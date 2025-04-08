using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TrungTamGiaSu_31_Minh;

namespace TrungTamGiaSuUnitTest_31_Minh
{
    [TestClass]
    public class UnitTest_31_Minh
    {
        //Tạo đối tượng TestContext cho lớp UnitTest
        public TestContext TestContext { get; set; }

        private string studentId_31_Minh;
        private string fullName_31_Minh;
        private string homeTown_31_Minh;
        private double mathScore_31_Minh;
        private double literatureScore_31_Minh;
        private double englishScore_31_Minh;
        private bool isSchls_31_Minh;
        private string errorMessage = "";

        Form1 form = new Form1();

        //Kiểm thử với 7 cột và 8 hàng dữ liệu có sẵn
        //Hàng 1: studentId_31_Minh = 'HV01', fullName_31_Minh = 'Tran Nguyen Duc Minh', homeTown_31_Minh = 'Ha Noi',
        //mathScore_31_Minh = 9.1, literatureScore_31_Minh = 8.5, englishScore_31_Minh = 8.4, isSchls_31_Minh = true

        //Hàng 2: studentId_31_Minh = 'HV02', fullName_31_Minh = 'Nguyen Thi Thuy Hanh', homeTown_31_Minh = 'TP.HCM',
        //mathScore_31_Minh = 7.8, literatureScore_31_Minh = 6.3, englishScore_31_Minh = 8.7, isSchls_31_Minh = false

        //Hàng 3: studentId_31_Minh = 'HV03', fullName_31_Minh = 'Le Van Hien', homeTown_31_Minh = 'Da Nang',
        //mathScore_31_Minh = 5.9, literatureScore_31_Minh = 5.2, englishScore_31_Minh = 6.1, isSchls_31_Minh = false

        //Hàng 4: studentId_31_Minh = 'HV04', fullName_31_Minh = 'Tran Xuan Hung', homeTown_31_Minh = 'Can Tho',
        //mathScore_31_Minh = 8.6, literatureScore_31_Minh = 8.5, englishScore_31_Minh = 9.7, isSchls_31_Minh = true

        //Hàng 5: studentId_31_Minh = 'HV05', fullName_31_Minh = 'Ngo Tan Tai', homeTown_31_Minh = 'Binh Duong',
        //mathScore_31_Minh = 3.6, literatureScore_31_Minh = 7.8, englishScore_31_Minh = 6.6, isSchls_31_Minh = false

        //Hàng 6: studentId_31_Minh = 'HV06', fullName_31_Minh = 'Huynh Quoc Anh', homeTown_31_Minh = 'Nha Trang',
        //mathScore_31_Minh = 7.9, literatureScore_31_Minh = 7.0, englishScore_31_Minh = 10, isSchls_31_Minh = true

        //Hàng 7: studentId_31_Minh = 'HV07', fullName_31_Minh = 'Hua Quang Sang', homeTown_31_Minh = 'Nghe An',
        //mathScore_31_Minh = 8.3, literatureScore_31_Minh = 9.4, englishScore_31_Minh = 8.8, isSchls_31_Minh = true

        //Hàng 8: studentId_31_Minh = 'HV08', fullName_31_Minh = 'Cao Anh Tho', homeTown_31_Minh = 'Hue',
        //mathScore_31_Minh = 10, literatureScore_31_Minh = 8.0, englishScore_31_Minh = 9.2, isSchls_31_Minh = true

        [TestInitialize]
        public void SetUp_31_Minh()
        {
            //Cột dữ liệu đầu tiên
            studentId_31_Minh = TestContext.DataRow[0].ToString();

            //Cột dữ liệu thứ hai
            fullName_31_Minh = TestContext.DataRow[1].ToString();

            //Cột dữ liệu thứ ba
            homeTown_31_Minh = TestContext.DataRow[2].ToString();

            //Cột dữ liệu thứ tư
            mathScore_31_Minh = double.Parse(TestContext.DataRow[3].ToString());

            //Cột dữ liệu thứ năm
            literatureScore_31_Minh = double.Parse(TestContext.DataRow[4].ToString());

            //Cột dữ liệu thứ sáu
            englishScore_31_Minh = double.Parse(TestContext.DataRow[5].ToString());

        }

        //Test case 1: Thực hiện thêm học viên vào danh sách (3 Pass, 5 Fail)
        //Hàng 1, 3, 5: "Mã sinh viên bị trùng" (FaiL)
        //Hàng 2, 4: "Điểm không hợp lệ" (Fail)
        //Hàng 6, 7, 8: (Pass)
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data_31_Minh\StudentsData_31_Minh.csv", "StudentsData_31_Minh#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC1_AddStudent_31_Minh()
        {
            //Đếm số lượng học viên ban đầu có trong danh sách
            int init_31_Minh = form.listStudents_31_Minh.Count;

            //Tạo đối tượng học viên
            Student_31_Minh student_31_Minh = new Student_31_Minh(studentId_31_Minh, fullName_31_Minh, homeTown_31_Minh, mathScore_31_Minh, literatureScore_31_Minh, englishScore_31_Minh);

            //Điều kiện điền đủ thông tin
            if (student_31_Minh.isNotEmptyInfo_31_Minh())
            {
                //Điều kiện không có mã sinh viên bị trùng
                if (!form.isStudentExists_31_Minh(studentId_31_Minh))
                {
                    //Điều kiện điểm số hợp lệ
                    if (student_31_Minh.isValidScore_31_Minh())
                    {
                        // Thêm vào danh sách học viên
                        form.listStudents_31_Minh.Add(student_31_Minh);
                    }
                    else
                    {
                        errorMessage = "Điểm không hợp lệ";
                    }
                }
                else
                {
                    errorMessage = "Mã học viên đã tồn tại";
                }
            }
            else
            {
                errorMessage = "Chưa điền đủ thông tin";
            }

            Console.WriteLine(init_31_Minh); //Hiển thị số lượng học viên ban đầu có trong danh sách
            Console.WriteLine("====================");
            Console.WriteLine(form.listStudents_31_Minh.Count); //Hiển thị ra số lượng học viên sau khi thêm học viên

            //So sánh kết quả mong muốn (1) và kết quả thực tế (form.listStudents_31_Minh.Count - init_31_Minh)
            Assert.AreEqual(1, form.listStudents_31_Minh.Count - init_31_Minh, errorMessage);
        }

        //Test case 2: Thực hiện lọc thành công danh sách học viên nhận học bổng (8 Pass, 0 Fail)
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data_31_Minh\StudentsData2_31_Minh.csv", "StudentsData2_31_Minh#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TC2_ListScholarshipStudents_31_Minh()
        {
            //Cột dữ liệu thứ bảy
            isSchls_31_Minh = bool.Parse(TestContext.DataRow[6].ToString());

            //Khai báo danh sách kết quả mong muốn chứa đối tượng học viên nhận học bổng
            List<Student_31_Minh> expected_31_Minh = new List<Student_31_Minh>();
            //Khai báo danh sách kết quả thực tế chứa đối tượng học viên nhận học bổng
            List<Student_31_Minh> actual_31_Minh = new List<Student_31_Minh>();

            //Tạo đối tượng học viên
            Student_31_Minh student_31_Minh = new Student_31_Minh(studentId_31_Minh, fullName_31_Minh, homeTown_31_Minh, mathScore_31_Minh, literatureScore_31_Minh, englishScore_31_Minh);

            //Điều kiện để là một học viên
            if (student_31_Minh.isNotEmptyInfo_31_Minh() == true && student_31_Minh.isValidScore_31_Minh() == true)
            {
                if (isSchls_31_Minh == true)
                {
                    //Thêm vào danh sách kết quả mong muốn
                    expected_31_Minh.Add(student_31_Minh);
                }
                //Kiểm tra điều kiện để nhận học bổng
                if (student_31_Minh.isScholarship_31_Minh() == true)
                {
                    //Thêm vào danh sách kết quả thực tế
                    actual_31_Minh.Add(student_31_Minh);
                }
            }

            //Hiển thị thông tin học viên có trong danh sách kết quả mong muốn
            foreach (Student_31_Minh s_31_Minh in expected_31_Minh)
            {
                Console.WriteLine($"Student ID: {s_31_Minh.StudentId_31_Minh}, Fullname: {s_31_Minh.FullName_31_Minh}, Hometown: {s_31_Minh.HomeTown_31_Minh}, " +
                      $"Math: {s_31_Minh.MathScore_31_Minh}, Literature: {s_31_Minh.LiteratureScore_31_Minh}, English: {s_31_Minh.EnglishScore_31_Minh}, " +
                      $"Scholarship: {s_31_Minh.isScholarship_31_Minh()}");
            }
            Console.WriteLine("====================");

            //Hiển thị thông tin học viên có trong danh sách kết quả thực tế
            foreach (Student_31_Minh s_31_Minh in actual_31_Minh)
            {
                Console.WriteLine($"Student ID: {s_31_Minh.StudentId_31_Minh}, Fullname: {s_31_Minh.FullName_31_Minh}, Hometown: {s_31_Minh.HomeTown_31_Minh}, " +
                      $"Math: {s_31_Minh.MathScore_31_Minh}, Literature: {s_31_Minh.LiteratureScore_31_Minh}, English: {s_31_Minh.EnglishScore_31_Minh}, " +
                      $"Scholarship: {s_31_Minh.isScholarship_31_Minh()}");
            }

            //So sánh kết quả mong muốn (expected_31_Minh) và kết quả thực tế (actual_31_Minh)
            CollectionAssert.AreEqual(expected_31_Minh, actual_31_Minh, "Danh sách học viên nhận học bổng không giống nhau");
        }
    }
}
